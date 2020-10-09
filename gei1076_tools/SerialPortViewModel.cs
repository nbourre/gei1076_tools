using System;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace gei1076_tools
{
    public class SerialPortViewModel : INotifyPropertyChanged
    {
        private SerialPort serialPort = null;
        private bool opened = false;

        byte[] buffer = new byte[8];

        public event PropertyChangedEventHandler PropertyChanged;

        public SerialPortViewModel() {
            serialPort = new SerialPort();
        }

        public bool Open(string portName = "COM1", int baudRate = 9600)
        {
            if (!opened)
            {
                try
                {
                    serialPort.PortName = portName;
                    serialPort.BaudRate = baudRate;
                    serialPort.DataBits = 8;
                    serialPort.Parity = Parity.None;
                    serialPort.StopBits = StopBits.One;
                    serialPort.Handshake = Handshake.None;

                    serialPort.Open();

                    serialPort.DiscardInBuffer();

                    opened = true;

                    OnPropertyChanged("Ouvert");
                    return true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Problème à l'ouverture du port " + portName + " à la vitesse de " + baudRate + "   " + error.Message, "ERREUR !!");
                }
            }

            return false;
        }

        public bool Close()
        {
            if (opened == false) return false;

            try
            {
                serialPort.Close();
                opened = false;
                OnPropertyChanged("Ouvert");
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
            if (opened == false) return false;

            bool result = false;

            try
            {
                buffer[0] = _byte;
                serialPort.Write(buffer, 0, 1);
                result = true;
            } catch (Exception e)
            {
                MessageBox.Show("Problème de connexion \n" + e.Message);
                serialPort.Dispose();
            }

            return result;
        }

        public bool WriteBytes(byte[] frame, int size)
        {
            if (opened == false) return false;

            bool result = false;

            try
            {
                serialPort.Write(frame, 0, size);
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
            if (opened == false) return false;

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
            if (opened == false) return 0;

            return this.serialPort.BytesToRead;

            
        }

        public bool ReadByte(ref byte octet)
        {
            if (opened == false) return false;

            try
            {
                octet = (byte)this.serialPort.ReadByte();
            } catch (Exception e)
            {
                MessageBox.Show("Problème de connexion \n" + e.Message);
                serialPort.Dispose();
            }


            return true;
        }

        public bool Opened
        {
            get
            {
                return opened;
            }
        }

        public int ReadBytes(byte[] byteArray, int offset, int count)
        {

            // Voir : http://stackoverflow.com/questions/21337123/read-and-store-bytes-from-serial-port
            if (!opened) return -1;

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


        // Permet de lever l'évément de changement de propriété
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



    }
}
