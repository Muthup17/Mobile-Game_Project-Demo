using UnityEngine;

public class ContentPopup : MonoBehaviour
{
    public GameObject content;

    private void Awake()
    {
        content.transform.localScale = Vector3.zero;
    }
    public void OnOpen()
    {
        ContentPopup_Group.Instance.OnOpenClick(this);
    }

    public void OnClose()
    {
        ContentPopup_Group.Instance.OnCloseClick(this);
    }
}
