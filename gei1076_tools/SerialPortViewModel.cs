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
        private bool ouvert = false;

        byte[] tampon = new byte[8];

        public event PropertyChangedEventHandler PropertyChanged;

        public SerialPortViewModel() {
            serialPort = new SerialPort();
        }

        public bool Ouvrir(string nomPort = "COM1", int baudRate = 9600)
        {
            if (!ouvert)
            {
                try
                {
                    serialPort.PortName = nomPort;
                    serialPort.BaudRate = baudRate;
                    serialPort.DataBits = 8;
                    serialPort.Parity = Parity.None;
                    serialPort.StopBits = StopBits.One;
                    serialPort.Handshake = Handshake.None;

                    serialPort.Open();

                    serialPort.DiscardInBuffer();

                    ouvert = true;

                    OnPropertyChanged("Ouvert");
                    return true;
                }
                catch (Exception erreur)
                {
                    MessageBox.Show("Problème à l'ouverture du port " + nomPort + " à la vitesse de " + baudRate + "   " + erreur.Message, "ERREUR !!");
                }
            }

            return false;
        }

        public bool Fermer()
        {
            if (ouvert == false) return false;

            try
            {
                serialPort.Close();
                ouvert = false;
                OnPropertyChanged("Ouvert");
                return true;
            }
            catch (IOException erreur)
            {
                MessageBox.Show("Problème à la fermeture du port " + erreur.Message);
            }

            return false;
        }




        public bool EcrireOctet(byte octet)
        {
            if (ouvert == false) return false;

            bool result = false;

            try
            {
                tampon[0] = octet;
                serialPort.Write(tampon, 0, 1);
                result = true;
            } catch (Exception e)
            {
                MessageBox.Show("Problème de connexion \n" + e.Message);
                serialPort.Dispose();
            }

            return result;
        }

        public bool EcrireOctets(byte[] trame, int taille)
        {
            if (ouvert == false) return false;

            bool result = false;

            try
            {
                serialPort.Write(trame, 0, taille);
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Problème de connexion \n" + e.Message);
                serialPort.Dispose();
            }



            return result;
        }

        public bool EcrireLigne(string tampon)
        {
            if (ouvert == false) return false;

            bool result = false;

            try
            {
                serialPort.WriteLine(tampon);
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Problème de connexion \n" + e.Message);
                serialPort.Dispose();
            }
            

            return result;
        }

        public int DonneesALire()
        {
            if (ouvert == false) return 0;

            return this.serialPort.BytesToRead;

            
        }

        public bool LireOctet(ref byte octet)
        {
            if (ouvert == false) return false;

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

        public bool Ouvert
        {
            get
            {
                return ouvert;
            }
        }

        public int LireOctets(byte[] tableau, int decalage, int v)
        {

            // Voir : http://stackoverflow.com/questions/21337123/read-and-store-bytes-from-serial-port
            if (!ouvert) return -1;

            int result = 0;


            try
            {
                result = serialPort.Read(tableau, decalage, v);
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
