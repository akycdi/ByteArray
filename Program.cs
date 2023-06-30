using System.IO.Ports;

namespace ByteArray
{
    class Program
    {
        static void Main()
        {
            SerialPort serialPort = new SerialPort("COM11", 230400);
            byte[] dataToSend = new byte[16];
            int[] pwmValues = new int[16];
            Random random = new Random();

            while (true)
            {
                for (int i = 0; i < 16; i++)
                {
                    pwmValues[i] = random.Next(256);
                    dataToSend[i] = (byte)pwmValues[i];
                }

                serialPort.Open();
                serialPort.Write(dataToSend, 0, dataToSend.Length);
                serialPort.Close();

                Console.WriteLine("Data sent: " + string.Join(", ", pwmValues));
                Thread.Sleep(5000);
            }
        }
    }
}
