using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace EWS.Networking
{
    public class Network11
    {
        UdpClient udpServer;
        int PortNo = 11000;
        IPAddress IP_Address;
        IPEndPoint remoteEP;
        
        public Network11()
        {
            udpServer = new UdpClient(PortNo);
            remoteEP = new IPEndPoint(IPAddress.Any, 11000);
        }

        public void ReadData()
        {
            try
            {
                while (true)
                {

                    var data = udpServer.Receive(ref remoteEP); // listen on port 11000
                    Trace.Write("receive data from " + remoteEP.ToString());
                    //udpServer.Send(new byte[] { 1 }, 1, remoteEP); // reply back
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
