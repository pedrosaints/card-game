using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    [Header("Par�metros de cria��o da carta:")]
    public string cardName;
    public string cardDescription;
    public Sprite cardArt;
    public Color cardType;

}
