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
        // BGM‚ğÄ¶
        BGMManager.Instance.PlayBGM(bgmClip);
    }

    public void SwitchScene()
    {
        // Ÿ‚ÌƒV[ƒ“‚É‘JˆÚ
        SceneManager.LoadScene(nextSceneName);
    }
}
