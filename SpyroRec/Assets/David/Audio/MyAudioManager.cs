using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MyAudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer;
    public void SetVolMaster(float volume)
    {
        _audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
    public void SetVolSFX(float volume)
    {
        _audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
    public void SetVolMusic(float volume)
    {
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }
}
