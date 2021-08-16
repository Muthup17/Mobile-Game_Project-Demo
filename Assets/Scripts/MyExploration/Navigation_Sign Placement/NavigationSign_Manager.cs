using UnityEngine.SceneManagement;
using UnityEngine;

public class NavigationSign_Manager : MonoBehaviour
{
    [SerializeField] private float m_rayDistance;
    [SerializeField] private LayerMask m_mazeLayer;
    [SerializeField] GameObject[] handSignPrefab;
    [SerializeField] int numberOfSignHaving;
    [SerializeField] PowerUp power;

    NavigationSignCountUI ui;
    GameObject m_crosshair;
    Transform handSignRefContainer;
    GameObject[] handSignRefs;
    Ray ray;
    RaycastHit hitOfSignPlacement;
    bool isHittingMaze;

    public enum RefHandType
    {
        TYPE1,
        TYPE2,
        TYPE3,
        TYPE4
    }
    private RefHandType currentHandType;
    private RefHandType previousHandType;

    private void Awake()
    {
        m_crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        handSignRefContainer = GameObject.FindGameObjectWithTag("HandsignRefContainer").transform;
        ui = FindObjectOfType<NavigationSignCountUI>();
    }
    void Start()
    {
        handSignRefs = new GameObject[handSignRefContainer.childCount];
        int i = 0;
        foreach(Transform child in handSignRefContainer)
        {
            handSignRefs[i] = child.gameObject;
            i++;
        }
        currentHandType = RefHandType.TYPE1;
        numberOfSignHaving = power.currentPowerUpCount;
        if (SceneManager.GetActiveScene().buildIndex.Equals(1))
        {
            numberOfSignHaving = 100;
        }
        ui.UpdateCount(numberOfSignHaving);
    }

    private void FixedUpdate()
    {
        FindHittingOfMaze();
    }
    void Update()
    {
        PlaceHandSign();
    }

    void FindHittingOfMaze()
    {
        ray = Camera.main.ScreenPointToRay(m_crosshair.transform.position);
        isHittingMaze = Physics.Raycast(ray, out hitOfSignPlacement, m_rayDistance, m_mazeLayer);
        if (isHittingMaze)
        {
            Vector3 hitPoint = hitOfSignPlacement.point;
            if (NavigationSign_PlacementData.Instance.SignPlacePoint.Equals(Vector3.zero))
            {
                NavigationSign_PlacementData.Instance.SignPlacePoint = hitPoint;
            }
            else
            {
                if (NavigationSign_PlacementData.Instance.SameSignPlacePoint(hitPoint))
                {
                    return;
                }
                else
                {
                    NavigationSign_PlacementData.Instance.SignPlacePoint = hitPoint;
                }
            }
        }
        else
        {
            NavigationSign_PlacementData.Instance.SignPlacePoint = Vector3.zero;
        }
        NavigationSign_PlacementData.Instance.ReadyToPlaceSign = isHittingMaze;
    }

    void PlaceHandSign()
    {
        if (NavigationSignPlacement_InputData.Instance.IsKeyHolded && isHittingMaze && numberOfSignHaving > 0)
        {
            if (!handSignRefContainer.gameObject.activeSelf)
            {
                handSignRefContainer.gameObject.SetActive(true);
            }
            if (NavigationSignPlacement_InputData.Instance.FirstOneIsSelected)
            {
                previousHandType = currentHandType;
                currentHandType = RefHandType.TYPE1;
                SetHandSignRefs();
            }
            else if (NavigationSignPlacement_InputData.Instance.SecondOneIsSelected)
            {
                previousHandType = currentHandType;
                currentHandType = RefHandType.TYPE2;
                SetHandSignRefs();
            }
            else if (NavigationSignPlacement_InputData.Instance.ThirdOneIsSelected)
            {
                previousHandType = currentHandType;
                currentHandType = RefHandType.TYPE3;
                SetHandSignRefs();
            }
            else if (NavigationSignPlacement_InputData.Instance.ForthOneIsSelected)
            {
                previousHandType = currentHandType;
                currentHandType = RefHandType.TYPE4;
                SetHandSignRefs();
            }
            MoveHandSignRefs();
            if (NavigationSignPlacement_InputData.Instance.Printed)
            {
                InstantiateHandSign();   
            }
        }
        else
        {
            handSignRefContainer.gameObject.SetActive(false);
        }

    }

    void SetHandSignRefs()
    {
        switch (previousHandType)
        {
            case RefHandType.TYPE1:
                SetTransform(false, handSignRefs[0], Vector3.zero, Quaternion.identity);
                break;
            case RefHandType.TYPE2:
                SetTransform(false, handSignRefs[1], Vector3.zero, Quaternion.identity);
                break;
            case RefHandType.TYPE3:
                SetTransform(false, handSignRefs[2], Vector3.zero, Quaternion.identity);
                break;
            case RefHandType.TYPE4:
                SetTransform(false, handSignRefs[3], Vector3.zero, Quaternion.identity);
                break;
        }
    }

    void MoveHandSignRefs()
    {
        switch (currentHandType)
        {
            case RefHandType.TYPE1:
                SetTransform(true, handSignRefs[0], hitOfSignPlacement.point, Quaternion.LookRotation(hitOfSignPlacement.normal));
                break;
            case RefHandType.TYPE2:
                SetTransform(true, handSignRefs[1], hitOfSignPlacement.point, Quaternion.LookRotation(hitOfSignPlacement.normal));
                break;
            case RefHandType.TYPE3:
                SetTransform(true, handSignRefs[2], hitOfSignPlacement.point, Quaternion.LookRotation(hitOfSignPlacement.normal));
                break;
            case RefHandType.TYPE4:
                SetTransform(true, handSignRefs[3], hitOfSignPlacement.point, Quaternion.LookRotation(hitOfSignPlacement.normal));
                break;
        }
    }

    void InstantiateHandSign()
    {
        switch (currentHandType)
        {
            case RefHandType.TYPE1:
                Instantiate(handSignPrefab[0], hitOfSignPlacement.point, Quaternion.LookRotation(hitOfSignPlacement.normal));
                break;
            case RefHandType.TYPE2:
                Instantiate(handSignPrefab[1], hitOfSignPlacement.point, Quaternion.LookRotation(hitOfSignPlacement.normal));
                break;
            case RefHandType.TYPE3:
                Instantiate(handSignPrefab[2], hitOfSignPlacement.point, Quaternion.LookRotation(hitOfSignPlacement.normal));
                break;
            case RefHandType.TYPE4:
                Instantiate(handSignPrefab[3], hitOfSignPlacement.point, Quaternion.LookRotation(hitOfSignPlacement.normal));
                break;
        }
        numberOfSignHaving--;
        ui.UpdateCount(numberOfSignHaving);
    }

    void SetTransform(bool activeOrNot ,GameObject obj, Vector3 pos, Quaternion rot)
    {
        obj.SetActive(activeOrNot);
        obj.transform.position = pos;
        obj.transform.rotation = rot;
    }

    private void OnDestroy()
    {
        if (!SceneManager.GetActiveScene().buildIndex.Equals(1))
        {
            power.currentPowerUpCount = numberOfSignHaving;
        }
    }
    private void OnDisable()
    {
        NavigationSign_PlacementData.Instance.ResetData();
    }
}
