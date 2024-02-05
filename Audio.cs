using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Audio : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleAudio()
    {
        if (audioSource != null)
        {
            // ŠÖ”ToggleAudio‚ªŒÄ‚Î‚ê‚½‚çŒ»İ‚Ìmute‚Ì’l‚ğ”½“]‚³‚¹‚é
            audioSource.mute = !audioSource.mute;
        }
    }
}