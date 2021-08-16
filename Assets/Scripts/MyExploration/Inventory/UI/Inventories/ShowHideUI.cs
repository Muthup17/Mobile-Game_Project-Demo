using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ShowHideUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject uiContainer = null;

    // Start is called before the first frame update
    void Start()
    {
        uiContainer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (UI_InputData.Instance.InventoryUIKeyPressed)
        {
            uiContainer.SetActive(!uiContainer.activeSelf);
            UI_InputData.Instance.IsInventoryPanelActive = uiContainer.activeSelf;
        }
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        UI_InputData.Instance.IsPointerOverUI = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        UI_InputData.Instance.IsPointerOverUI = false;
    }
}