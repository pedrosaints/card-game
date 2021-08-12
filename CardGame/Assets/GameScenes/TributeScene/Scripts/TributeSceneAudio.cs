using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TributeSceneAudio : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("TributeTheme");
        FindObjectOfType<AudioManager>().Play("NatureSounds");
    }
}