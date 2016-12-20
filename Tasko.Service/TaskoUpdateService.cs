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
using Tasko.Model;
using Tasko.Repository;
using Tasko.Services;

namespace Tasko.Service
{
    public partial class TaskoUpdateService : ServiceBase
    {
        public TaskoUpdateService(string[] args)
        {
            InitializeComponent();
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource("MySource", "MyNewLog");
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
            //// Reset all logins longitude and lattitude to 0.
            VendorData.ResetAllLogins();
        }

        public void OnTimer2(object sender, System.Timers.ElapsedEventArgs args)
        {
            List<OrderSummary> pendingOrders = VendorData.GetAllPendingOrders();
            VendorAppService service = new VendorAppService();

            foreach (OrderSummary orderSummary in pendingOrders)
            {
                short orderStatusId = (short)Tasko.Common.TaskoEnum.OrderStatus.OrderMissed;
                service.UpdateOrderStatus(orderSummary.OrderId, orderStatusId, "Vendor missed the Order");
            }
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
