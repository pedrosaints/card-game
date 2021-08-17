using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassChoiceSceneAudio : MonoBehaviour
{
    void Start()
    {
        var audioManager = FindObjectOfType<AudioManager>();
        if (audioManager == null)
        {
            return;
        }

        audioManager.Stop("TributeTheme");
        audioManager.Play("Cascavel");
    }
}