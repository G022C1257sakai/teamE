using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

// 1/11çXêV

public class HudaMatu : MonoBehaviour
{
    public HudaUme ume;
    public HudaTake take;
    public HudaMozi umemozi;
    public HudaMozi takemozi;
    public HudaMozi matumozi;
    public StartView mozi;



    public void onclick()
    {
        transform.DOLocalMove(new Vector3(0f, 0f, 0f), 1f);

        ume.matuclick();
        take.matuclick();
        umemozi.SetInvisible();
        takemozi.SetInvisible();
        matumozi.SetInvisible();
        mozi.Active();

    }

    public void takeclick()
    {
        transform.DOLocalMove(new Vector3(1900f, 0f, 0f), 1f);
    }

    public void umeclick()
    {
        transform.DOLocalMove(new Vector3(1900f, 0f, 0f), 1f);
    }

    public void reset()
    {
        transform.DOLocalMove(new Vector3(505f, 0f, 0f), 1f);
    }
}
