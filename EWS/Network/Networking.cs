using DCS.Compile;

using DCS;
using DCS.DCSTables;
using DCS.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ENG.Network
{

    public class Networking
    {
        UdpClient udpSocket;
        int PortNo = 11000;
        int BroadcastPortNo = 11000;
        IPAddress IP_Address;
        //IPEndPoint remoteEP;

        public Networking()
        {
            udpSocket = new UdpClient(PortNo);
            //remoteEP = new IPEndPoint(IPAddress.Any, 11000);
            ////remoteEP = new IPEndPoint(IPAddress.Parse("192.168.1.2"), 11000);
            //udpServer.Connect(remoteEP);
        }

        public void ReadData()
        {
            try
            {
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, BroadcastPortNo);
                //udpServer.Connect(remoteEP);
                while (true)
                {
                    Trace.Write("receive data from " + remoteEP.ToString());

                    

                    StructBytes sf = new StructBytes(typeof(MessagePacket));
                    var data = udpSocket.Receive(ref remoteEP); // listen on port 11000
                    
                    
                    //udpServer.Send(new byte[] { 1 }, 1, remoteEP); // reply back
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        public bool SendData()
        {
            udpSocket.Send(new byte[] { 1, 2, 3, 4, 5 }, 5);
            return true;
        }

        public void CheckWorkstations()
        {
            int n = 0;
            Thread.Sleep(5000);
            MessagePacket messagepack;

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress broadcast = IPAddress.Parse("192.168.1.255");

            
            IPEndPoint ep = new IPEndPoint(broadcast, 11000);

           // s.SendTo(sendbuf, ep);



            
            StructBytes sf = new StructBytes(typeof(MessagePacket));
            try
            {
                while (true)
                {
                    foreach(tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
                    {
                        messagepack.Index = 1;
                        messagepack.res = 1;
                        messagepack.CAT = 1;
                        messagepack.ID = 1;
                        messagepack.StationNo = (byte)tblcontroller.NodeNumber;
                        //udpServer.Send(sf.StructToByteArray(messagepack), sf.SizeofStructure(messagepack));
                        n = s.SendTo(sf.StructToByteArray(messagepack), ep);
                        //udpServer.Send(new byte[] { 1 }, 1);
                        Thread.Sleep(100);
                    
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
