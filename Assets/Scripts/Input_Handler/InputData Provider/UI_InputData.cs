using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InputData
{
    private static UI_InputData m_instance = new UI_InputData();
    public static UI_InputData Instance => m_instance;

    private bool m_inventoryUI_KeyPressed;

    private bool m_gameMenuUI_KeyPressed;

    private bool m_isInventoryPanelActive;

    private bool m_isPointerOverUI;
    public bool InventoryUIKeyPressed
    {
        get => m_inventoryUI_KeyPressed;
        set => m_inventoryUI_KeyPressed = value;
    }

    public bool GameMenuUI_KeyPressed
    {
        get => m_gameMenuUI_KeyPressed;
        set => m_gameMenuUI_KeyPressed = value;
    }

    public bool IsInventoryPanelActive
    {
        get => m_isInventoryPanelActive;
        set => m_isInventoryPanelActive = value;
    }
    public bool IsPointerOverUI
    {
        get => m_isPointerOverUI;
        set => m_isPointerOverUI = value;
    }

    public void ResetInput()
    {
        m_inventoryUI_KeyPressed = false;

        m_gameMenuUI_KeyPressed = false;

        m_isInventoryPanelActive = false;

        m_isPointerOverUI = false;
    }
}
