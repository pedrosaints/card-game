using UnityEngine;

public class PutCardsInHand : MonoBehaviour
{
    public GameObject cardPrefab;
    public RectTransform cardContainer;
    public int maxCardsInHand = 4;


    public void GetCards() {
        foreach (Card card in CardList.Cards)
        {
            // S� � adicionada uma carta � m�o do jogador se o n�mero de cartas for menor que o definido.
            if (cardContainer.childCount >= maxCardsInHand) break;

            // Instanciando a carta e colocando ela dentro de CardContainer.
            var clone = Instantiate(cardPrefab, cardContainer.transform);
            // Inicializando a carta com as informa��es da carta.
            clone.GetComponent<CardRenderer>().Initialize(card);
            // Ajustando a escala da carta.
            clone.transform.localScale = new Vector3(1.5f, 1.5f, 0.0f);
        }
    }

}
