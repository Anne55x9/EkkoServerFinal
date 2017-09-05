using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerClient
{
    public class Client
    {

        public void Start()
        {
            //String sendStr = "Anne Sofie";

            using (TcpClient client = new TcpClient("localhost", 7))
            using (NetworkStream ns = client.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using(StreamWriter sw = new StreamWriter(ns))
            {
                while (true)
                {
                    string sendStr = Console.ReadLine(); 
                    sw.WriteLine(sendStr);
                    sw.Flush();

                    String incomingStr = sr.ReadLine();
                    Console.WriteLine("Ekko Modtaget:" + incomingStr);
                   
                }

                Console.ReadLine();
            }
        }
    }
}
