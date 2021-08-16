using System.Collections;
using DG.Tweening;
using UnityEngine;
using MyExploration.Interaction;
using MyExploration.Inventories;
using MyExploration.Examine;
public class PickableObject : InteractableObject, IExaminable
{
    [SerializeField] SoundBase pickup;
    [SerializeField] SoundBase drop;
    [SerializeField] Vector2 sensitivity = new Vector2(500, 500);
    [SerializeField] Vector2 smoothAmount = new Vector2(20, 20);
    float m_yaw;
    float m_pitch;
    float m_desiredYaw;
    float m_desiredPitch;
    private Rigidbody rb;

    public ExaminationType ExamineType => ExaminationType.JUSTLOOKTYPE;

    public Transform ExaminationPlace => PlayerExaminationData.Instance.ExaminingPlace;

    private bool m_isExamining;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (m_isExamining && PlayerExaminationData.Instance.CurrentExaminationObject.Equals(this) )
        {
            Debug.Log("Called");
            CalculateRotation();
            SmoothRotation();
            ApplyRotation();
        }
    }

    #region Interact
    public override void OnInteract()
    {
        base.OnInteract();
        HoldTheObject();
        pickup.Play(source);
    }
    public virtual void HoldTheObject()
    {
        transform.SetParent(PlayerInteractionData.Instance.HoldingAnchor);
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        rb.isKinematic = true;
        ResetTransform();
        PlayerInteractionData.Instance.CurrentHoldingObject = this;
        PlayerInteractionData.Instance.PlayerState = PlayerStates.HOLDING;
        PlayerInteractionData.Instance.IsConsumable = GetComponent<Pickup>().GetItem().IsConsumable();
        transform.DORotate(new Vector3(0, 360, 0), 1, RotateMode.LocalAxisAdd);
        ChangeLayerMask("Interacting");
    }
    public void UnHoldTheObject()
    {
        rb.isKinematic = false;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        if (PlayerInteractionData.Instance.ReadyToPutBack())
        {
            transform.SetParent(PlayerInteractionData.Instance.PutBackTransform);
            ResetTransform();
        }
        else
        {
            transform.SetParent(null);
            transform.position = PlayerExaminationData.Instance.ExaminingPlace.position;
            Vector3 forceDirection = PlayerInteractionData.Instance.HitEveryThingRayHitPoint - transform.position;
            forceDirection.Normalize();
            rb.AddForce(forceDirection * 10000f * Time.deltaTime);
        }
        PlayerInteractionData.Instance.PlayerState = PlayerStates.HOLDNOTHING;
        PlayerInteractionData.Instance.CurrentHoldingObject = null;
        PlayerInteractionData.Instance.IsConsumable = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.collider.CompareTag("Player") && PlayerInteractionData.Instance.CurrentHoldingObject != this) 
        {
            if (!gameObject.layer.Equals(LayerMask.NameToLayer("Interactable")))
            {
                ChangeLayerMask("Interactable");
            }
            drop.Play(source);
        }
    }
    #endregion

    #region Examine
    public void OnExamine()
    {
        if (transform.parent != ExaminationPlace)
        {
            transform.SetParent(ExaminationPlace);
            ResetTransform();
        }
        PlayerInteractionData.Instance.PlayerState = PlayerStates.EXAMINING;
        m_isExamining = true;
        PlayerExaminationData.Instance.IsExamining = m_isExamining;
    }
    public void AfterExamined()
    {
        transform.SetParent(PlayerInteractionData.Instance.HoldingAnchor);
        ResetTransform();
        m_yaw = 0;
        m_pitch = 0;
        m_desiredYaw = 0;
        m_desiredPitch = 0;
        PlayerInteractionData.Instance.PlayerState = PlayerStates.HOLDING;
        m_isExamining = false;
        PlayerExaminationData.Instance.IsExamining = m_isExamining;
    }
   
    void CalculateRotation()
    {
        m_desiredYaw += PlayerExamination_InputData.Instance.InputVector.x * sensitivity.x * Time.deltaTime;
        m_desiredPitch -= PlayerExamination_InputData.Instance.InputVector.y * sensitivity.y * Time.deltaTime;
    }

    void SmoothRotation()
    {
        m_yaw = Mathf.Lerp(m_yaw, m_desiredYaw, smoothAmount.x * Time.deltaTime);
        m_pitch = Mathf.Lerp(m_pitch, m_desiredPitch, smoothAmount.y * Time.deltaTime);
    }

    void ApplyRotation()
    {
        transform.localEulerAngles = new Vector3(m_pitch, m_yaw, 0f);
    }

    #endregion

    public void ResetTransform()
    {
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;
        transform.localScale = Vector3.one;
    }

    void ChangeLayerMask(string layerName)
    {
        Collider[] allColliders = transform.GetComponentsInChildren<Collider>();
        foreach(Collider col in allColliders)
        {
            col.gameObject.layer = LayerMask.NameToLayer(layerName);
        }

    }

}
