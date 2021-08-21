using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;
    
    [Range(0f, 1f)] public float initVolume;
    [Range(0f, 1f)] public float maxVolume;
    [Range(0f, 1f)] public float audioSourceTimeDelay;
    [Range(0f, 1f)] public float deltaVolume;

    public bool loop;

    [HideInInspector] public AudioSource source;
}