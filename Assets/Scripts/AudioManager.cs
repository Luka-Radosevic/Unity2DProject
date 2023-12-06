using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Audio[] sounds;
    void Awake()
    {
        foreach (Audio s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Click (string name)
    {
        Audio s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
