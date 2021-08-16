using System.Collections;
using UnityEngine.UI;
using UnityEngine;
[System.Serializable]
public class SelectorValue
{
    public string valueName;
    public int value;
}
public class HorizontalSelector : MonoBehaviour
{
    [SerializeField] Text displayText;
    [SerializeField] SelectorValue[] selectors;

    int currentIndex;

    private SelectorValue curr_Selector;
    public SelectorValue CurrentSelector
    {
        get => curr_Selector;
    }
    private void Start()
    {
        if(selectors == null)
        {
            Debug.LogError("Put Values To" + " " + this.gameObject + " ");
        }
        currentIndex = 0;
        displayText.text = selectors[currentIndex].valueName;
    }

    public void LeftClick()
    {
        currentIndex -= 1;
        if (currentIndex < 0)
        {
            currentIndex = selectors.Length - 1;
        }
        curr_Selector = selectors[currentIndex];
        displayText.text = selectors[currentIndex].valueName;
    }
    public void RightClick()
    {
        currentIndex += 1;
        if (currentIndex > selectors.Length - 1)
        {
            currentIndex = 0;
        }
        curr_Selector = selectors[currentIndex];
        displayText.text = selectors[currentIndex].valueName;
    }
}
