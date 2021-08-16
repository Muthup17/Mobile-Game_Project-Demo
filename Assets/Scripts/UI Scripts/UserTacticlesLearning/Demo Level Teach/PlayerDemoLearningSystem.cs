using System.Collections;
using UnityEngine;

[DefaultExecutionOrder(-10)]
public class PlayerDemoLearningSystem : MonoBehaviour
{
    private static PlayerDemoLearningSystem m_instance;
    public static PlayerDemoLearningSystem Instance => m_instance;

    [SerializeField] LearnedItems learn;
    [SerializeField] InteractableObjectTipDetails[] tipUI;

    private DemoUserTips userTipUI;
    public LearnedItems Learn => learn;

    public DemoUserTips UserTipUI
    {
        get => userTipUI;
        set => userTipUI = value;
    }

    public bool tipRequested;
    public int currentTipIndex;
    public int nextTipIndex;
    bool called;
    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
        called = false;
        tipRequested = false;
        nextTipIndex = 0;
    }

    private void Update()
    {
        if (!called)
            ShowTip();
    }
    void ShowTip()
    {
        if (!tipRequested) return;
        userTipUI.tip = tipUI[currentTipIndex];
        GameWindowPopUpGroup.Instance.OnOpenClick(userTipUI.content);
        userTipUI.ShowUI();
        StartCoroutine(WaitToFinish());
        called = true;
        nextTipIndex += 1;
    }
    IEnumerator WaitToFinish()
    {
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 0;
    }
    public void HideTip()
    {
        learn.learnItems[currentTipIndex].value = true;
        tipRequested = false;
        Time.timeScale = 1;
        userTipUI.tip = null;
        GameWindowPopUpGroup.Instance.OnCloseClick(userTipUI.content);
        called = false;
    }
}
