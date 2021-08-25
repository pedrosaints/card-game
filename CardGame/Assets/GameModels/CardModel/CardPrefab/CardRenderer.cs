using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardRenderer : MonoBehaviour
{
    public Card cardModel;

    private TMP_Text cardNameTMP;
    private TMP_Text cardDescriptionTMP;
    private Image cardArt;


    public void Start()
    {
        GetFields();
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

    private void GetFields()
    {

        cardNameTMP = transform.Find("CardNameTMP").GetComponent<TMP_Text>();
        cardDescriptionTMP = transform.Find("CardDescriptionTMP").GetComponent<TMP_Text>();
        cardArt = transform.Find("CardArt").GetComponent<Image>();
    }

}
