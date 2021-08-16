using DG.Tweening;
using UnityEngine;
using System.Collections;
using MyExploration.Interaction;
using MyExploration.UI.Interactions;
public class Chest : InteractableObject, IValidatable
{
    bool m_isContainKey;
    [SerializeField] InteractionState m_interactionState;
    [SerializeField] string m_openID;
    [SerializeField] float animationDuration;
    SkeletonTriggerer skTrigger;
    public InteractionState StateOfInteraction { get => m_interactionState; set => m_interactionState = value; }

    public string ID => m_openID;
    new void Start()
    {
        base.Start();
        m_isContainKey = true;
        skTrigger = GetComponent<SkeletonTriggerer>();
    }
    public override void OnInteract()
    {
        base.OnInteract();
        if (PlayerInteractionData.Instance.AmIHoldSomething() && PlayerInteractionData.Instance.CurrentHoldingObject.TypeOfObject.Equals(ObjectType.TWOHANDED))
        {
            Debug.Log("Need to Drop");
            return;
        }
        else
        {
            if (m_interactionState.Equals(InteractionState.UNLOCKED))
            {
                OpenChest();
            }
            else
            {
                Debug.Log("Chest is Locked, Find the Appropriate Key");
                InteractionStateUI.Instance.StartShowandHide(InteractionStateUI.Instance.interactionFailed);
            }
        }
    }
    void OpenChest()
    {
        Transform chest_Top = transform.Find("ChestTop");
        if (gameObject.name.StartsWith("Stone"))
        {
            StartCoroutine(PlayChestAnimations(chest_Top));
        }
        else
        {
            chest_Top.DORotate(Vector3.right * -90f, animationDuration, RotateMode.LocalAxisAdd);
        }
        chest_Top.gameObject.layer = LayerMask.NameToLayer("Default");
        transform.Find("ChestBase").gameObject.layer = LayerMask.NameToLayer("Default");
        if (!UserLearningSystem.Instance.Learn.learnItems[0].value)
        {
            UserLearningSystem.Instance.tipRequested = true;
            UserLearningSystem.Instance.currentTipIndex = 0;
        }
        if(skTrigger != null)
        {
            skTrigger.Trigger();
        }
    }
    public bool IsContainsKey()
    {
        m_isContainKey = transform.Find("Key") != null ? true : false;
        Debug.Log(m_isContainKey);
        return m_isContainKey;
    }
    
    IEnumerator PlayChestAnimations(Transform chest_Top)
    {
        chest_Top.DORotate(Vector3.up * 50f, animationDuration * 0.5f, RotateMode.LocalAxisAdd);
        yield return new WaitForSeconds(animationDuration * 0.5f);
        chest_Top.DOMove(transform.localPosition - transform.right * 0.5f, animationDuration * 0.5f);
    }

}
