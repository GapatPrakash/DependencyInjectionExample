using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace DependencyInjectionExample
{
    class Program
    {
        static void Main(string[] args)
        {

            IUnityContainer containerObject = new UnityContainer();
            
            containerObject.RegisterType<Customer>();
           
            containerObject.RegisterType<IDataLayer, OracleClass>();
           // containerObject.RegisterType<IDataLayer, MySqlClass>();

           

            Customer custObject = containerObject.Resolve<Customer>();
                
            //MySqlClass myaqlobj = new MySqlClass();
            //Customer custObject = new Customer(new MySqlClass());
            custObject.CustID = 1;
            custObject.CustName = "Prakash";
            //containerObject.LoadConfiguration();
            custObject.Add();




        }
    }


    class Customer
    {
        public int CustID { get; set; }
        public string CustName { get; set; }

        //MySqlClass mysqlobj = new MySqlClass();
        //OracleClass oraclobj = new OracleClass();
        IDataLayer idatlayer;


        public Customer(IDataLayer I)
        {
            idatlayer = I;
        }



        public void Add()
        {
            
            idatlayer.Add();
        }
    }


    interface IDataLayer
    {
        void Add(); 
    }


    class MySqlClass : IDataLayer
    {
        public void Add()
        {
            Console.WriteLine("Record Added !!");
            
        }

    }
    class OracleClass : IDataLayer
    {
        public void Add()
        {
            Console.WriteLine("Record Added !!");
            
        }

    }

}
