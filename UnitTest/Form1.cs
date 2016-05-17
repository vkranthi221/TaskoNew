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
using UnitTest.ServiceReference1;

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

        private void button2_Click(object sender, EventArgs e)
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();

            EndpointAddress myEndpoint = new EndpointAddress("http://localhost/TAsko/authenticationservice.svc/basic");

            ChannelFactory<ServiceReference1.IAuthenticationService> myChannelFactory = new ChannelFactory<ServiceReference1.IAuthenticationService>(myBinding, myEndpoint);

            ServiceReference1.IAuthenticationService client1 = myChannelFactory.CreateChannel();
            Response response = client1.Login("srikanth", "password", "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();

            EndpointAddress myEndpoint = new EndpointAddress("http://localhost/TAsko/authenticationservice.svc/basic");

            ChannelFactory<ServiceReference1.IAuthenticationService> myChannelFactory = new ChannelFactory<ServiceReference1.IAuthenticationService>(myBinding, myEndpoint);

            ServiceReference1.IAuthenticationService client1 = myChannelFactory.CreateChannel();
            Response response = client1.Logout("ACD1F25ED458234F81FA45ED171519D0", "1F96377579E30F4AB3FB49092B4DADF2");
            
        }
    }
}
