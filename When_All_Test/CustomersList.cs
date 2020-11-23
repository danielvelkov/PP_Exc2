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
    class CustomersList:NPC
    {
        Random seed = new Random();
        List<Customer> customers;
        List<Customer> searchedCustomers;
        string ids;

        public List<Customer> Customers { get => customers; set => customers = value; }
        public List<Customer> SearchedCustomers
        {
            get
            {
                return searchedCustomers;
            }
            set
            {
                if (searchedCustomers != value)
                {
                    searchedCustomers = value;
                    NotifyPropertyChanged("SearchedCustomers");
                }
            }
        }
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
            SearchedCustomers = new List<Customer>();
            Customers = new List<Customer>()
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

        

        public async Task<Customer> GetCustomerAsync(int Id)
        {
            await Task.Delay(seed.Next(100, 1000));
            return Customers.SingleOrDefault(x => x.Id == Id);
        }

        public async Task<Customer[]> GetCustomersAsync(List<int> Ids)
        {
            List<Task<Customer>> tasks = new List<Task<Customer>>();
            foreach (int id in Ids)
            {
                tasks.Add(GetCustomerAsync(id));
            }
            return await Task.WhenAll(tasks);
        }

        AsyncCommand getCustByMultIdsAsync;
        public AsyncCommand GetCust {
            get
            {
                return getCustByMultIdsAsync ?? (getCustByMultIdsAsync = new AsyncCommand(DisplayCustAsync, () => { return true; }));
            }
        }

        public async Task DisplayCustAsync()
        {
            List<string> IDS = TextIds.Split(',').ToList();
            List<int> intIds = new List<int>();
            foreach (string id in IDS)
            {
                try
                {
                    intIds.Add(Int32.Parse(id));
                }
                catch
                {
                    intIds.Add(-1);
                }
            }
            SearchedCustomers= (await GetCustomersAsync(intIds)).ToList();
        }
    }
}
