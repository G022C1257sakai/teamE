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
        // BGM���Đ�
        BGMManager.Instance.PlayBGM(bgmClip);
    }

    public void SwitchScene()
    {
        // ���̃V�[���ɑJ��
        SceneManager.LoadScene(nextSceneName);
    }
}
