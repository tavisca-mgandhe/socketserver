using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SocketServer
{
    class GetFile
    {
         public string file { get; }
        public StreamReader GetFileData(string fileName)
        {
            try
            {


                return new StreamReader("C:/Users/mgandhe/source/repos/SocketServer/" + fileName);
            }
            catch
            {
                

            }

            return new StreamReader("C:/Users/mgandhe/source/repos/SocketServer/404.html" );
        }

    }
}
