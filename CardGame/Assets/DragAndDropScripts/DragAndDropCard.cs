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
        // Guardando o nome do parent atual para caso não mude, a carta volte para a posição inicial.
        currentParentName = cardRectTransform.parent.name;
        // Guardando a posição inicial, assim se não for possível dropar a carta na área desejada ela irá voltar
        // para a posição inicial.
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
        // Caso o parent da carta continue o mesmo, significa que não foi possível dropar a carta,
        // então devemos retornar a carta para a posição inicial.
        if(cardRectTransform.parent.name == currentParentName)
        {
            cardRectTransform.position = startPosition;
        }

        // Ativando a captura de eventos da carta após o drop.
        cardCanvasGroup.blocksRaycasts = true;
    }

}
