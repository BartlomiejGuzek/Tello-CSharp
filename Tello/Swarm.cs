using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Tello
{
    class Swarm
    {
        static void Main()
        {
            //List to store each tello
            List<Drone> telloList = new List<Drone>();
            Drone tello1 = new Drone("tello1", "192.168.20.51");
            Drone tello2 = new Drone("tello2", "192.168.20.52");
            Drone tello3 = new Drone("tello3", "192.168.20.53");
            telloList.Add(tello1);
            telloList.Add(tello2);
            telloList.Add(tello3);
            Console.ReadKey();
        }
    }
}
