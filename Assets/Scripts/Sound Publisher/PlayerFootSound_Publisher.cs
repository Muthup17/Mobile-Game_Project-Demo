using System;
using System.Collections;
using UnityEngine;
using PlayerControlls;
public class PlayerFootSound_Publisher : MonoBehaviour
{
    private static PlayerFootSound_Publisher m_instance;
    public static PlayerFootSound_Publisher Instance => m_instance;

    [SerializeField] LayerMask monsterLayer;
    [SerializeField] LayerMask obstacleLayer; 
    [SerializeField] float publishing_Radius;
    [SerializeField] float yOffset;
    FirstPersonController fpc;

    public event Action<GameObject, GameObject> onFootSoundHear;
    public bool playerVisibledToEnemy;

    private void OnEnable()
    {
        if(m_instance == null)
        {
            m_instance = this;
        }
        fpc = this.GetComponent<FirstPersonController>();
    }
    // Update is called once per frame
    void Update()
    {
        Collider[] subscribers = Physics.OverlapSphere(transform.position + new Vector3(0f, yOffset, 0f), publishing_Radius, monsterLayer);
        foreach (Collider sub in subscribers)
        {
            if (sub.CompareTag("Base"))
            {
                bool canPublish = sub.transform.parent.gameObject.CompareTag("ChasingPlayer") ? false : true;
                if (!canPublish) return;
                Transform CurrTarget = sub.transform;
                Vector3 dirToTarget = (CurrTarget.position - transform.position).normalized;
                float dstToTarget = Vector3.Distance(transform.position, CurrTarget.position);
                if (!Physics.Raycast(transform.position + new Vector3(0, yOffset, 0), dirToTarget, dstToTarget, obstacleLayer))
                {
                    Debug.DrawRay(transform.position + new Vector3(0, yOffset, 0), dirToTarget * dstToTarget, Color.green);
                    if (fpc.IsFootSoundPlayed || fpc.IsJumpSoundPlayed)
                    {
                        StartCoroutine(WaitToInvoke(sub.transform.parent.gameObject));
                    }
                }
            }
        }
    }

    IEnumerator WaitToInvoke(GameObject target)
    {
        yield return new WaitForSeconds(0.5f);
        onFootSoundHear?.Invoke(target, this.gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0f, yOffset, 0f), publishing_Radius);
    }
}
