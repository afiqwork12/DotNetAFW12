using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingEntityFrameworkApp
{
    class Program
    {
        readonly pubsEntities _entities;
        public Program()
        {
            _entities = new pubsEntities();
        }
        void PrintAuthors()
        {
            var authors = _entities.authors.ToList();
            foreach (var auth in authors)
            {
                Console.WriteLine(auth.au_id);
                Console.WriteLine(auth.au_fname + " " + auth.au_lname);
                Console.WriteLine(auth.address);
                Console.WriteLine(auth.state);
                Console.WriteLine("==============================");
            }
        }
        void PrintStore()
        {
            var stores = _entities.stores.ToList();
            Console.WriteLine("Printing stores");
            Console.WriteLine("{0,-10} | {1,-40} | {2,-20} | {3,-20} | {4,-10} | {5,-10}", "stor_id", "stor_name", "stor_address", "city", "state", "zip");
            foreach (var store in stores)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-20} | {3,-20} | {4,-10} | {5,-10}", store.stor_id, store.stor_name, store.stor_address, store.city, store.state, store.zip);
            }
        }
        void InsertStore()
        {
            store store = new store();
            store.stor_id = "2563";
            store.stor_name = "bokkss";
            store.stor_address = "here";
            store.city = "Tustin";
            store.state = "CA";
            store.zip = "92789";
            _entities.stores.Add(store);
            _entities.SaveChanges();
            Console.WriteLine("Store Added");
        }
        void EditStore()
        {
            store store = _entities.stores.FirstOrDefault(s => s.stor_id == "2563");
            if (store == null)
            {
                Console.WriteLine("No such store");
                return;
            }
            else
            {
                store.stor_name = "XYZ";
                _entities.SaveChanges();
                Console.WriteLine("Store updated");
            }
        }
        void RemoveStore()
        {
            store store = _entities.stores.FirstOrDefault(s => s.stor_id == "2563");
            if (store == null)
            {
                Console.WriteLine("No such store");
                return;
            }
            else
            {
                _entities.stores.Remove(store);
                _entities.SaveChanges();
                Console.WriteLine("Store Deleted");
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.PrintAuthors();
            //p.PrintStore();
            //p.InsertStore();
            p.PrintStore();
            //p.EditStore();
            //p.RemoveStore();
            //p.PrintStore();

            Console.ReadLine();
        }
    }
}
