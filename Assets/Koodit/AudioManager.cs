using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volum;
            s.source.pitch = s.pitch;
        }
    }
    private void Start()
    {
        Play("Theme");
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s == null) 
        { 
        Debug.LogWarning("Ääni: " + name + " ei Löydy!");
        return; 
        }
        s.source.Play();
    }
   
}
