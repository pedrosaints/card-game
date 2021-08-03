using UnityEngine;

public class TextScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    private RectTransform rectTransform;


    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Update()
    {
        rectTransform.anchoredPosition += Vector2.up * Time.deltaTime * scrollSpeed;
    }
}
