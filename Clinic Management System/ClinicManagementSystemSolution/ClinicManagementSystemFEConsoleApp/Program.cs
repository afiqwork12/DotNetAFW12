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
        static List<User> users;
        static void ManageAppointmentsPatientSide()
        {
            int choice;
            ManageAppointments appointments = new ManageAppointments(currentUser, users);
            do
            {
                Console.WriteLine("Choose from the options");
                Console.WriteLine("1: View Upcoming Appointments");
                Console.WriteLine("2: View Past Appointment");
                Console.WriteLine("3: Pay for Appointments");
                Console.WriteLine("4: Make an Appointment");
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
                        appointments.PayForAppointment();
                        break;
                    case 4:
                        appointments.MakeAppointment();
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
        static void ManageAppointmentsDoctorSide()
        {
            int choice;
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
            Console.WriteLine("Welcome to the Clinic");
            ManageUsers manageUsers = new ManageUsers();
            currentUser = manageUsers.LoginUser();
            users = manageUsers.users;
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
