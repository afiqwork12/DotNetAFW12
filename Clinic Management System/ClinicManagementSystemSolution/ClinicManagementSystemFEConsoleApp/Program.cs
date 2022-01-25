using ClinicManagementSystemModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystemFEConsoleApp
{
    class Program
    {
        static User currentUser;
        static void ManageAppointments()
        {
            Console.WriteLine("Welcome to Appointment Management");
            int choice = 0;
            ManageAppointments appointments = new ManageAppointments();
            do
            {
                Console.WriteLine("1: Add Appointment");
                Console.WriteLine("2: Edit Appointment Price");
                Console.WriteLine("3: Remove Appointment");
                Console.WriteLine("4: Print Appointment Details");
                Console.WriteLine("5: Print all Appointment Details");
                Console.WriteLine("0: Exit");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a number");
                }
                switch (choice)
                {
                    case 1:
                        appointments.AddAppointments();
                        break;
                    case 2:
                        appointments.EditAppointmentPrice();
                        break;
                    case 3:
                        appointments.DeleteAppointment();
                        break;
                    case 4:
                        appointments.PrintAppointmentById();
                        break;
                    case 5:
                        appointments.PrintAllAppointments();
                        break;
                    case 0:
                        Console.WriteLine("Bye Bye");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != 0);
        }
        static void ManageAppointmentsPatientSide()
        {

        }
        static void ManageAppointmentsDoctorSide()
        {
            int choice = 0;
            ManageAppointments appointments = new ManageAppointments(currentUser);
            do
            {
                Console.WriteLine("Choose from the options");
                Console.WriteLine("1: View Upcoming Appointments");
                Console.WriteLine("2: View Past Appointment");
                Console.WriteLine("3: Raise Payment Request");
                Console.WriteLine("0: Exit");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a number");
                }
                switch (choice)
                {
                    case 1:
                        appointments.PrintUpcomingAppointments();
                        break;
                    case 2:
                        appointments.PrintPastAppointments();
                        break;
                    case 3:
                        appointments.RaisePayment();
                        break;
                    case 0:
                        Console.WriteLine("Bye Bye");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != 0);
        }
        static void Main(string[] args)
        {
            //ManageUsers manageUsers = new ManageUsers();
            //manageUsers.RegisterUsers();
            //manageUsers.DisplayUsers();
            //ManageAppointments();
            //appointments.AddAppointments();
            //appointments.PrintAllAppointments();
            Console.WriteLine("Welcome to the Clinic");
            ManageUsers manageUsers = new ManageUsers();
            currentUser = manageUsers.LoginUser();
            if (currentUser.Type == "Patient")
            {
                ManageAppointmentsPatientSide();
            }
            else
            {
                ManageAppointmentsDoctorSide();
            }
            Console.ReadLine();
        }
    }
}
