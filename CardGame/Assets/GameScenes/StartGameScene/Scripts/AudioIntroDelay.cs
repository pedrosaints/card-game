using UnityEngine;

public class AudioIntroDelay : MonoBehaviour
{
    [SerializeField] private float maxVolume;
    [SerializeField] private float audioSourceTimeDelay;
    [SerializeField] private float deltaVolume;

    private AudioSource introAudio;

    void Start()
    {
        introAudio = GetComponent<AudioSource>();
        introAudio.volume = 0.0f;
        introAudio.PlayDelayed(audioSourceTimeDelay);
    }

    private void Update()
    {
        IncreaseVolume(maxVolume, deltaVolume);
    }

    private void IncreaseVolume(float maxVolume, float deltaVolume)
    {
        // IcreaseVolume aumenta o volume do AudioSource um certo valor delta passado cada vez que é chamado,
        // incrementando até um valor máximo passado.
        if (introAudio.volume < maxVolume) {
            introAudio.volume += deltaVolume * Time.deltaTime;
        }
    }
}
