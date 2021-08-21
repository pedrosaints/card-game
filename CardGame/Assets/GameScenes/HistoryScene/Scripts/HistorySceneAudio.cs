using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistorySceneAudio : MonoBehaviour
{
    public AudioManager audioManagerPrefab;
    private AudioManager _audioManager;

    void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        if (_audioManager == null)
        {
            _audioManager = Instantiate(audioManagerPrefab);
        }
    }

    private void Start()
    {
        _audioManager.Play("TributeTheme");
        _audioManager.Play("NatureSounds");
    }

    private void Update()
    {
        _audioManager.IncreaseVolume("NatureSounds");
    }
}
