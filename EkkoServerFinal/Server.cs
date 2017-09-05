using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EkkoServerFinal
{
    public class Server
    {
        public Server()
        {

        }

        public void Start()
        {
            // TCP er den pålidelige forbindelse. TCP er et socket.

            TcpListener server = new TcpListener(IPAddress.Loopback, 7);
            server.Start();

            //using funktionen sørger for at alt der åbnes lukkes pænt. 

            using (TcpClient client = server.AcceptTcpClient())
            using (NetworkStream ns = client.GetStream())

            //En som læser.
            using (StreamReader sr = new StreamReader(ns))
            // En som skriver)
            using (StreamWriter sw = new StreamWriter(ns))
            {
                // denne del adskiller vores ekko server fra en almindelig webserver.

                while (true)
                {
                    string inlinje = sr.ReadLine();
                    Console.WriteLine("Server modtaget : " + inlinje);
                    sw.WriteLine(inlinje.ToUpper());

                    //Tæller antal bogstaver inklusiv mellemrum.

                    int numberOfLetters = inlinje.Length;
                    Console.WriteLine(numberOfLetters);

                    //Tæller antal ord i en sætning.

                    int numberOfNew = inlinje.Split().Length;
                    Console.WriteLine(numberOfNew);


                    // Flush tømmer det serveren har og sender ud til forbindelse. 
                    sw.Flush();
                }
                

                //Console.ReadLine();
            }

        }
    }

}
    
