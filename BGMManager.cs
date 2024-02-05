using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;
    private AudioSource audioSource;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // AudioSource コンポーネントを取得
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }

            // シーン遷移しても破棄されないようにする
            DontDestroyOnLoad(gameObject);


    }

    public void PlayBGM(AudioClip bgmClip)
    {
        // BGM再生
        audioSource.clip = bgmClip;
        audioSource.Play();
    }

    public void StopBGM()
    {
        // BGM停止
        audioSource.Stop();
    }
}
