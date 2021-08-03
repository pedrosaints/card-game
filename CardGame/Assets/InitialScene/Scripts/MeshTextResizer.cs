using UnityEngine;
using TMPro;

public class MeshTextResizer : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private float minAlpha;
    [SerializeField] private float speed;

    private float maxAlpha;
    private bool inMaxAlpha = true;

    public void Start()
    {
        maxAlpha = tmpText.alpha;
    }
    public void Update()
    {
        FlashingText(minAlpha, maxAlpha, speed);
    }

    private void FlashingText(float minAlpha, float maxAlpha, float speedBlink)
    {
        if (inMaxAlpha)
        {
            if (Mathf.Ceil(tmpText.alpha - 0.01f) == minAlpha) inMaxAlpha = false;
            tmpText.alpha = Mathf.Lerp(tmpText.alpha, minAlpha, speedBlink * Time.deltaTime);
        }
        else {
            if (Mathf.Floor(tmpText.alpha + 0.01f) == maxAlpha) inMaxAlpha = true;
            tmpText.alpha = Mathf.Lerp(tmpText.alpha, maxAlpha, speedBlink * Time.deltaTime);
        }
        
    }
}
