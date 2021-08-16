using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleButtonUIAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        this.transform.DOScale(1.05f, 0.3f);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        this.transform.DOScale(1, 0.3f);
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        this.transform.DOShakePosition(0.2f, 10, 15);
    }
}
