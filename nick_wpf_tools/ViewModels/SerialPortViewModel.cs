using nick_wpf_tools.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace nick_wpf_tools.ViewModels
{
    public class SerialPortViewModel : BaseViewModel
    {
        private SerialPort serialPort = null;
        private bool isOpen = false;

        byte[] buffer = new byte[8];

        private ObservableCollection<string> comPorts;

        public ObservableCollection<string> ComPorts
        {
            get { return comPorts; }
            set {
                comPorts = value;
                OnPropertyChanged();
            }
        }

        private string selectedComPort;

        public string SelectedComPort
        {
            get { return selectedComPort; }
            set { 
                selectedComPort = value;
                OnPropertyChanged();
            }
        }

        private string selectedBaudRate;

        public string SelectedBaudRate
        {
            get { 
                return selectedBaudRate; 
            }
            set { 
                selectedBaudRate = value;
                OnPropertyChanged();
            }
        }



        public List<string> BaudRates { get; set; }

        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
            private set
            {
                isOpen = value;
                OnPropertyChanged();
                ClosePortCommand.RaiseCanExecuteChanged();
                TestPortCommand.RaiseCanExecuteChanged();
            }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { 
                status = value;
                OnPropertyChanged();
            }
        }

        private string receivedData;

        public string ReceivedData
        {
            get { return receivedData; }
            set { 
                receivedData = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand<string> LoadedCommand { get; set; }
        public DelegateCommand<string> OpenPortCommand { get; set; }
        public DelegateCommand<string> ClosePortCommand { get; set; }
        public DelegateCommand<string> TestPortCommand { get; set; }
        public DelegateCommand<string> ClearReceivedDataCommand { get; set; }

        public SerialPortViewModel()
        {
            initValues();
            
            initCommands();
        }

        private void initValues()
        {
            serialPort = new SerialPort();
            BaudRates = new List<string> { "110", " 300", " 600", " 1200", " 2400", " 4800", " 9600", " 14400", " 19200", " 38400", " 57600", " 115200", " 128000", "256000" };
            SelectedBaudRate = "9600";
            Status = "Closed";
            
        }

        private void initCommands()
        {
            LoadedCommand = new DelegateCommand<string>(GetAvailableComm);
            OpenPortCommand = new DelegateCommand<string>(OpenPort);
            ClosePortCommand = new DelegateCommand<string>(ClosePort, CanClosePort);
            TestPortCommand = new DelegateCommand<string>(TestPort, CanTestPort);
            ClearReceivedDataCommand = new DelegateCommand<string>(ClearReceivedData);
        }

        private void ClearReceivedData(string obj)
        {
            ReceivedData = string.Empty;
        }

        private bool CanTestPort(string obj)
        {
            return IsOpen;
        }

        private bool CanClosePort(string obj)
        {
            return IsOpen;
        }

        private async void TestPort(string obj)
        {
            Debug.WriteLine("Test command executed. Not implemented!");

            await Task.Run(() => 
                Debug.WriteLine("Task running")
                // Do some code here
            );
        }

        private void ClosePort(string obj)
        {
            if (Close())
            {
                Status = "Closed";
            } else
            {
                Status = "Error";
            }
        }

        private async void OpenPort(string obj)
        {
            if (await Open(SelectedComPort, int.Parse(SelectedBaudRate)))
            {
                Status = "OPEN";
            } else
            {
                Status = "Error";
            }
        }

        /// <summary>
        /// Returns the available ports on the host
        /// </summary>
        /// <param name="obj"></param>
        private async void GetAvailableComm(string obj)
        {
            ComPorts = new ObservableCollection<string>(await Task.Run(()=> SerialPort.GetPortNames()));
        }

        public async Task<bool> Open(string portName = "COM1", int baudRate = 9600)
        {
            if (!IsOpen)
            {
                try
                {
                    serialPort.PortName = portName;
                    serialPort.BaudRate = baudRate;
                    serialPort.DataBits = 8;
                    serialPort.Parity = Parity.None;
                    serialPort.StopBits = StopBits.One;
                    serialPort.Handshake = Handshake.None;
                    serialPort.DataReceived += SerialPort_DataReceived;

                    Status = "Opening...";
                    
                    var task = Task.Run(() =>
                    {
                        try
                        {
                            serialPort.Open();
                        }
                        catch (Exception e)
                        {
                            /// Bypass the task error handling...
                            /// Must have a better way
                            /// But for now the job is ok
                        }
                    }
                    );

                    await task;
                    
                    serialPort.DiscardInBuffer();

                    IsOpen = true;
                    return true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Problème à l'ouverture du port " + portName + " à la vitesse de " + baudRate + "   " + error.Message, "ERREUR !!");
                }
            }

            return false;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] data = new byte[serialPort.BytesToRead];
            ReadBytes(data, 0, data.Length);
            ReceivedData += Encoding.GetEncoding("UTF-8").GetString(data) + Environment.NewLine;
        }

        public bool Close()
        {
            if (!IsOpen) return false;

            try
            {
                serialPort.DataReceived -= SerialPort_DataReceived;
                serialPort.Close();
                IsOpen = false;
                return true;
            }
            catch (IOException erreur)
            {
                MessageBox.Show("Problème à la fermeture du port " + erreur.Message);
            }

            return false;
        }




        public bool WriteByte(byte _byte)
        {
            if (IsOpen == false) return false;

            bool result = false;

            try
            {

                buffer[0] = _byte;
                serialPort.Write(buffer, 0, 1);
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Problème de connexion \n" + e.Message);
                serialPort.Dispose();
            }

            return result;
        }

        public bool WriteBytes(byte[] frame)
        {
            if (IsOpen == false) return false;

            bool result = false;

            try
            {
                serialPort.Write(frame, 0, frame.Length);
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Problème de connexion \n" + e.Message);
                serialPort.Dispose();
            }

            return result;
        }

        public bool WriteLine(string buffer)
        {
            if (IsOpen == false) return false;

            bool result = false;

            try
            {
                serialPort.WriteLine(buffer);
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Problème de connexion \n" + e.Message);
                serialPort.Dispose();
            }


            return result;
        }

        public int DataToRead()
        {
            if (IsOpen == false) return 0;

            return serialPort.BytesToRead;


        }

        public bool ReadByte(ref byte octet)
        {
            if (IsOpen == false) return false;

            try
            {
                octet = (byte)serialPort.ReadByte();
            }
            catch (Exception e)
            {
                MessageBox.Show("Problème de connexion \n" + e.Message);
                serialPort.Dispose();
            }

            return true;
        }


        public int ReadBytes(byte[] byteArray, int offset, int count)
        {

            // Voir : http://stackoverflow.com/questions/21337123/read-and-store-bytes-from-serial-port
            if (!IsOpen) return -1;

            int result = 0;


            try
            {
                result = serialPort.Read(byteArray, offset, count);
            }
            catch (Exception e)
            {
                MessageBox.Show("Problème de connexion \n" + e.Message);
                serialPort.Dispose();
            }

            return result;

        }





    }
}
