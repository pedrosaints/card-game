using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            GameObject audioSource = new GameObject(s.name);
            audioSource.transform.parent = this.gameObject.transform;
            s.source = audioSource.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.initVolume;
            s.source.loop = s.loop;
        }
    }

    public void Play(string soundName, bool isDelayed = false)
    {
        if (GetSound(soundName, out var s)) return;

        if (s.source.isPlaying) return;
        if (isDelayed)
        {
            s.source.PlayDelayed(s.audioSourceTimeDelay);
        }
        else
        {
            s.source.Play();
        }
    }

    public void SetVolume(string soundName, float volume)
    {
        if (GetSound(soundName, out var s)) return;

        s.source.volume = volume;
    }

    public void IncreaseVolume(string soundName)
    {
        // IcreaseVolume aumenta o volume do AudioSource um certo valor delta passado cada vez que é chamado,
        // incrementando até um valor máximo passado.

        if (GetSound(soundName, out var s)) return;

        if (s.source.volume < s.maxVolume)
        {
            s.source.volume += s.deltaVolume * Time.deltaTime;
        }
    }

    public void Stop(string soundName)
    {
        if (GetSound(soundName, out var s)) return;

        s.source.Stop();
    }

    private bool GetSound(string soundName, out Sound s)
    {
        s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found!");
            return true;
        }

        return false;
    }
}