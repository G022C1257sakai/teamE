using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StopBGMButton : MonoBehaviour
{

    public void OnButtonClick()
    {
        // BGM���~
        BGMManager.Instance.StopBGM();
    }
}
