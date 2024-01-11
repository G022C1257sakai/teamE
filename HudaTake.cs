using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

// 1/11çXêV

public class HudaTake : MonoBehaviour
{
    public HudaUme ume;
    public HudaMatu matu;
    public HudaMozi umemozi;
    public HudaMozi takemozi;
    public HudaMozi matumozi;
    public StartView mozi;


    public void onclick()
    {
        transform.DOLocalMove(new Vector3(0f, 0f, 0f), 1f);

        ume.takeclick();
        matu.takeclick();
        umemozi.SetInvisible();
        takemozi.SetInvisible();
        matumozi.SetInvisible();
        mozi.Active();
    }

    public void umeclick()
    {
        transform.DOLocalMove(new Vector3(1900f, 0f, 0f), 1f);
    }

    public void matuclick()
    {
        transform.DOLocalMove(new Vector3(-1900f, 0f, 0f), 1f);
    }

    public void reset()
    {
        transform.DOLocalMove(new Vector3(0f, 0f, 0f), 1f);
    }


}
