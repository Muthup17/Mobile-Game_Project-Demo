using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
public class Tab_Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image bg;
    TabGroup tabGroup;

    void Awake()
    {
        tabGroup = this.GetComponentInParent<TabGroup>();
    }

    void Start()
    {
        tabGroup.SubscribeButton(this);
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabHover(this);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

    public void Select()
    {

    }
    public void Deselect()
    {

    }
}
