using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropCard : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
 
    public RectTransform cardRectTransform;
    public Canvas canvas;
    public CanvasGroup cardCanvasGroup;
    public Vector3 startPosition;
    public string currentParentName;


    public void OnBeginDrag(PointerEventData eventData)
    {
        // Guardando o nome do parent atual para caso n�o mude, a carta volte para a posi��o inicial.
        currentParentName = cardRectTransform.parent.name;
        // Guardando a posi��o inicial, assim se n�o for poss�vel dropar a carta na �rea desejada ela ir� voltar
        // para a posi��o inicial.
        startPosition = cardRectTransform.position;
        // Desativando a captura de eventos da carta.
        cardCanvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        cardRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Caso o parent da carta continue o mesmo, significa que n�o foi poss�vel dropar a carta,
        // ent�o devemos retornar a carta para a posi��o inicial.
        if(cardRectTransform.parent.name == currentParentName)
        {
            cardRectTransform.position = startPosition;
        }

        // Ativando a captura de eventos da carta ap�s o drop.
        cardCanvasGroup.blocksRaycasts = true;
    }

}
