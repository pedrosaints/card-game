using UnityEngine;
using UnityEngine.EventSystems;

public class CardAreaDrop : MonoBehaviour, IDropHandler
{
    public int maxChildrenNumber = 2;

    public void Start()
    {
        if(maxChildrenNumber == 0)
        {
            throw new System.Exception("O n�mero de filhos n�o pode ser 0");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(ChildCount() < maxChildrenNumber)
        {
            // Caso a carta seja dropada na �rea, mudamos seu Parent como sendo a �rea de drop.
            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(this.transform);
        }
    }

    public int ChildCount() {
        // Retorna o n�mero de filhos presentes na �rea de drop.
        return GetComponent<RectTransform>().childCount;
    }

}
