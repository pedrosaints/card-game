using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    [Header("Parâmetros de criação da carta:")]
    public string cardName;
    public string cardDescription;
    public Sprite cardArt;
    public Color cardType;

}
