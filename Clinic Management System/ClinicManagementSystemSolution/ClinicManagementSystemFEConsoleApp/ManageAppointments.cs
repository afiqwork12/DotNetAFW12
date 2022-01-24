using ClinicManagementSystemModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystemFEConsoleApp
{
    public class ManageAppointments
    {
        List<Appointment> appointments = new List<Appointment>();
        public void AddAppointments()
        {
            Console.WriteLine("Number of Appointments to be created:");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input. Try again.");
            }
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("Creating Appointment " + (i + 1));
                Appointment appointment = new Appointment
                {
                    Id = 100 + i
                };
                appointment.TakeDetails();
            }
        }
        public void PrintAllAppointments()
        {
            for (int i = 0; i < appointments.Count; i++)
            {
                PrintAppointment(appointments[i]);
            }
        }
        public void PrintAppointment(Appointment appointment)
        {
            Console.WriteLine("************************");
            Console.WriteLine(appointment);
            Console.WriteLine("************************");
        }
        public Appointment GetAppointmentByID(int ID)
        {
            Appointment a = new Appointment();
            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointments[i].Id == ID)
                {
                    a = appointments[i];
                    break;
                }
            }
            return a;
        }
        public int GetIdFromUser()
        {
            Console.WriteLine("Please enter the appointment ID:");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            return id;
        }
        public void PrintAppointmentById()
        {
            Appointment a = GetAppointmentByID(GetIdFromUser());
            PrintAppointment(a);
        }
        public void EditAppointmentPrice()
        {
            Appointment a = GetAppointmentByID(GetIdFromUser());
            Console.WriteLine("Please enter new appointment price:");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointments[i].Id == a.Id)
                {
                    appointments[i].Price = price;
                    break;
                }
            }
            Console.WriteLine("New Appointment Details");
            PrintAppointment(a);
        }
    }
}
