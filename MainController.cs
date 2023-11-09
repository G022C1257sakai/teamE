using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{

    public UDPReceiver updReceiver;

    // Use this for initialization
    void Start()
    {
        updReceiver.UDPStart();
    }
}


