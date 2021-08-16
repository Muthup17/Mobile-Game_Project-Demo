using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
namespace AI.Skeletons
{
    public class PlayerDetection : MonoBehaviour
    {
        [SerializeField] LayerMask targetLayer;
        [SerializeField] LayerMask obstacleLayer;
        [SerializeField] float yOffset;
        [SerializeField] private float viewRadius;
        [SerializeField] private float viewAngle;

        [SerializeField] Slider detectionMeter;
        [SerializeField] float detectionMultiplier;
        [SerializeField] float detectMeterPositionScale;
        bool coolDown;
        float detectionMeterValue;
        float maxDetectionMeterValue = 100;

        GOAP_Agent gAgent;
        GameObject currentVisibleTarget;
        bool trigger1;
        public bool trigger2;
        public bool playerVisibled;

        bool playerFootSoundHeard;
        GameObject CheckDirection;
        NavMeshAgent navAgent;

        private void Awake()
        {
            PlayerFootSound_Publisher.Instance.onFootSoundHear += OnSoundHeardByFoot;
            DoorSound_Publisher.onDoorOpenSoundHear += OnSoundHeardByObject;
            RockSound_Publisher.onRockCollidedSoundHear += OnSoundHeardByObject;
            gAgent = this.GetComponent<GOAP_Agent>();
            navAgent = this.GetComponent<NavMeshAgent>();

        }
        private void FixedUpdate()
        {
            DetectPlayer();
        }
        // Update is called once per frame
        void Update()
        {
            ApplyStates();
            CheckSoundDirection();
        }

        void DetectPlayer()
        {
            if (!trigger1 || !trigger2) { return; }
            Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetLayer);
            foreach (Collider player in targetsInViewRadius)
            {
                Vector3 dirToTarget = player.transform.position - transform.position;
                float dstTarget = dirToTarget.magnitude;
                if (dstTarget < viewRadius)
                {
                    Vector3 normalizedDirection = dirToTarget.normalized;
                    float angleFromPlayerToEnemy = Vector3.SignedAngle(player.transform.forward, -normalizedDirection, Vector3.up);
                    float xpos = Mathf.Cos(angleFromPlayerToEnemy * Mathf.Deg2Rad) * detectMeterPositionScale;
                    float ypos = Mathf.Sin(angleFromPlayerToEnemy * Mathf.Deg2Rad) * detectMeterPositionScale;
                    detectionMeter.transform.localPosition = new Vector3(ypos, xpos, Camera.main.nearClipPlane);

                    if (!Physics.Raycast(transform.position + new Vector3(0, yOffset, 0), normalizedDirection, dstTarget, obstacleLayer))
                    {
                        if (!detectionMeter.gameObject.activeSelf)
                        {
                            detectionMeter.gameObject.SetActive(true);
                        }
                        float angleFromEnemyToPlayer = Vector3.Angle(transform.forward, normalizedDirection);
                        if (angleFromEnemyToPlayer < viewAngle)
                        {
                            coolDown = false;
                            Debug.DrawRay(transform.position + new Vector3(0, yOffset, 0), normalizedDirection * dstTarget, Color.green);
                            detectionMeterValue += Time.fixedDeltaTime * Inverse(Remap(dstTarget, viewRadius, 2)) * detectionMultiplier;
                            if (detectionMeterValue > maxDetectionMeterValue) detectionMeterValue = maxDetectionMeterValue;
                            detectionMeter.value = Remap(detectionMeterValue, maxDetectionMeterValue, detectionMeter.maxValue);
                            if (detectionMeter.value >= 1)
                            {
                                currentVisibleTarget = player.gameObject;
                                playerVisibled = true;
                            }
                        }
                        else
                        {
                            coolDown = true;
                            currentVisibleTarget = null;
                            playerVisibled = false;
                        }
                    }
                    else
                    {
                        coolDown = true;
                        currentVisibleTarget = null;
                        playerVisibled = false;
                    }
                }
                else
                {
                    if (detectionMeter.gameObject.activeSelf)
                    {
                        detectionMeter.gameObject.SetActive(false);
                    }
                }
            }

