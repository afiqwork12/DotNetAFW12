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
        List<User> users;
        User currentUser;
        public ManageAppointments()
        {
            GenerateAppointments();
        }
        public ManageAppointments(User user)
        {
            GenerateAppointments();
            currentUser = user;
        }
        public ManageAppointments(User user, List<User> users)
        {
            GenerateAppointments();
            currentUser = user;
            this.users = users;
        }
        public void MakeAppointment()
        {
            Console.WriteLine("Please enter a few details for your Appointment");
            Appointment newAppointment = new Appointment
            {
                Id = appointments.Count < 0 ? 1 : appointments.Max(x => x.Id) + 1
            };
            newAppointment.TakeDetails(currentUser, users.Where(u => u.Type == "Doctor").ToList());
            appointments.Add(newAppointment);
            Console.WriteLine("Appointment Made. Displaying Appointment Details.");
            PrintAppointment(newAppointment);
        }
        public void PayForAppointment()
        {
            Console.WriteLine("Please select an unpaid appointment");
            var temp = appointments.Where(x => x.PatientID == currentUser.Id && x.Date < DateTime.Now && x.Status == "Pending Payment").ToList();
            PrintAppointmentsFromList(temp);
            var check = true;
            Console.WriteLine("Please enter the appointment ID");
            int id;
            while (check)
            {
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
                if (temp.Find(x => x.Id == id) == null)
                {
                    Console.WriteLine("Please select from the above list.");
                }
                else
                {
                    check = false;
                    Appointment apt = appointments.SingleOrDefault(a => a.Id == id);
                    if (apt != null)
                    {
                        int index = appointments.IndexOf(apt);
                        if (index > 0)
                        {
                            
                            appointments[index].Status = "Paid";
                            Console.WriteLine("Payment Updated. Displaying Appointment Details");
                            PrintAppointment(appointments[index]);
                        }
                        else
                        {
                            Console.WriteLine("Opps");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opps");
                    }
                }
            }
        }
        public void RaisePayment()
        {
            Console.WriteLine("Please select an appointment for raising payment request");
            var temp = appointments.Where(x => x.DoctorID == currentUser.Id && x.Date < DateTime.Now && x.Status == "Opened").ToList();
            PrintAppointmentsFromList(temp);
            Console.WriteLine("Please enter the appointment ID");
            int id;
            var check = true;
            while (check)
            {
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
                if (temp.Find(x => x.Id == id) == null)
                {
                    Console.WriteLine("Please select from the above list.");
                }
                else
                {
                    check = false;
                    Console.WriteLine("Please enter any message to be saved");
                    string details = Console.ReadLine();
                    Console.WriteLine("Please enter amount to be collected");
                    double price;
                    while (!double.TryParse(Console.ReadLine(), out price))
                    {
                        Console.WriteLine("Invalid input. Try again.");
                    }
                    for (int i = 0; i < appointments.Count; i++)
                    {
                        if (id == appointments[i].Id)
                        {
                            appointments[i].Details = details;
                            appointments[i].Price = price;
                            appointments[i].Status = (price == 0 ? "Paid" : "Pending Payment");
                            Console.WriteLine("Payment Raised. Displaying Appointment Details.");
                            PrintAppointment(appointments[i]);
                            break;
                        }
                    }
                }
            }
            
            //while (!int.TryParse(Console.ReadLine(), out id))
            //{
            //    Console.WriteLine("Invalid input. Try again.");
            //}
            //if (temp.Find(x => x.Id == id) != null)
            //{
            //    Console.WriteLine("Please enter any message to be saved");
            //    string details = Console.ReadLine();
            //    Console.WriteLine("Please enter amount to be collected");
            //    double price;
            //    while (!double.TryParse(Console.ReadLine(), out price))
            //    {
            //        Console.WriteLine("Invalid input. Try again.");
            //    }
            //    for (int i = 0; i < appointments.Count; i++)
            //    {
            //        if (id == appointments[i].Id)
            //        {
            //            appointments[i].Details = details;
            //            appointments[i].Price = price;
            //            appointments[i].Status = "Pending Payment";
            //            Console.WriteLine("Updated");
            //            PrintAppointment(appointments[i]);
            //            break;
            //        }
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Please select the appointments from the list");
            //}
        }

        private void PrintAppointmentsFromList(List<Appointment> temp)
        {
            foreach (var item in temp)
            {
                PrintAppointment(item);
            }
        }

        public void GenerateAppointments()
        {
            appointments.Add(new Appointment() { Id = 1, PatientID = 101, DoctorID = 201, Details = "aaaa", Date = new DateTime(2022,2,16,14,20,0), Price = -1, Status = "Opened"});
            appointments.Add(new Appointment() { Id = 2, PatientID = 101, DoctorID = 201, Details = "aaaa2", Date = new DateTime(2022,1,20,12,20,0), Price = -1, Status = "Opened" });
            appointments.Add(new Appointment() { Id = 3, PatientID = 101, DoctorID = 201, Details = "aaaa3", Date = new DateTime(2022,1,10,14,35,0), Price = 444.36, Status = "Pending Payment" });
            appointments.Add(new Appointment() { Id = 4, PatientID = 101, DoctorID = 201, Details = "aaaa4", Date = new DateTime(2022,1,11,14,35,0), Price = 52.2, Status = "Pending Payment" });
            appointments.Add(new Appointment() { Id = 5, PatientID = 101, DoctorID = 201, Details = "aaaa5", Date = new DateTime(2022,1,12,14,35,0), Price = 62.2, Status = "Paid" });
            appointments.Add(new Appointment() { Id = 6, PatientID = 102, DoctorID = 201, Details = "bbbb", Date = new DateTime(2021,12,15,11,30,0), Price = 20.0, Status = "Paid"});
            appointments.Add(new Appointment() { Id = 7, PatientID = 102, DoctorID = 201, Details = "cccc", Date = new DateTime(2020,5,4,13,25,0), Price = 123.6, Status = "Paid" });
        }
        public void PrintUpcomingAppointments()
        {
            List<Appointment> temp;
            Console.WriteLine("Displaying Upcoming Appointments");
            if (currentUser.Type == "Patient")
            {
                temp = appointments.Where(x => x.PatientID == currentUser.Id && x.Date >= DateTime.Now).ToList();
            }
            else
            {
                temp = appointments.Where(x => x.DoctorID == currentUser.Id && x.Date >= DateTime.Now).ToList();
            }
            PrintAppointmentsFromList(temp);
        }
        public void PrintPastAppointments()
        {
            List<Appointment> temp;
            Console.WriteLine("Displaying Past Appointments");
            if (currentUser.Type == "Patient")
            {
                temp = appointments.Where(x => x.PatientID == currentUser.Id && x.Date < DateTime.Now).ToList();
            }
            else
            {
                temp = appointments.Where(x => x.DoctorID == currentUser.Id && x.Date < DateTime.Now).ToList();
            }
            PrintAppointmentsFromList(temp);
        }
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
                    Id = appointments.Count < 0 ? 1 : appointments.Max(x => x.Id) + 1
                };
                appointment.TakeDetails();
                appointments.Add(appointment);
            }
            appointments.Sort();
        }
        public void PrintAllAppointments()
        {
            if (appointments.Count > 0)
            {
                for (int i = 0; i < appointments.Count; i++)
                {
                    PrintAppointment(appointments[i]);
                }
            }
            else
            {
                Console.WriteLine("No Appointments created yet");
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
            //for (int i = 0; i < appointments.Count; i++)
            //{
            //    if (appointments[i].Id == ID)
            //    {
            //        return appointments[i];
            //    }
            //}
            return appointments.Find(a => a.Id == ID);
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
            if (a != null)
            {
                PrintAppointment(a);
            }
            else
            {
                Console.WriteLine("No such appointment created.");
            }
        }
        public void EditAppointmentPrice()
        {
            Appointment a = GetAppointmentByID(GetIdFromUser());
            if (a != null)
            {
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
            else
            {
                Console.WriteLine("No such appointment created.");
            }
        }
        public void DeleteAppointment()
        {
            Appointment a = GetAppointmentByID(GetIdFromUser());
            if (a != null)
            {
                Console.WriteLine("Do you want to delete the following Appointment?");
                PrintAppointment(a);
                string check = Console.ReadLine();
                if (check == "Yes")
                {
                    var remove = appointments.Single(r => r.Id == a.Id);
                    appointments.Remove(remove);
                    Console.WriteLine("New Appointment List");
                    PrintAllAppointments();
                }
            }
            else
            {
                Console.WriteLine("No such appointment created.");
            }
        }
    }
}
