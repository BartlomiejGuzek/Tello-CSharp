using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tello
{
    class Drone
    {
        private string name;
        private string address;
        private UdpClient udpClient;
        private IPEndPoint endPoint;

        public Drone(string _name, string _address)
        {
            name = _name;
            address = _address;
        }


        public string GetName()
        {
            return name;
        }
        /// <summary>
        /// Utility command used to send bytes over ip
        /// </summary>
        /// <param name="_command"></param>
        public void Send(string _command)
        {
            udpClient = new UdpClient();
            endPoint = new IPEndPoint(IPAddress.Parse(address), 8889);
            try
            {
                udpClient.Connect(endPoint);
                Byte[] sendBytes = Encoding.ASCII.GetBytes(_command);
                udpClient.Send(sendBytes, sendBytes.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(name + " threw: " + e.ToString());
            }
        }

        /// <summary>
        /// Puts Tello in SDK mode
        /// </summary>
        public void Command()
        {
            Send("command");
            Console.WriteLine(name + " command");
        }

        /// <summary>
        /// Take off
        /// </summary>
        public void TakeOff()
        {
            Send("takeoff");
            Console.WriteLine(name + " takeoff");
        }

        /// <summary>
        /// Land
        /// </summary>
        public void Land()
        {
            Send("land");
            Console.WriteLine(name + " land");
        }

        /// <summary>
        /// Set video stream on. IP 0.0.0.0 via UDP PORT 11111.
        /// </summary>
        public void StreamOn()
        {
            Send("streamon");
        }

        /// <summary>
        /// Set video stream off.
        /// </summary>
        public void StreamOff()
        {
            Send("streamoff");
        }


        /// <summary>
        /// Stop all motors immediately
        /// </summary>
        public void Emergency()
        {
            Send("emergency");
        }

        /// <summary>
        /// Fly up with distance x cm
        /// </summary>
        /// <param name="distance">Must be between 20 - 500</param>
        public void Up(int distance)
        {
            Send("up " + distance);
        }

        /// <summary>
        /// Fly down with distance x cm
        /// </summary>
        /// <param name="distance">Must be between 20 - 500</param>
        public void Down(int distance)
        {
            Send("down " + distance);
        }

        /// <summary>
        /// Fly left with distance x cm
        /// </summary>
        /// <param name="distance">Must be between 20 - 500</param>
        public void Left(int distance)
        {
            Send("left " + distance);
        }

        /// <summary>
        /// Fly right with distance x cm
        /// </summary>
        /// <param name="distance">Must be between 20 - 500</param>
        public void Right(int distance)
        {
            Send("right " + distance);
        }

        /// <summary>
        /// Fly forward with distance x cm
        /// </summary>
        /// <param name="distance">Must be between 20 - 500</param>
        public void Forward(int distance)
        {
            Send("forward " + distance);
        }

        /// <summary>
        /// Fly back with distance x cm
        /// </summary>
        /// <param name="distance">Must be between 20 - 500</param>
        public void Back(int distance)
        {
            Send("back " + distance);
        }

        /// <summary>
        /// Rotate Tello by x degree clockwise
        /// </summary>
        /// <param name="degree">Must be between 1- 3600</param>
        public void Cw(int degree)
        {
            Send("cw " + degree);
        }

        /// <summary>
        /// Rotate Tello by x degree counter-clockwise
        /// </summary>
        /// <param name="degree">Must be between 1- 3600</param>
        public void Ccw(int degree)
        {
            Send("ccw " + degree);
        }

        /// <summary>
        /// Perform a flip in given direction
        /// </summary>
        /// <param name="direction">"l" - left, "r" - right, "f" - forward, "b" - back</param>
        public void Flip(string direction)
        {
            Send("flip " + direction);
        }

        /// <summary>
        /// Fly Tello to x, y, z with given speed
        /// </summary>
        /// <param name="x">Must be between 20 - 500</param>
        /// <param name="y">Must be between 20 - 500</param>
        /// <param name="z">Must be between 20 - 500</param>
        /// <param name="speed">Must be between 10 - 100</param>
        public void Go(int x, int y, int z, int speed)
        {
            Send("go " + x + y + z + speed);
        }

        /// <summary>
        /// Fly on curve defined by
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <param name="speed"></param>
        public void Curve(int x1, int y1, int z1, int x2, int y2, int z2, int speed)
        {
            Send("curve " + x1 + y1 + z1 + x2 + y2 + z2 + speed);
        }

        /// <summary>
        /// Set speed to x cm/s
        /// </summary>
        /// <param name="speed">Must be between 10 - 100</param>
        public void Speed(int speed)
        {
            Send("speed " + speed);
        }

        /// <summary>
        /// Send RC control via four channels
        /// </summary>
        /// <param name="a">Left/right. Must be between -100 - 100</param>
        /// <param name="b">Forward/backward. Must be between -100 - 100</param>
        /// <param name="c">Up/down. Must be between -100 - 100</param>
        /// <param name="d">Yaw. Must be between -100 - 100</param>
        public void RC(int a, int b, int c, int d)
        {
            Send("rc " + a + b + c + d);
        }

        /// <summary>
        /// Set new SSID and password
        /// </summary>
        /// <param name="ssid"></param>
        /// <param name="password">Must have at least 8 characters</param>
        public void Ssid(string ssid, string password)
        {
            Send("ssid " + ssid + password);
        }

        /// <summary>
        /// Get current speed
        /// </summary>
        public void GetSpeed()
        {
            Send("speed?");
        }

        /// <summary>
        /// Get current battery level
        /// </summary>
        public void GetBattery()
        {
            Send("battery?");
        }

        /// <summary>
        /// Get for current flytime
        /// </summary>
        public void GetTime()
        {
            Send("time?");
        }

        /// <summary>
        /// Get current height in cm
        /// </summary>
        public void GetHeight()
        {
            Send("height?");
        }

        /// <summary>
        /// Get current temperature
        /// </summary>
        public void GetTemp()
        {
            Send("temp?");
        }

        /// <summary>
        /// Get IMU attitude data
        /// </summary>
        public void GetAttitude()
        {
            Send("attitude?");
        }

        /// <summary>
        /// Get barometer value in meters
        /// </summary>
        public void GetBaro()
        {
            Send("baro?");
        }

        /// <summary>
        /// Get IMU angular acceleration data
        /// </summary>
        public void GetAcceleration()
        {
            Send("acceleration?");
        }

        /// <summary>
        /// Get distance from TOF in centimeters
        /// </summary>
        public void GetTOF()
        {
            Send("tof?");
        }

        /// <summary>
        /// Get WIFI SNR
        /// </summary>
        public void GetWifi()
        {
            Send("wifi?");
        }

    }
}