            if (coolDown)
            {
                detectionMeterValue -= Time.fixedDeltaTime * 50f;
                if (detectionMeterValue < 0) detectionMeterValue = 0;
                detectionMeter.value = Remap(detectionMeterValue, maxDetectionMeterValue, detectionMeter.maxValue);
                if (detectionMeter.value <= 0)
                {
                    coolDown = false;
                }

            }

        }
        void ApplyStates()
        {
            if (currentVisibleTarget == null) return;
            if (gAgent.beliefs.HasState("PlayerIsDetected") || gAgent.inventory.items.Contains(currentVisibleTarget)) return;
            gAgent.beliefs.SetState("PlayerIsDetected", 1);
            gAgent.inventory.AddItem(currentVisibleTarget);
            if(gAgent.currentAction != null)
                gAgent.currentAction.skipImmediate = true;
            Debug.Log("Called");
        }
        void CheckSoundDirection()
        {
            if (!trigger1 && !trigger2) { return; }
            if (playerFootSoundHeard)
            {
                gAgent.isPause = true;
                navAgent.enabled = false;
                Vector3 targetDirection = CheckDirection.transform.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 250f);
                float dotValue = Vector3.Dot(transform.forward, targetDirection);
                if (dotValue > 0.9f)
                {
                    Debug.Log("FinishedRotation");
                    playerFootSoundHeard = false;
                    CheckDirection = null;
                    gAgent.isPause = false;
                    navAgent.enabled = true;
                    if (!playerVisibled && gAgent.currentAction != null)
                    {
                        gAgent.currentAction.agent.SetDestination(gAgent.currentAction.target.transform.position);
                    }
                }
            }
        }
        void OnSoundHeardByFoot(GameObject monster, GameObject player)
        {
            if (!trigger1 || !trigger2) return;
            if (monster.Equals(this.gameObject) && !playerFootSoundHeard)
            {
                playerFootSoundHeard = true;
                CheckDirection = player;
            }
        }
        void OnSoundHeardByObject(GameObject monster, GameObject obj)
        {
            if (!trigger1 || !trigger2) return;
            if (monster.Equals(this.gameObject))
            {
                Debug.Log("Sound Heard");
                if (gAgent.beliefs.HasState("SoundHeard") || gAgent.beliefs.HasState("PlayerIsDetected")) return;
                gAgent.beliefs.SetState("SoundHeard", 1);
                gAgent.inventory.AddItem(obj);
                Debug.Log("SkippedBySound");
                gAgent.currentAction.skipImmediate = true;
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (!trigger2) return;
            if (other.CompareTag("Player"))
            {
                Vector3 viewpoint = Camera.main.WorldToViewportPoint(transform.position + new Vector3(0, yOffset, 0));
                bool onScreen = viewpoint.z > 0 && viewpoint.x > 0 && viewpoint.x < 1 && viewpoint.y > 0 && viewpoint.y < 1;
                if (!onScreen)
                {
                    Destroy(GetComponent<Collider>());
                    this.GetComponent<Skeleton>().enabled = true;
                    this.GetComponent<Animator>().enabled = true;
                    trigger1 = true;
                }
            }
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + new Vector3(0, yOffset, 0), viewRadius);
        }

        float Remap(float inputValue, float maxOutputValue, float remapedMaxValue)
        {
            return (inputValue / maxOutputValue) * remapedMaxValue;
        }
        float Inverse(float value)
        {
            return 2 - value;
        }
        private void OnDestroy()
        {
            PlayerFootSound_Publisher.Instance.onFootSoundHear -= OnSoundHeardByFoot;
            DoorSound_Publisher.onDoorOpenSoundHear -= OnSoundHeardByObject;
            RockSound_Publisher.onRockCollidedSoundHear -= OnSoundHeardByObject;
        }
    }
}
