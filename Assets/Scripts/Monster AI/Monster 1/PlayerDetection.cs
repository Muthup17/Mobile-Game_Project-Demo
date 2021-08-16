using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;
namespace AI.Monsters
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
        GOAP_Agent gAgent;
        [HideInInspector]
        GameObject currentVisibleTarget;
        public bool playerVisibled;

        float detectionMeterValue;
        float maxDetectionMeterValue = 100;
        public bool coolDown;

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
            if (gAgent.currentGoal != null && gAgent.currentGoal.sGoals.Key.StartsWith("Sleep")) return;
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

                    if(!Physics.Raycast(transform.position + new Vector3(0, yOffset, 0), normalizedDirection, dstTarget, obstacleLayer))
                    {
                        if (!detectionMeter.gameObject.activeSelf)
                        {
                            detectionMeter.gameObject.SetActive(true);
                        }
                        float angleFromEnemyToPlayer = Vector3.Angle(transform.forward, normalizedDirection);
                        if(angleFromEnemyToPlayer < viewAngle)
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
            if (currentVisibleTarget == null || gAgent.currentGoal.sGoals.Key.StartsWith("Sleep")) return;
            if (gAgent.beliefs.HasState("PlayerVisibled") || gAgent.inventory.items.Contains(currentVisibleTarget)) return;
            gAgent.beliefs.SetState("PlayerVisibled", 1);
            gAgent.inventory.AddItem(currentVisibleTarget);
            if (gAgent.currentAction != null)
                gAgent.currentAction.skipImmediate = true;
        }

        void CheckSoundDirection()
        {
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
                    gAgent.currentAction.agent.SetDestination(gAgent.currentAction.target.transform.position);
                }
            }
        }
        void OnSoundHeardByFoot(GameObject monster, GameObject player)
        {
            if (monster.Equals(this.gameObject) && !playerFootSoundHeard && !gAgent.currentGoal.sGoals.Key.StartsWith("Sleep"))
            {
                Debug.Log("Hearing");
                playerFootSoundHeard = true;
                CheckDirection = player;
            }
        }
        void OnSoundHeardByObject(GameObject monster, GameObject obj)
        {
            if (monster.Equals(this.gameObject) && !gAgent.currentGoal.sGoals.Key.StartsWith("Sleep"))
            {
                Debug.Log("Sound Heard");
                if (gAgent.beliefs.HasState("SoundHeard") || gAgent.beliefs.HasState("PlayerIsDetected")) return;
                gAgent.beliefs.SetState("SoundHeard", 1);
                gAgent.inventory.AddItem(obj);
                Debug.Log("SkippedBySound");
                gAgent.currentAction.skipImmediate = true;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + new Vector3(0, yOffset, 0), viewRadius);
        }

        private void OnDestroy()
        {
            PlayerFootSound_Publisher.Instance.onFootSoundHear -= OnSoundHeardByFoot;
            DoorSound_Publisher.onDoorOpenSoundHear -= OnSoundHeardByObject;
            RockSound_Publisher.onRockCollidedSoundHear -= OnSoundHeardByObject;
        }


        float Remap(float inputValue, float maxOutputValue, float remapedMaxValue)
        {
            return (inputValue / maxOutputValue) * remapedMaxValue;
        }
        float Inverse(float value)
        {
            return 2 - value;
        }
    }
}
