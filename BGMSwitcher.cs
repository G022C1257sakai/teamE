using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class BGMSwitcher : MonoBehaviour
{
    public string nextSceneName;
    public AudioClip bgmClip;

    void Start()
    {
        // BGMを再生
        BGMManager.Instance.PlayBGM(bgmClip);
    }

    public void SwitchScene()
    {
        // 次のシーンに遷移
        SceneManager.LoadScene(nextSceneName);
    }
}
