using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    public Sound[] sounds;
    public TimeDeltaTime timer;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }
    private void Start()
    {
         Play("Theme");
    }
     public void Play(string name)
     {
         Sound s = Array.Find(sounds, sound => sound.name == name);
         if (s == null)
             return;
        s.source.pitch = 1;
        s.source.Play();
     }
     public void StopSound(string name)
     {
         Sound s = Array.Find(sounds, sound => sound.name == name);
         if (s == null)
             return;
         s.source.Stop();
     }
    public void ChangePitch(string name)
     {
         Sound s = Array.Find(sounds, sound => sound.name == name);
         if (s == null)
             return;
         //s.source.pitch=1+timer.speedIncrease/5;
    }
    public void ResetPitch(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.pitch = 1;
    }
}
