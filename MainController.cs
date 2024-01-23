using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{

    public UDPReceiver updReceiver;
    public Transform phoneTf;
    public Quaternion phoneRot;
    public GameObject sword;
    public GameObject up;
    public GameObject under;
    public int A;
    public int B;
    public int C;
    public float startTime = -1f;





    // Use this for initialization
    void Start()
    {
        Input.gyro.enabled = true;
        UDPReceiver.AccelCallBack += AccelAction;
        UDPReceiver.GyroCallBack += GyroAction;
        updReceiver.UDPStart();

    }

    public void AccelAction(float xx, float yy, float zz)
    {

    }

    public void GyroAction(float xx, float yy, float zz, float ww)
    {
        var newQut = new Quaternion(-xx, -zz, -yy, ww);
        var newRot = newQut * Quaternion.Euler(90f, 0, 0);
        phoneRot = newRot;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name + "Enter");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.name + "Stay");
      
        if (startTime < 0f)
        {
            if (other.name == "up")
            {
                A = 1;
            }
            else if (other.name == "under")
            {
                B = 1;
            }
            startTime = Time.time;
        }
        
        if ((A == 2) && (other.name == "under") || 
            (B == 2) && (other.name == "up"))
        {
            C = 1;
            float elapsedTime = Time.time ;
            //4秒以内に切れれば演出が出る
            if (elapsedTime < 4)
            {
                Debug.Log("切れました。経過時間: " + elapsedTime + "秒");
            }
            else
            {
                Debug.Log("切れませんでした。経過時間: " + elapsedTime + "秒");
            }

            
        }
  
    }

        void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log(other.name + "Exit");
        if (A == 1)
        {
            A = 2;
        }
        else if (B == 1)
        {
            B = 2;
        }
    }

        // Update is called once per frame
        void Update()
        {
            phoneTf.localRotation = phoneRot;

            if (sword != null)
            {
                // 制限された範囲を設定
                float minX = 0f;
                float maxX = 180f;
                float minY = 0f;
                float maxY = 90f;
                float minZ = 0f;
                float maxZ = 10f;

                // 新しい位置を計算し、制限された範囲内にクランプ
                Vector3 newPosition = sword.transform.localPosition + phoneRot * Vector3.forward * Time.deltaTime;
                newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
                newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
                newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

                // クランプされた位置を設定
                sword.transform.localPosition = newPosition;
            }


            if (sword != null)
            {
                sword.transform.localRotation = phoneRot;
            }
        }


    }
