using System.Collections;
using UnityEngine;

[DefaultExecutionOrder(-10)]
public class UserLearningSystem : MonoBehaviour
{
    private static UserLearningSystem m_instance;
    public static UserLearningSystem Instance => m_instance;

    [SerializeField] LearnedItems learn;
    [SerializeField] InteractableObjectTipDetails[] tipUI;

    private UserTipUI userTipUI;
    public LearnedItems Learn => learn;

    public UserTipUI UserTipUI
    {
        get => userTipUI;
        set => userTipUI = value;
    }

    public bool tipRequested;
    public int currentTipIndex;
    bool called;
    private void Awake()
    {
        if(m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        called = false;
        tipRequested = false;
    }

    private void Update()
    {
        if(!called)
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
