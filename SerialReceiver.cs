using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO.Ports;

namespace puertoSerialCsharp
{
    public class SerialReceiver
    {
        static void Main(string[] args)
        {

            string[] ports = SerialPort.GetPortNames();
            Console.WriteLine("Puertos disponibles:");
            foreach (string port in ports)
            {
                Console.WriteLine(port);
            }

            if (ports.Length == 0)
            {
                Console.WriteLine("No hay puertos disponibles");
                return;
            }

           // string portName = ports[0]; 
            //SerialPort serialPort = new SerialPort(portName, 9600); 

            SerialPort serialPort = new SerialPort("COM7", 9600); 
            serialPort.Open();

            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();

            serialPort.Close();
        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string inData = sp.ReadExisting();
            Console.WriteLine("Mensaje recibido: " + inData);
        }
    }
}
