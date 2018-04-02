using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net;
using System.Configuration;

namespace modPro
{
    public partial class ConnectView : UserControl
    {
        ModMaster _master;

        public ConnectView(ModMaster master)
        {
            InitializeComponent();
            FillRTUDropDownLists();
            LoadUserData();
            this._master = master;
        }

        private void BaseFormClosing(object sender, FormClosingEventArgs e)
        {
            SaveUserData();
        }

        private void FillRTUDropDownLists()
        {
            comboBoxSerialPorts.Items.Clear();
            foreach (var port in SerialPort.GetPortNames())
            {
                comboBoxSerialPorts.Items.Add(port);
            }
            if (comboBoxSerialPorts.Items.Count > 0)
                comboBoxSerialPorts.SelectedIndex = 0;
            comboBoxParity.Items.Clear();
            comboBoxParity.Items.Add(Parity.None.ToString());
            comboBoxParity.Items.Add(Parity.Odd.ToString());
            comboBoxParity.Items.Add(Parity.Even.ToString());
            comboBoxParity.Items.Add(Parity.Mark.ToString());
            comboBoxParity.Items.Add(Parity.Space.ToString());
        }

        private void LoadUserData()
        {
            if (Enum.TryParse(ConfigurationManager.AppSettings["CommunicationMode"], out CommunicationMode mode))
                CommunicationMode = mode;
            if (IPAddress.TryParse(ConfigurationManager.AppSettings["IPAddress"], out IPAddress ipAddress))
                IPAddress = ipAddress;

            if (int.TryParse(ConfigurationManager.AppSettings["TCPPort"], out int port))
                TCPPort = port;

            PortName = ConfigurationManager.AppSettings["PortName"];
            if (int.TryParse(ConfigurationManager.AppSettings["Baud"], out int baud))
                Baud = baud;

            switch (ConfigurationManager.AppSettings["Parity"])
            {
                case "None":
                    Parity=Parity.None;
                    break;
                case "Odd":
                    Parity = Parity.Odd;
                    break;
                case "Even":
                    Parity = Parity.Even;
                    break;
                default:
                    Parity = Parity.None;
                    break;
            }
            if (byte.TryParse(ConfigurationManager.AppSettings["SlaveId"], out byte slaveId))
                SlaveId = slaveId;
            if (int.TryParse(ConfigurationManager.AppSettings["DataBits"], out int dataBits))
                DataBits = dataBits;

            switch (ConfigurationManager.AppSettings["StopBits"])
            {
                case "One":
                    StopBits = StopBits.One;
                    break;
                case "Two":
                    StopBits = StopBits.Two;
                    break;
                case "None":
                    StopBits = StopBits.None;
                    break;
                default:
                    StopBits = StopBits.None;
                    break;
            }
        }

        public void SaveUserData()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["CommunicationMode"].Value = CommunicationMode.ToString();
            config.AppSettings.Settings["IPAddress"].Value = IPAddress.ToString();
            config.AppSettings.Settings["TCPPort"].Value = TCPPort.ToString();
            config.AppSettings.Settings["PortName"].Value = PortName.ToString();
            config.AppSettings.Settings["Baud"].Value = Baud.ToString();
            config.AppSettings.Settings["Parity"].Value = Parity.ToString();
            config.AppSettings.Settings["SlaveId"].Value = SlaveId.ToString();
            config.AppSettings.Settings["DataBits"].Value = DataBits.ToString();
            config.AppSettings.Settings["StopBits"].Value = StopBits.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");


            //Properties.Settings.Default.CommunicationMode = CommunicationMode.ToString();
            //Properties.Settings.Default.IPAddress = IPAddress.ToString();
            //Properties.Settings.Default.DisplayFormat = DisplayFormat.ToString();
            //Properties.Settings.Default.TCPPort = TCPPort;
            //Properties.Settings.Default.PortName = PortName;
            //Properties.Settings.Default.Baud = Baud;
            //Properties.Settings.Default.Parity = Parity;
            //Properties.Settings.Default.StartAddress = StartAddress;
            //Properties.Settings.Default.DataLength = DataLength;
            //Properties.Settings.Default.SlaveId = SlaveId;
            //Properties.Settings.Default.SlaveDelay = SlaveDelay;
            //Properties.Settings.Default.DataBits = DataBits;
            //Properties.Settings.Default.StopBits = StopBits;
            //Properties.Settings.Default.Save();
        }

