using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebSocketServidor
{
    public class Echo: WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("Recebido: " + e.Data);
            Send("Servidor recebeu:"+e.Data);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WebSocketServer wss = new WebSocketServer("ws://127.0.0.1:7890");
            wss.AddWebSocketService<Echo>("/Echo");
            wss.Start();
            Console.WriteLine("7890   Servidor conectado!");
            Console.ReadKey();
            wss.Stop();
        }
    }
}
