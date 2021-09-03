using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropCard : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas canvas;
    private RectTransform cardRectTransform;

    private CanvasGroup cardCanvasGroup;
    private Vector3 startPosition;
    private string currentParentName;


    public void Awake()
    {
        cardCanvasGroup = GetComponent<CanvasGroup>();
        cardRectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

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
