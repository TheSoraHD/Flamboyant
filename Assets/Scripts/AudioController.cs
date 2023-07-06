using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip[] audioClip;

    private AudioSource m_AudioSource;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void ChangeAudio(AudioClip audio)
    {
        m_AudioSource.clip = audio;
        m_AudioSource.Play();
    }
}
