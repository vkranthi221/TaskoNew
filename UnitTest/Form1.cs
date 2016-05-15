using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();

            EndpointAddress myEndpoint = new EndpointAddress("http://localhost/TAsko/authenticationservice.svc/basic");

            ChannelFactory<ServiceReference1.IAuthenticationService> myChannelFactory = new ChannelFactory<ServiceReference1.IAuthenticationService>(myBinding, myEndpoint);

            ServiceReference1.IAuthenticationService client1 = myChannelFactory.CreateChannel();
            client1.GetOrderDetails("1000");
            
        }
    }
}
