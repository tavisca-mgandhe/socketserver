using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.IO;

namespace SocketServer
{
    class Program
    {
        public static void Main()
        {
             TcpListener listner = new TcpListener(8100);
            listner.Start();


            while (true)

            {

                Console.WriteLine("Waiting For Connection....");

                TcpClient client = listner.AcceptTcpClient();

                StreamReader sr = new StreamReader(client.GetStream());

                StreamWriter sw = new StreamWriter(client.GetStream());

                try

                {

                    //client's request

                    string request = sr.ReadLine();

                    Console.WriteLine(request);

                    string[] token = request.Split(' ');

                    string page = token[1];

 
                    Console.WriteLine($"Asking For URL - {token[1]}");
                    new SendResponse(sw,page);
                  

 
                }

                catch (Exception e)

                {

                    sw.WriteLine("HTTP/1.0 404 OK\n");
                    
                    StreamReader reader = new StreamReader("C:/Users/mgandhe/source/repos/SocketServer/404.html");
                    string data = reader.ReadLine();
                    while (data != null)

                    {
                        try
                        {
                            sw.WriteLine(data);

                            sw.Flush();

                        }
                        catch
                        { }

                        //Next data

                        data = reader.ReadLine();

                    }
                    sw.Flush();

                }

                finally

                {

                    client.Close();

                }

            }
}
    }
}