using UnityEngine;

public class CharacterChoiceSceneAudio : MonoBehaviour
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
        _audioManager.Stop("TributeTheme");
        _audioManager.Play("NatureSounds");
        _audioManager.SetVolume("NatureSounds", 0.2f);

        if (Loader.LastScene != Loader.Scene.CharacterScene)
        {
            _audioManager.Play("FluteOpening");
        }
    }
}