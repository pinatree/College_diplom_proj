using System;
using System.Windows.Forms;
using System.ServiceModel;
using System.Configuration;
using bzgd_dr.WCF;

namespace TestDepartament_DataBase_Server
{
    public partial class MainWindow : Form
    {
        ServiceHost serviceHost;

		NetTcpBinding httpBinding;

        public MainWindow()
        {
            InitializeComponent();

            KeyValueConfigurationCollection res = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings;

            port_TB.Text = res["default_port"].Value;
        }

        public void StartServer(object sender, EventArgs e)
        {
            if (port_TB.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Empty value of port. Error.");
                return;
            }

            try
            {
				//Uri addr = new Uri("tcp://localhost:" + port_TB.Text.Replace(" ", ""));
				Uri addr = new Uri("net.tcp://0.0.0.0:" + port_TB.Text.Replace(" ", ""));
				serviceHost = new ServiceHost(typeof(ServerContract), addr);

                httpBinding = new NetTcpBinding();
				httpBinding.Security.Mode = SecurityMode.None;
                httpBinding.MaxReceivedMessageSize = int.MaxValue;
                System.Xml.XmlDictionaryReaderQuotas quotas = new System.Xml.XmlDictionaryReaderQuotas() { MaxArrayLength = int.MaxValue };
                httpBinding.ReaderQuotas = quotas;


                serviceHost.AddServiceEndpoint(typeof(IContract), httpBinding, addr);

                serviceHost.Open();

                Status_TB.Text = "Server is working";

                port_TB.Enabled = true;

                LogLB.Items.Add(DateTime.Now.ToUniversalTime().ToString() + " Server started");

                button1.Enabled = false;
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void StopServer(object sender, EventArgs e)
        {
            try
            {
                serviceHost.Close();

                Status_TB.Text = "Server is stoped";

                port_TB.Enabled = false;

                LogLB.Items.Add(DateTime.Now.ToUniversalTime().ToString() + " Server stoped");

                button1.Enabled = true;
                button2.Enabled = false;
            }
            catch (Exception ex)
            {
                LogLB.Items.Add(ex.Message);
            }
        }

        private void Save_port_Click(object sender, EventArgs e)
        {
            if (port_TB.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Empty value of port. Error.");
                return;
            }

            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            conf.AppSettings.Settings["default_port"].Value = port_TB.Text.Replace(" ", "");
            conf.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection(conf.AppSettings.SectionInformation.Name);

        }
    }
}