using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Second_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ReadFile(object sender, RoutedEventArgs e)
        {
            //Dictionary<string, int> wordOccurances = new Dictionary<string, int>();
            //await Task.Run(() =>
            //{
            //   string text = System.IO.File.ReadAllText(@"big.txt");
            //    var matches = Regex.Matches(text, @"\b[\w']*\b");
            //    var words = from m in matches.Cast<Match>()
            //                where !string.IsNullOrEmpty(m.Value)
            //                select TrimSuffix(m.Value.ToLowerInvariant());
            //    foreach (var word in words)
            //    {
            //        if (!wordOccurances.Any(x => x.Key == word))
            //        {
            //            wordOccurances.Add(word, 1);
            //        }
            //        else wordOccurances[word]++;
            //    }
            //});


            //takes around 200 sec to complete 

            ConcurrentDictionary<string, int> wordOccurances = new ConcurrentDictionary<string, int>();
            await Task.Run(() =>
            {
                string text = System.IO.File.ReadAllText(@"big.txt");


                var matches = Regex.Matches(text, @"\b[\w']*\b");
                var words = (from m in matches.Cast<Match>()
                             where !string.IsNullOrEmpty(m.Value)
                             select TrimSuffix(m.Value.ToLowerInvariant())).AsEnumerable<string>();
                ConcurrentBag<string> cb = new ConcurrentBag<string>();
                foreach (var word in words)
                    cb.Add(word);
                Parallel.ForEach<string>(cb, (word) =>
                {
                    wordOccurances.AddOrUpdate(word, 1, (key, oldValue) => oldValue += 1);
                });
                //takes around 5 sec to complete
            });
            lstBox.ItemsSource = wordOccurances.OrderBy(x=>x.Value);
        }

        static string TrimSuffix(string word)
        {
            int apostropheLocation = word.IndexOf('\'');
            if (apostropheLocation != -1)
            {
                word = word.Substring(0, apostropheLocation);
            }

            return word;
        }
    }
}
