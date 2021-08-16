using System.Collections;
using UnityEngine;
using MyExploration.Interaction;
using DG.Tweening;
using MyExploration.UI.Interactions;
public enum ObjectState
{
    CLOSED,
    OPENED
}
public class DoorObject : InteractableObject, IValidatable
{
    [SerializeField] InteractionState m_interactionState;
    [SerializeField] private SoundBase m_doorOpen;
    [SerializeField] private SoundBase m_doorClose;
    [SerializeField] float doorAnimationLength;
    [SerializeField] private string doorID;

    private GameObject player;
    private ObjectState m_doorState;

    public bool doorOpenSoundPlayed;
    public InteractionState StateOfInteraction
    {
        get => m_interactionState;
        set => m_interactionState = value;
    }

    public ObjectState StateOfDoor
    {
        get => m_doorState;
        set => m_doorState = value;
    }
    public string ID => doorID;

    new void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
        m_doorState = ObjectState.CLOSED;
    }
    public override void OnInteract()
    {
        base.OnInteract();
        if (!UserLearningSystem.Instance.Learn.learnItems[1].value)
        {
            UserLearningSystem.Instance.tipRequested = true;
            UserLearningSystem.Instance.currentTipIndex = 1;
        }
        if (PlayerInteractionData.Instance.AmIHoldSomething() && PlayerInteractionData.Instance.CurrentHoldingObject.TypeOfObject.Equals(ObjectType.TWOHANDED))
        {
            Debug.Log("Need to Drop");
            return;
        }
        switch (m_doorState)
        {
            case ObjectState.OPENED:
                DoorClose();
                break;
            case ObjectState.CLOSED:
                if (m_interactionState.Equals(InteractionState.UNLOCKED))
                {
                    DoorOpen();
                }
                else
                {
                    Debug.Log("Door is Locked");
                    InteractionStateUI.Instance.StartShowandHide(InteractionStateUI.Instance.interactionFailed);
                }
                break;
        }
       
    }
    void DoorOpen()
    {
        if(DoorDotValue(player) > 0)
        {
            float yawValue = transform.localEulerAngles.y > 180 ? 90 + (360 - transform.localEulerAngles.y)  : 90 - transform.localEulerAngles.y;
            transform.DORotate(new Vector3(0, yawValue, 0), doorAnimationLength, RotateMode.LocalAxisAdd);
        }
        else
        {
            float yawValue = -90 - Remap(transform.localEulerAngles.y);
            transform.DORotate(new Vector3(0, yawValue, 0), doorAnimationLength, RotateMode.LocalAxisAdd);
        }
        m_doorOpen.Play(source);
        m_doorState = ObjectState.OPENED;
        StartCoroutine(DoorSoundPlayed());
    }

    void DoorClose()
    {
        float yawValue = transform.localEulerAngles.y > 180 ? 360 - transform.localEulerAngles.y : 0 - transform.localEulerAngles.y;
        transform.DORotate(new Vector3(0,yawValue, 0), doorAnimationLength, RotateMode.LocalAxisAdd);
        m_doorClose.Play(source);
        m_doorState = ObjectState.CLOSED;
    }

    public void OnMonsterInteract(GameObject monster)
    {
        DoorOpen(monster);
    }
    void DoorOpen(GameObject enemy)
    {
        if (DoorDotValue(enemy) > 0)
        {
            float yawValue = transform.localEulerAngles.y > 180 ? 90 + (360 - transform.localEulerAngles.y) : 90 - transform.localEulerAngles.y;
            transform.DORotate(new Vector3(0, yawValue, 0), doorAnimationLength * 0.5f, RotateMode.LocalAxisAdd);
        }
        else
        {
            float yawValue = -90 - Remap(transform.localEulerAngles.y);
            transform.DORotate(new Vector3(0, yawValue, 0), doorAnimationLength * 0.5f, RotateMode.LocalAxisAdd);
        }
        m_doorOpen.Play(source);
        m_doorState = ObjectState.OPENED;
        StartCoroutine(DoorSoundPlayed());
    }
    float DoorDotValue(GameObject obj)
    {
        float value = Vector3.Dot(transform.parent.transform.forward, obj.transform.forward);
        return value;
    }

    IEnumerator DoorSoundPlayed()
    {
        yield return new WaitForSeconds(doorAnimationLength);
        doorOpenSoundPlayed = true;
        yield return null;
        doorOpenSoundPlayed = false;
    }
    float Remap(float value)
    {
        return value > 180 ? value - 360 : value;
    }
}
