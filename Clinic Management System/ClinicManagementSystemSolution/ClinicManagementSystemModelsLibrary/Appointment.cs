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
        private string status;//Open, Pending Payment, Paid, Closed
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
            status = "Opened";
        }
        public override string ToString()
        {
            return
                "Appointment ID: " + id +
                "\nPatient ID: " + patientID +
                "\nDoctor ID: " + doctorID +
                "\nPatient Notes: " + details +
                "\nDate: " + date.ToString("dd/MM/yyyy") +
                "\nTime: " + date.ToString("hh:mm tt") +
                "\nPrice: " + (price < 0.0 ? "To be decided": "$" + price) +
                "\nStatus: " + status;
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
            Console.WriteLine("Enter Date (e.g. dd/MM/yyyy hh:mm AM/PM):");
            var check = true;
            while (check)
            {
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null, DateTimeStyles.None, out date))
                {
                    Console.WriteLine("Invalid Value. Try again.");
                }
                if (date < DateTime.Now)
                {
                    Console.WriteLine("Please enter a date after today.");
                }
                else
                {
                    check = false;
                }
            }
            
            Console.WriteLine("Enter Status:");
            status = Console.ReadLine();
        }
        public void TakeDetails(User user, List<User> listOfDoctors, List<Appointment> appointments)
        {
            patientID = user.Id;
            Console.WriteLine("Please select from the list of doctors below");
            foreach (var item in listOfDoctors)
            {
                Console.WriteLine("************************");
                Console.WriteLine("ID: " + item.Id + "\nName: " + item.Name + "\nSpeciality: " + ((Doctor)item).Speciality + "\nYears of Experience: " + ((Doctor)item).Experience);
                Console.WriteLine("************************");
            }
            Console.WriteLine("Enter Doctor ID:");
            var check = true;
            while (check)
            {
                doctorID = GetIntInput();
                if (listOfDoctors.SingleOrDefault(d => d.Id == doctorID) == null)
                {
                    Console.WriteLine("Please select from the list of doctors above");
                }
                else
                {
                    check = false;
                }
            }
            Console.WriteLine("Enter Appointment Details:");
            details = Console.ReadLine();
            price = -1;
            Console.WriteLine("Enter Date (e.g. dd/MM/yyyy):");
            check = true;
            DateTime appDate = DateTime.Now.AddDays(-1.0);
            while (check)
            {
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, DateTimeStyles.None, out appDate))
                {
                    Console.WriteLine("Invalid Value. Try again.");
                }
                if (appDate < DateTime.Now)
                {
                    Console.WriteLine("Please enter a date after today.");
                }
                else
                {
                    check = false;
                }
            }
            var docApp = appointments.Where(x => x.doctorID == doctorID && x.date.Date == appDate.Date).ToList();
            //if (docApp.Count > 0)
            //{
            //    DateTime chosenTimeslot = GetTimeSlot(appDate, docApp);
            //    date = chosenTimeslot;
            //}
            //else
            //{
            //    Console.WriteLine("Select a timeslot");
            //    Console.ReadLine();
            //}
            DateTime chosenTimeslot = GetTimeSlot(appDate, docApp);
            date = chosenTimeslot;
            status = "Opened";
        }

        private static DateTime GetTimeSlot(DateTime appDate, List<Appointment> docApp)
        {
            Console.WriteLine("Select a timeslot (choose from the numbers listed e.g. 1 or 2):");
            List<DateTime> timeslots = new List<DateTime>();
            for (int i = 9; i <= 17; i++)
            {
                string hour = (i > 12 ? i - 12 : i).ToString("D2") + ":00:00";
                //Console.WriteLine(dsadsa.ToString("dd/MM/yyyy") + " " + hour + (i < 12 ? " AM" : " PM"));
                timeslots.Add(DateTime.ParseExact(appDate.ToString("dd/MM/yyyy") + " " + hour + (i < 12 ? " AM" : " PM"), "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture));
            }
            timeslots = timeslots.Where(x => !docApp.Select(y => y.date).Contains(x)).ToList();
            int count = 0;
            foreach (var item in timeslots)
            {
                Console.WriteLine(count + " - " + item.ToString("hh:mm:ss tt"));
                count++;
            }
            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Please select from timeslot above");
            }
            var chosenTimeslot = timeslots[option];
            return chosenTimeslot;
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
