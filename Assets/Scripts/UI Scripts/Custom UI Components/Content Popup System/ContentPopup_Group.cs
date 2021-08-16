using UnityEngine;
using DG.Tweening;
using System.Collections;
public class ContentPopup_Group : MonoBehaviour
{
    private static ContentPopup_Group m_instance;
    public static ContentPopup_Group Instance => m_instance;
    [SerializeField] float animationDuration;

    private void Awake()
    {
        if(m_instance == null)
        {
            m_instance = this;
        }
    }
    public void OnOpenClick(ContentPopup popup)
    {
        WaitToEnbaleAnimationFinish(popup.content, Vector3.one, animationDuration);
    }
    public void OnOpenClick(GameObject content)
    {
        WaitToEnbaleAnimationFinish(content, Vector3.one, animationDuration);
    }
    public void OnCloseClick(ContentPopup popup)
    {
        StartCoroutine(WaitToDisableAnimationFinish(popup.content, Vector3.zero, animationDuration));
    }
    public void OnCloseClick(GameObject content)
    {
        StartCoroutine(WaitToDisableAnimationFinish(content, Vector3.zero, animationDuration));
    }

    void WaitToEnbaleAnimationFinish(GameObject obj, Vector3 vec, float duration)
    {
        obj.transform.parent.gameObject.SetActive(true);
        obj.transform.DOScale(vec, duration);
    }
    IEnumerator WaitToDisableAnimationFinish(GameObject obj, Vector3 vec, float duration)
    {
        obj.transform.DOScale(vec, duration);
        yield return new WaitForSeconds(duration);
        obj.transform.parent.gameObject.SetActive(false);
    }
}
