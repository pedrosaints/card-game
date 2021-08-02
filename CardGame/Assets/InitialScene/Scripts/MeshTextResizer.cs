using UnityEngine;
using TMPro;

public class MeshTextResizer : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private float maxFontSize;
    [SerializeField] private float speedResize;

    private float minFontSize;
    private bool isIncreasingSize = true;

    public void Start()
    {
        minFontSize = tmpText.fontSize;
    }
    public void Update()
    {
        Resize(minFontSize, maxFontSize, speedResize);
    }

    private void Resize(float minSize, float maxSize, float speedResize) {
        // Resize modifica o tamanho da fonte do texto de um valor minimo até um valor máximo, e do valor máximo até o minimo
        // em uma dada velocidade.

        if (isIncreasingSize)
        {
            if (Mathf.Ceil(tmpText.fontSize + 0.5f) > maxSize)
            {
                isIncreasingSize = false;
            }
            tmpText.fontSize = Mathf.Lerp(tmpText.fontSize, maxSize, speedResize * Time.deltaTime);
        }
        else {
            if (Mathf.Floor(tmpText.fontSize - 0.5f) < minSize)
            {
                isIncreasingSize = true;
            }
            tmpText.fontSize = Mathf.Lerp(tmpText.fontSize, minSize, speedResize * Time.deltaTime);
        }
        
    }
}
