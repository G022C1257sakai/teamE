using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1/11XV

public class Reset : MonoBehaviour
{
    public HudaUme ume;
    public HudaTake take;
    public HudaMatu matu;
    public HudaMozi umemozi;
    public HudaMozi takemozi;
    public HudaMozi matumozi;
    public StartView mozi;



    public void onclick()
    {
        ume.reset();
        take.reset();
        matu.reset();
        umemozi.reset();
        takemozi.reset();
        matumozi.reset();
        mozi.reset();
    }

}
