using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RenderCard : MonoBehaviour
{
    public Card cardModel;

    public TMP_Text cardNameTMP;
    public TMP_Text cardDescriptionTMP;
    public Image cardArt;

    void Start()
    {
        cardNameTMP.text = $"<size=120%><font=\"NouveauDropCaps SDF\">{cardModel.cardName[0]}</font></size>{cardModel.cardName.Substring(1)}";
        cardDescriptionTMP.text = cardModel.cardDescription;
        cardArt.sprite = cardModel.cardArt;
    }

}
