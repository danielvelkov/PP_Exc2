using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace When_All_Test.Model
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NumberOfOrders { get; set; }

        public Customer(int id,string name,string address,int numberOrders)
        {
            Id = id;
            Name = name;
            Address = address;
            NumberOfOrders = numberOrders;
        }
        
    }
}
