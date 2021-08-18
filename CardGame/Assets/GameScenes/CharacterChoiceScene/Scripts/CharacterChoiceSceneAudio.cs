using UnityEngine;

public class CharacterChoiceSceneAudio : MonoBehaviour
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