using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Skeletons
{
    public enum SkeletonType
    {
        TWOHANDSWORDSWEEPER,
        SINGLEHANDSWORDSWEEPER,
        ARCHER
    }
    public class Skeleton : GOAP_Agent
    {
        GameObject player;
        SubGoal catchPlayer;
        SubGoal searchPlayer;
        SubGoal checkSoundCameDirection;
        public SkeletonType role;
        new void Start()
        {
            base.Start();
            DecideRole();

            player = GameObject.FindGameObjectWithTag("Player");
            catchPlayer = new SubGoal("Attack", 1, false);
            searchPlayer = new SubGoal("SearchPlayer", 1, false);
            checkSoundCameDirection = new SubGoal("Check", 1, false);

            goals.Add(catchPlayer, 4);
            goals.Add(searchPlayer, 2);
            goals.Add(checkSoundCameDirection, 3);
        }
        void Update()
        {
            CurrentActionRelated();
            CurrentGoalRelated();
        }
        void CurrentActionRelated()
        {
            if (currentAction != null)
            {
                if (currentAction.GetType().Equals(typeof(AttackPlayer)) || currentAction.GetType().Equals(typeof(ShootAttack)))
                {
                    RotateTowardsPlayer();
                }
            }
        }
        void CurrentGoalRelated()
        {
            if (currentGoal == catchPlayer)
            {
                if (previousGoal == searchPlayer && isGoalChanged)
                {
                    ReturnSearchResources();
                }
            }
            if(currentGoal == checkSoundCameDirection)
            {
                if (previousGoal == searchPlayer && isGoalChanged)
                {
                    ReturnSearchResources();
                }
            }

        }
        void RotateTowardsPlayer()
        {
            Vector3 directionToPlayer = player.transform.position - transform.position;
            Quaternion desiredRot = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionToPlayer), Time.deltaTime * 1.5f);
            transform.rotation = desiredRot;
        }

        void DecideRole()
        {
            switch (role)
            {
                case SkeletonType.ARCHER:
                    animationAgent.anim.SetBool("Archer", true);
                    break;
                case SkeletonType.TWOHANDSWORDSWEEPER:
                    animationAgent.anim.SetBool("TwoHandSworder", true);
                    break;
                case SkeletonType.SINGLEHANDSWORDSWEEPER:
                    animationAgent.anim.SetBool("SingleSworder", true);
                    break;
            }
        }

        void ReturnSearchResources()
        {
            Debug.Log("Returned");
            GameObject searchPoint = inventory.FindItemWithTag("SearchPoint");
            if (searchPoint)
            {
                GOAP_World.Instance.GetResourceQueue("SearchPoint").AddResource(searchPoint);
                GOAP_World.Instance.World.ModifyState("FreeSearchPoint", 1);
                inventory.RemoveItem(searchPoint);
            }
        }
    }

}