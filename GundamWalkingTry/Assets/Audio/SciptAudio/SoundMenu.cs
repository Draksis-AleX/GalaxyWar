using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume (float volume){
        audioMixer.SetFloat("volume", volume);
    }

    public void SetVolumeEffects(float volume)
    {
        audioMixer.SetFloat("Effects", Mathf.Log10(volume)*20);
    }

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }


}
