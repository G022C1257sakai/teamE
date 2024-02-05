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

            // AudioSource �R���|�[�l���g���擾
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }

            // �V�[���J�ڂ��Ă��j������Ȃ��悤�ɂ���
            DontDestroyOnLoad(gameObject);


    }

    public void PlayBGM(AudioClip bgmClip)
    {
        // BGM�Đ�
        audioSource.clip = bgmClip;
        audioSource.Play();
    }

    public void StopBGM()
    {
        // BGM��~
        audioSource.Stop();
    }
}
