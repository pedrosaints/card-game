using UnityEngine;
using UnityEngine.UI;

public class ResizableBar : MonoBehaviour
{
    public Sprite barImage;
    public Sprite borderImage;

    public int minValue = 0;
    public int maxValue = 5;

    private Slider slider;

    public void Start()
    {
        ReplaceSprites();
        ReplaceValues();
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

    public void ReplaceValues()
    {
        // ReplaceValues redefine os novos valores de máximo e mínimo da barra com base no que foi inserido no editor.

        slider = GetComponent<Slider>();
        
        if(minValue >= 0 && maxValue >= 0)
        {
            slider.maxValue = maxValue;
            slider.minValue = minValue;
        }

    }
}
