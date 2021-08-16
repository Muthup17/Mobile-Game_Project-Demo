using System.Collections;
using UnityEngine;

namespace AI.Monsters
{
    public class ThrowableAffect : MonoBehaviour
    {
        [SerializeField] GOAP_Agent gAgent;
        [SerializeField] float takeDamageAnimLength;

        MonsterHealthSystem healthSystem;
        private void Awake()
        {
            healthSystem = GetComponentInParent<MonsterHealthSystem>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Player_SmokeBomb") && gAgent.enabled && !gAgent.currentGoal.sGoals.Key.StartsWith("Sleep"))
            {
                ContactPoint cp = collision.contacts[0];
                if(cp.point.y > 1.35)
                {
                    healthSystem.TakePoisonDamage(100);
                    gAgent.beliefs.SetState("ThrowedSmokeBomb", 1);
                    gAgent.currentAction.skipImmediate = true;
                }
                else
                {
                    healthSystem.TakePoisonDamage(40);
                    if(healthSystem.CurrentPoisonAffect <= 0)
                    {
                        gAgent.beliefs.SetState("ThrowedSmokeBomb", 1);
                        gAgent.currentAction.skipImmediate = true;
                    }
                    else
                    {
                        gAgent.isPause = true;
                        gAgent.animationAgent.anim.SetTrigger("TakeDamage");
                        StartCoroutine(WaitToAnimationFinish(takeDamageAnimLength));
                    }
                }
            }
        }

        IEnumerator WaitToAnimationFinish(float animationLength)
        {
            float startTime = Time.time;
            float desiredTime = 0;

            while (true)
            {
                desiredTime = Time.time - startTime;
                if (desiredTime > animationLength)
                {
                    gAgent.isPause = false;
                    break;
                }
                yield return null;
            }
        }
    }
}
