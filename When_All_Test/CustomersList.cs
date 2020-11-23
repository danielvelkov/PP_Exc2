using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using When_All_Test.Model;

namespace When_All_Test
{
    class CustomersList:NotifyPropertChanged
    {
        Random seed = new Random();
        ObservableCollection<Customer> customers;
        ObservableCollection<Customer> searchedCustomers;
        string ids;

        public ObservableCollection<Customer> Customers { get => customers; set => customers = value; }
        public ObservableCollection<Customer> SearchedCustomers { get => searchedCustomers; set => searchedCustomers = value; }
        public string TextIds {
            get
            {
                return ids;
            }
            set
            {
                if (ids != value)
                {
                    ids = value;
                    NotifyPropertyChanged("TextIds");
                }
            }
        }
        

        public CustomersList()
        {
            SearchedCustomers = new ObservableCollection<Customer>();
            Customers = new ObservableCollection<Customer>()
            {
                new Customer(1,"Bibo baggins","nowher strt",1),
                new Customer(2,"frodo","nowher blv",3),
                new Customer(3,"gandalf","nowher",5),
                new Customer(5,"smeagl","nowher blv",7),
                new Customer(8,"pippin","nowher",1),
                new Customer(9,"Dingus","nowher blv",2),
                new Customer(10,"Huffleberry","nowher",5),
                new Customer(12,"Dodo","nowher",3),
                new Customer(16,"Burb","nowher",8),
                new Customer(17,"Cintia","nowher",54),
                new Customer(18,"Selena","nowher",25),
                new Customer(19,"Sarah","nowher",65),
                new Customer(20,"Saxop","nowher",75),
                new Customer(21,"Blakcbeard","nowher",15),
                new Customer(22,"Tony","nowher",56),
                new Customer(23,"fauycy","nowher",58),
                new Customer(24,"Lod","nowher",15),
                new Customer(25,"Clyd","nowher",25),
                new Customer(27,"Dren","nowher",65),
                new Customer(29,"Bibo","nowher",15),
            }; 
        }

        

        public async Task<Customer> GetCustomer(int Id)
        {
            await Task.Delay(seed.Next(100, 1000));
            return Customers.SingleOrDefault(x => x.Id == Id);
        }

        public async Task<Customer[]> GetCustomersAsync(List<int> Ids)
        {
            List<Task> tasks = new List<Task>();
            foreach (int id in Ids)
            {
                Task<Customer> t = GetCustomer(id);
                tasks.Add(t);

            }
            Task t=await Task.WhenAll(tasks);
            return 
        }


        AsyncCommand getCust;
        public AsyncCommand GetCust {
            get
            {
                return getCust ?? (getCust = new AsyncCommand(PutCust, () => { return true; }));
            }
        }

        public async Task PutCust()
        {
            List<string> IDS = TextIds.Split(',').ToList();
            List<int> intIds = new List<int>();
            foreach (string id in IDS)
            {
                intIds.Add(Int32.Parse(id));
            }
            SearchedCustomers= await GetCustomersAsync(intIds);
        }


    }
}
