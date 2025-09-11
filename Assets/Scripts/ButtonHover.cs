using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    public float scaleFactor = 1.5f; // quanto vai crescer
    public float speed = 10f;        // velocidade da transição

    private bool isHovered = false;

    public GameObject lFrame;
    public GameObject rFrame;

    void Start()
    {
        originalScale = transform.localScale;
        lFrame.SetActive(false);
        rFrame.SetActive(false);
    }

    void Update()
    {
        // Suaviza a animação de escala
        Vector3 targetScale = isHovered ? originalScale * scaleFactor : originalScale;
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.unscaledDeltaTime * speed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
        lFrame.SetActive(isHovered);
        rFrame.SetActive(isHovered);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        lFrame.SetActive(isHovered);
        rFrame.SetActive(isHovered);
    }
}