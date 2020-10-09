using System;
using System.Drawing;
using System.Windows.Forms;

namespace gei1076_tools
{
    public partial class SerialPortConfigurator: UserControl
    {
        SerialPortViewModel ps;

        public SerialPortConfigurator()
        {
            InitializeComponent();
            

            ps = new SerialPortViewModel();

            cboSerialPortList.Items.Clear();
            String[] Ports = System.IO.Ports.SerialPort.GetPortNames();
            cboSerialPortList.Items.AddRange(Ports);

            btnSerialPortOpen.Enabled = cboSerialPortList.SelectedItem != null;
            setStateLabelColor();

            btnTest.DataBindings.Add(new Binding("Enabled", ps, "Ouvert"));
            btnSerialPortClose.DataBindings.Add(new Binding("Enabled", ps, "Ouvert"));
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ps.Close();

            OnHandleDestroyed(new EventArgs());
        }

        private void btnSerialPortOpen_Click(object sender, EventArgs e)
        {
            if (cboSerialPortList.SelectedItem != null)
            {
                ps.Open(cboSerialPortList.SelectedItem.ToString(), int.Parse( cboSerialPortSpeed.SelectedItem.ToString()));
                setStateLabelColor();
            }
        }

        public SerialPortViewModel getPS()
        {
            return ps;
        }

        public Control[] getControlByName(string name)
        {
            if (name == "") return null;

            return Controls.Find(name, true);
        }

        private void setStateLabelColor()
        {
            if (ps.Opened)
            {
                lblState.BackColor = Color.Green;
            }
            else
            {
                lblState.BackColor = Color.LightGray;
            }
        }

        private void btnSerialPortClose_Click(object sender, EventArgs e)
        {
            ps.Close();
            setStateLabelColor();
        }

        private void cboSerialPortList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSerialPortList.SelectedItem == null)
            {
                btnSerialPortOpen.Enabled = false;
            }
            else
            {
                btnSerialPortOpen.Enabled = true;
            }

            ps.Close();
            setStateLabelColor();
        }

        private void SerialPortConfigurator_Load(object sender, EventArgs e)
        {
            this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            ps.WriteByte(0);
        }
    }
}
