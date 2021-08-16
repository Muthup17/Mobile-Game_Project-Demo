using System.Collections;
using UnityEngine;

namespace AI.Monsters
{
    public class SlipDown : GOAP_Action
    {
        [SerializeField] float sleepAnimationLength;
        public override bool PostPerform()
        {
            beliefs.RemoveState("ThrowedSmokeBomb");
            return true;
        }

        public override bool PrePerform()
        {
            target = this.gameObject;
            gAgent.animationAgent.anim.SetTrigger("Sleep");
            StartCoroutine(WaitToAnimationFinish(sleepAnimationLength));
            return true;
        }
        IEnumerator WaitToAnimationFinish(float animationLength)
        {
            gAgent.isPause = true;
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
