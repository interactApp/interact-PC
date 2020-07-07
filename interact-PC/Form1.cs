using Fleck;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace interact_PC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string str_msg = "ws://" + GetIpAddress() + ":50000";
            int version = 7;
            int pixel = 5;
            int int_icon_size = 1;
            int int_icon_border = 1;

            Bitmap bmp = chestnut_qrcode.Encoder.code(str_msg, version, pixel, "E:/20180329173736326.jpg", int_icon_size, int_icon_border,true);
            pb_qrcode.Image = bmp;
            LoadWebSocket();

        }
        private void LoadWebSocket()
        {
            var allSockets = new List<IWebSocketConnection>();
            var server = new WebSocketServer("ws://0.0.0.0:50000");
            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("Open!");
                    allSockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("Close!");
                    allSockets.Remove(socket);
                };
                socket.OnMessage = message =>
                {
                    Console.WriteLine(message);
                    allSockets.ToList().ForEach(s => s.Send("Echo: " + message));
                };
            });


           // var input = Console.ReadLine();
           // while (input != "exit")
           // {
           //     foreach (var socket in allSockets.ToList())
           //     {
           //         socket.Send(input);
           //     }
            //    input = Console.ReadLine();
           // }
        }

        private string GetIpAddress()
        {
            string hostName = Dns.GetHostName();   //获取本机名
            // IPHostEntry localhost = Dns.GetHostByName(hostName);    //方法已过期，可以获取IPv4的地址
                                                                    //IPHostEntry localhost = Dns.GetHostEntry(hostName);   //获取IPv6地址
            var ipv4 = Dns.GetHostEntry(hostName).AddressList.Where(i => i.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
            // IPAddress localaddr = localhost.AddressList[0];

            return ipv4.ToString();
        }

    }
}

