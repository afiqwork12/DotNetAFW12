using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystemModelsLibrary
{
    public class Appointment : IComparable
    {
        private int id;
        private int patientID;
        private int doctorID;
        private string details;
        private DateTime date;
        private string status;
        private double price;

        public int Id { get => id; set => id = value; }
        public int PatientID { get => patientID; set => patientID = value; }
        public int DoctorID { get => doctorID; set => doctorID = value; }
        public string Details { get => details; set => details = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Status { get => status; set => status = value; }
        public double Price { get => price; set => price = value; }

        public Appointment()
        {
            status = "Open";
        }
        public override string ToString()
        {
            return
                "Appointment ID: " + id +
                "\nPatient ID: " + patientID +
                "\nDoctor ID: " + doctorID +
                "\nDetails ID: " + details +
                "\nDate: " + date +
                "\nPrice: $" + price +
                "\n";
        }
        public void TakeDetails()
        {
            Console.WriteLine("Enter Patient ID:");
            patientID = GetIntInput();
            Console.WriteLine("Enter Doctor ID:");
            doctorID = GetIntInput();
            Console.WriteLine("Enter Details:");
            details = Console.ReadLine();
            Console.WriteLine("Enter Price:");
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid Value. Try again.");
            }
            Console.WriteLine("Enter Date (e.g. dd/MM/yyyy):");
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", new CultureInfo("pt-BR"), DateTimeStyles.None, out date))
            {
                Console.WriteLine("Invalid Value. Try again.");
            }
        }

        private static int GetIntInput()
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid Value. Try again.");
            }
            return input;
        }

        public int CompareTo(object obj)
        {
            return date.CompareTo(((Appointment)obj).date);
        }
    }
}
