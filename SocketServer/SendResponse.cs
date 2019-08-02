using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SocketServer
{class SendResponse
    {
        public SendResponse(StreamWriter sw, string page)
        {
            StreamReader reader = new GetFile().GetFileData(page);
            sw.WriteLine("HTTP/1.0 200 OK \n");
            sw.Flush();

            string[] filed = page.Split('.');
            if (filed.Length == 2 && filed[1] == "png")
            {
            sw.WriteLine("Accept:*/*");
                sw.Flush();
                Console.WriteLine("Image");
            }
            //Send That File to Client

            string data = reader.ReadLine();

            while (data != null)

            {

                sw.WriteLine(data);
                Console.WriteLine(data);

                sw.Flush();



                //Next data

                data = reader.ReadLine();

            }


        }
    }
}
