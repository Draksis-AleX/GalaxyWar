using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioMenager : MonoBehaviour
{

    public Sound[] sounds;
    public AudioMixer audioMixer;
    public static AudioMenager _instance;

    public static AudioMenager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AudioMenager>();
                if (_instance == null) Debug.LogError("No PauseMenu in scene");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[0];
        }
    }

    private void Start() {
        Play("Background");
    }

    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }


}
