using UnityEngine;
using UnityEngine.EventSystems;

public class CardAreaDrop : MonoBehaviour, IDropHandler
{
    public int maxChildrenNumber = 2;

    public void Start()
    {
        if(maxChildrenNumber == 0)
        {
            throw new System.Exception("O número de filhos não pode ser 0");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(ChildCount() < maxChildrenNumber)
        {
            // Caso a carta seja dropada na área, mudamos seu Parent como sendo a área de drop.
            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(this.transform);
        }
    }

    public int ChildCount() {
        // Retorna o número de filhos presentes na área de drop.
        return GetComponent<RectTransform>().childCount;
    }

}
