using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    [SerializeField] Tab_Button defaultTab;
    [SerializeField] List<Tab_Button> tabButtons;
    [SerializeField] List<GameObject> contents;
    [SerializeField] Color hover;
    [SerializeField] Color selected;
    [SerializeField] Color normal;

    Tab_Button selectedTab;

    private void OnEnable()
    {
        OnTabSelected(defaultTab);
    }
    public void SubscribeButton(Tab_Button tab)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<Tab_Button>();
        }
        tabButtons.Add(tab);
    }

    public void OnTabHover(Tab_Button tab)
    {
        if (selectedTab == null || tab != selectedTab)
        {
            ResetColor();
            tab.bg.color = hover;
        }
    }

    public void OnTabExit(Tab_Button tab)
    {
        ResetColor();
    }

    public void OnTabSelected(Tab_Button tab)
    {
        selectedTab = tab;
        ResetColor();
        tab.bg.color = selected;
        int index = tab.transform.GetSiblingIndex();
        for(int i = 0; i < contents.Count; i++)
        {
            if(index == i)
            {
                contents[i].SetActive(true);
            }
            else
            {
                contents[i].SetActive(false);
            }
        }
    }

    void ResetColor()
    {
        foreach(Tab_Button tab in tabButtons)
        {
            if (selectedTab != null && selectedTab == tab) continue;
            tab.bg.color = normal;
        }
    }


}
