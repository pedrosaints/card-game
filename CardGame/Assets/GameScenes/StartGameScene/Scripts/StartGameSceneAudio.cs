using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameSceneAudio : MonoBehaviour
{
    public AudioManager audioManager;

    private void Awake()
    {
        var audioManagerInstance = FindObjectOfType<AudioManager>();
        if (audioManagerInstance == null)
        {
            audioManagerInstance = Instantiate(audioManager);
            audioManager = audioManagerInstance;
        }
    }

    void Start()
    {
        audioManager.Play("NatureSounds", true);
    }

    private void Update()
    {
        audioManager.IncreaseVolume("NatureSounds");
    }
}