using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void VolumeChange(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
