using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    public List<Card> inputCardList;

    private static List<Card> cards;

    public void Awake()
    {
        cards = inputCardList;
    }

    // Retorna todas as cartas do jogo.
    public static List<Card> Cards => cards;

}
