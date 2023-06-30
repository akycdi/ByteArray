using System;
using System.IO.Ports;
using System.Threading;

namespace ByteArray
{
    class Program
    {
        static void Main()
        {
            SerialPort serialPort = new SerialPort("COM11", 230400);
            byte[] dataToSend = new byte[18];
            int[] pwmValues = new int[16];
            Random random = new Random();

            while (true)
            {
                for (int i = 0; i < 16; i++)
                {
                    pwmValues[i] = random.Next(256);
                    dataToSend[i + 1] = (byte)pwmValues[i];
                }

                dataToSend[0] = (byte)'{'; // Start delimiter
                dataToSend[17] = (byte)'}'; // End delimiter

                serialPort.Open(); 
                serialPort.Write(dataToSend, 0, dataToSend.Length);
                serialPort.Close(); //System crashing so keep the com port close


                Console.WriteLine("Data sent: " + string.Join(", ", pwmValues));
                Thread.Sleep(1); 
            }
        }
    }
}
