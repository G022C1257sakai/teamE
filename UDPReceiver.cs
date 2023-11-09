using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

public class UDPReceiver : MonoBehaviour
{

    int LOCAL_PORT = 22222;
    static UdpClient udp;
    Thread thread;

    public void UDPStart()
    {
        udp = new UdpClient(LOCAL_PORT);
        thread = new Thread(new ThreadStart(ThreadMethod));
        thread.Start();
    }

    private static void ThreadMethod()
    {
        while (true)
        {
            IPEndPoint remoteEp = null;
            byte[] data = udp.Receive(ref remoteEp);
            string text = Encoding.ASCII.GetString(data);

            JsonNode jsonNode = JsonNode.Parse(text);

            double ax = jsonNode["sensordata"]["accel"]["x"].Get<double>();
            double ay = jsonNode["sensordata"]["accel"]["y"].Get<double>();
            double az = jsonNode["sensordata"]["accel"]["z"].Get<double>();

            double qutX = jsonNode["sensordata"]["quaternion"]["x"].Get<double>();
            double qutY = jsonNode["sensordata"]["quaternion"]["y"].Get<double>();
            double qutZ = jsonNode["sensordata"]["quaternion"]["z"].Get<double>();
            double qutW = jsonNode["sensordata"]["quaternion"]["w"].Get<double>();

            /*double proX = jsonNode["sensordata"]["proximity monitor"]["x"].Get<double>();
            double proY = jsonNode["sensordata"]["proximity monitor"]["y"].Get<double>();
            double proZ = jsonNode["sensordata"]["proximity monitor"]["z"].Get<double>();
            double proW = jsonNode["sensordata"]["proximity monitor"]["w"].Get<double>();
            */

            Debug.Log("ax = " + ax + ", ay = " + ay + ", az = " + az);
            Debug.Log("qutX = " + qutX + ", qutY = " + qutY + ", qutZ = " + qutZ + ", qutW = " + qutW);
            //Debug.Log("proX = " + proX + ", proY = " + proY + ", proZ = " + proZ + ", proW = " + proW);//


        }
    }

    void OnApplicationQuit()
    {
        if (thread != null && thread.IsAlive)
        {
            thread.Abort();
        }
    }
}




