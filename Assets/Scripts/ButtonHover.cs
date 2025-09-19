using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
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
        SetHover(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetHover(false);
    }

    // --- Gamepad seleção ---
    public void OnSelect(BaseEventData eventData)
    {
        SetHover(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        SetHover(false);
    }

    private void SetHover(bool state)
    {
        isHovered = state;
        lFrame.SetActive(state);
        rFrame.SetActive(state);
    }
}