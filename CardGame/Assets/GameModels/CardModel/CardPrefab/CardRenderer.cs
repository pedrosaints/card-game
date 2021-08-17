using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardRenderer : MonoBehaviour
{
    public Card cardModel;

    public TMP_Text cardNameTMP;
    public TMP_Text cardDescriptionTMP;
    public Image cardArt;

    void Start()
    {
        Draw();
    }

    public void Draw()
    {
        // Insere as informações na carta e desenha ela na tela.


        // Mudando a fonte e o tamanho da primeira letra do nome da carta.
        cardNameTMP.text = $"<size=120%><font=\"NouveauDropCaps SDF\">{cardModel.cardName[0]}</font></size>{cardModel.cardName.Substring(1)}";
        cardDescriptionTMP.text = cardModel.cardDescription;
        cardArt.sprite = cardModel.cardArt;
        gameObject.SetActive(true);
    }

}