        #region properties
        protected IPAddress IPAddress
        {
            get
            {
                return IPAddress.Parse(txtIP.Text);
            }
            set
            {
                txtIP.Text = value.ToString();
            }
        }

        protected int TCPPort
        {
            get
            {
                return Int32.Parse(textBoxPort.Text);
            }
            set
            {
                textBoxPort.Text = Convert.ToString(value);

            }
        }

        protected byte SlaveId
        {
            get
            {
                return Byte.Parse(textBoxSlaveID.Text);
            }
            set
            {
                textBoxSlaveID.Text = Convert.ToString(value);
            }
        }

        protected string PortName
        {
            get
            {
                return comboBoxSerialPorts.Text;
            }
            set
            {
                comboBoxSerialPorts.Text = value;
            }
        }

        protected int Baud
        {
            get
            {
                return Int32.Parse(comboBoxBaudRate.Text);
            }
            set
            {
                comboBoxBaudRate.SelectedItem = Convert.ToString(value);
            }
        }

        protected Parity Parity
        {
            get
            {
                var parity = Parity.None;
                if (comboBoxParity.SelectedItem.Equals(Parity.None.ToString()))
                {
                    parity = Parity.None;
                }
                else if (comboBoxParity.SelectedItem.Equals(Parity.Odd.ToString()))
                {
                    parity = Parity.Odd;
                }
                else if (comboBoxParity.SelectedItem.Equals(Parity.Even.ToString()))
                {
                    parity = Parity.Even;
                }
                else if (comboBoxParity.SelectedItem.Equals(Parity.Mark.ToString()))
                {
                    parity = Parity.Mark;
                }
                else if (comboBoxParity.SelectedItem.Equals(Parity.Space.ToString()))
                {
                    parity = Parity.Space;
                }
                return parity;
            }
            set
            {
                comboBoxParity.SelectedItem = Convert.ToString(value);
            }
        }

        protected int DataBits
        {
            get
            {
                int bits = 0;
                switch (comboBoxDataBits.SelectedIndex)
                {
                    case 0:
                        bits = 7;
                        break;
                    case 1:
                        bits = 8;
                        break;
                }
                return bits;
            }
            set
            {
                switch (value)
                {
                    case 7:
                        comboBoxDataBits.SelectedIndex = 0;
                        break;
                    case 8:
                        comboBoxDataBits.SelectedIndex = 1;
                        break;
                }
            }
        }

        protected StopBits StopBits
        {
            get
            {
                StopBits bits = StopBits.None;
                switch (comboBoxStopBits.SelectedIndex)
                {
                    case 0:
                        bits = StopBits.None;
                        break;
                    case 1:
                        bits = StopBits.One;
                        break;
                    case 2:
                        bits = StopBits.Two;
                        break;
                }
                return bits;
            }
            set
            {
                switch (value)
                {
                    case StopBits.None:
                        comboBoxStopBits.SelectedIndex = 0;
                        break;
                    case StopBits.One:
                        comboBoxStopBits.SelectedIndex = 1;
                        break;
                    case StopBits.Two:
                        comboBoxStopBits.SelectedIndex = 2;
                        break;
                }
            }
        }

        private CommunicationMode _communicationMode = CommunicationMode.TCP;
        protected CommunicationMode CommunicationMode
        {
            get { return _communicationMode; }
            set
            {
                switch (value)
                {
                    case CommunicationMode.TCP:
                        radioButtonTCP.Checked = true;
                        break;
                    case CommunicationMode.UDP:
                        radioButtonUDP.Checked = true;
                        break;
                    case CommunicationMode.RTU:
                        radioButtonRTU.Checked = true;
                        break;
                }
                _communicationMode = value;
            }
        }

        #endregion





        private void btnConnect_Click(object sender, EventArgs e)
        {
            _master.ConnectRTU(PortName,Baud, Parity,DataBits, StopBits,SlaveId);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _master.Disconnect();
        }
    }
}
