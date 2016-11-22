using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Service
{
    public partial class TaskoUpdateService : ServiceBase
    {
        public TaskoUpdateService()
        {
            InitializeComponent();
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("Tasko Service Started");

            System.Timers.Timer timer = new System.Timers.Timer();
            TimeSpan timeSpanToMidnight = GetNextMidnight().Subtract(DateTime.Now);
            timer.Interval = timeSpanToMidnight.TotalMilliseconds;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();

            System.Timers.Timer timer2 = new System.Timers.Timer();
            timer2.Interval = 50000; // 60 seconds
            timer2.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer2);
            timer2.Start();
        }
        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            ////eventLog1.WriteEntry("Resetting the User Login's");
            using (SqlConnection connection = new SqlConnection(@"Data Source=WIN-P4AUDD5MBT2;Initial Catalog=Tasko_live;User ID=sa;password=Tasko@12345"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE ADDRESS SET LATITIUDE = '0', LONGITUDE = '0' WHERE ADDRESS_ID !=0xFC32A83A7791074B8072B68B652088E6", connection);
                command.ExecuteNonQuery();
            }
            ////eventLog1.WriteEntry("User Login's reset");
        }
        public void OnTimer2(object sender, System.Timers.ElapsedEventArgs args)
        {
            ////eventLog1.WriteEntry("Check Started for order status");
            using (SqlConnection connection = new SqlConnection(@"Data Source=WIN-P4AUDD5MBT2;Initial Catalog=Tasko_live;User ID=sa;password=Tasko@12345"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE [ORDER] SET ORDER_STATUS_ID = 7 WHERE REQUESTED_DATE <=DateADD(minute, -2, Current_TimeStamp) AND ORDER_STATUS_ID = 1", connection);
                command.ExecuteNonQuery();
            }
            ////eventLog1.WriteEntry("Order Status Updated to Missed(7)");
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("Tasko Service Stopped");
        }
        private static DateTime GetNextMidnight()
        {
            const string datePattern = "dd/MM/yyyy hh:mm:ss";
            const string dateFormat = "{0:00}/{1:00}/{2:0000} {3:00}:{4:00}:{5:00}";
            DateTime nextMidnight;

            string dateString = string.Format(dateFormat, DateTime.Now.Day + 1, DateTime.Now.Month, DateTime.Now.Year, 0, 0, 0);
            bool valid = DateTime.TryParseExact(dateString, datePattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out nextMidnight);

            if (!valid)
            {
                dateString = string.Format(dateFormat, 1, DateTime.Now.Month + 1, DateTime.Now.Year, 0, 0, 0);
                valid = DateTime.TryParseExact(dateString, datePattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out nextMidnight);
            }

            if (!valid)
            {
                dateString = string.Format(dateFormat, 1, 1, DateTime.Now.Year + 1, 0, 0, 0);
                DateTime.TryParseExact(dateString, datePattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out nextMidnight);
            }

            return nextMidnight;
        }
    }
}
