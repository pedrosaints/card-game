using UnityEngine;
using UnityEngine.UI;

public class ResizableBar : MonoBehaviour
{
    public Sprite barImage;
    public Sprite borderImage;

    public int minValue = 0;
    public int maxValue = 5;

    public Slider slider;

    public void Start()
    {
        slider = GetComponent<Slider>();
        ReplaceSprites();
    }


    public void ReplaceSprites()
    {
        // ReplaceSprites substitui os sprites padrões de ResizableBar pelos novos sprites passados no editor.

        if (barImage != null)
        {
            transform.Find("Bar").GetComponent<Image>().sprite = barImage;
        }

        if (borderImage != null)
        {
            transform.Find("Border").GetComponent<Image>().sprite = borderImage;
        }
    }

    public void ChangeColor(Color newColor) => transform.Find("Bar").GetComponent<Image>().color = newColor;

}
