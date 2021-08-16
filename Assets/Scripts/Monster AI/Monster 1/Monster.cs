using UnityEngine;

namespace AI.Monsters
{
    public class Monster : GOAP_Agent
    {
        GameObject player;
        [SerializeField] private GameObject chest;
        [SerializeField] private PlayerDetection pd;
        SubGoal protectChest;
        SubGoal catchPlayer;
        SubGoal blockPlayerFromExit;
        SubGoal search;
        SubGoal CheckSoundCameDirection;
        SubGoal sleep;
        new void Start()
        {
            base.Start();
            player = GameObject.FindGameObjectWithTag("Player");
            inventory.Chest = chest;

            protectChest = new SubGoal("Protect", 1, false);
            CheckSoundCameDirection = new SubGoal("Check", 1, false);
            catchPlayer = new SubGoal("Attack", 1, false);
            blockPlayerFromExit = new SubGoal("BlockPlayer", 1, false);
            search = new SubGoal("SearchPlayer", 1, false);
            sleep = new SubGoal("Sleep", 1, false);

            goals.Add(protectChest, 1);
            goals.Add(CheckSoundCameDirection, 4);
            goals.Add(catchPlayer, 5);
            goals.Add(blockPlayerFromExit, 2);
            goals.Add(search, 3);
            goals.Add(sleep, 6);
            beliefs.SetState("HavingKey", 1);

        }

        void Update()
        {
            ExtraStuffs();
        }

        void ExtraStuffs()
        {
            CurrentGoalRelated();
            CurrentActionRelated();
        }

        void CurrentActionRelated()
        {
            if (currentAction != null)
            {
                if (currentAction.GetType().Equals(typeof(ChasePlayer)))
                {
                    float distanceToPlayer = Vector3.Distance(transform.position, currentAction.target.transform.position);
                    if (distanceToPlayer > 6 && distanceToPlayer < 10 && pd.playerVisibled && !beliefs.HasState("ReadyToShoot"))
                    {
                        beliefs.SetState("ReadyToShoot", 1);
                        animationAgent.anim.SetBool("Run", false);
                        currentAction.skipImmediate = true;
                    }
                }
                else if (currentAction.GetType().Equals(typeof(AttackPlayer)) || currentAction.GetType().Equals(typeof(ShootAttack)))
                {
                    RotateTowardsPlayer();
                }
                else
                {
                    return;
                }
            }
        }
        void CurrentGoalRelated()
        {
            if (currentGoal == catchPlayer)
            {
                if (previousGoal == protectChest && isGoalChanged)
                {
                    beliefs.RemoveState("AtChestPlace");
                    beliefs.RemoveState("KeyIsAtPlace");
                }
                else if (previousGoal == blockPlayerFromExit && isGoalChanged)
                {
                    BlockPlayer_GoalResource();
                }
                else if (previousGoal == search && isGoalChanged)
                {
                    beliefs.RemoveState("GotoSearchForPlayer");
                    GameObject searchPoint = inventory.FindItemWithTag("SearchPoint");
                    if (searchPoint != null)
                    {
                        GOAP_World.Instance.GetResourceQueue("SearchPoint").AddResource(searchPoint);
                        GOAP_World.Instance.World.ModifyState("FreeSearchPoint", -1);
                        inventory.RemoveItem(searchPoint);
                    }
                }
                else if(previousGoal == CheckSoundCameDirection && isGoalChanged)
                {
                    beliefs.RemoveState("TurnToSoundDirection");
                }
            }
            else if (currentGoal == blockPlayerFromExit)
            {
                if (previousGoal == protectChest && isGoalChanged)
                {
                    beliefs.RemoveState("AtChestPlace");
                }
            }
            else if (currentGoal == search)
            {
                if (previousGoal == blockPlayerFromExit && isGoalChanged)
                {
                    BlockPlayer_GoalResource();
                }
            }
            else if(currentGoal == CheckSoundCameDirection)
            {
                if(previousGoal == protectChest && isGoalChanged)
                {
                    beliefs.RemoveState("AtChestPlace");
                    beliefs.RemoveState("KeyIsAtPlace");
                }
                if(previousGoal == search && isGoalChanged)
                {
                    ReturnSearchResources();
                }
            }
            else if(currentGoal == sleep)
            {
                if(previousGoal == catchPlayer && isGoalChanged)
                {
                    GameObject player = inventory.FindItemWithTag("Player");
                    if (player)
                    {
                        beliefs.RemoveState("PlayerVisibled");
                        beliefs.RemoveState("PlayerIsDetected");
                        beliefs.RemoveState("ChasedPlayer");
                        inventory.RemoveItem(player);
                        if (gameObject.CompareTag("ChasingPlayer"))
                        {
                            gameObject.tag = "Monster";
                        }
                    }
                }
                else if(previousGoal == CheckSoundCameDirection && isGoalChanged)
                {
                    beliefs.RemoveState("SoundHeard");
                    GameObject obj = inventory.items[inventory.RecentlyAddedIndex - 1];
                    if(obj != null)
                    {
                        inventory.RemoveItem(obj);
                    }
                }
            }
        }
        void BlockPlayer_GoalResource()
        {
            beliefs.RemoveState("AtExitDoorArea");
            GameObject exitDoorArea = inventory.FindItemWithTag("ExitDoor") != null ? inventory.FindItemWithTag("ExitDoor") : inventory.FindItemWithTag("ExitDoorCover");
            if (exitDoorArea != null)
            {
                string tag = exitDoorArea.tag;
                GOAP_World.Instance.GetResourceQueue(tag).AddResource(exitDoorArea);
                inventory.RemoveItem(exitDoorArea);
                GOAP_World.Instance.World.ModifyState("Free" + tag, -1);
            }
        }
        void RotateTowardsPlayer()
        {
            Vector3 directionToPlayer = player.transform.position - transform.position;
            Quaternion desiredRot = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(directionToPlayer), Time.deltaTime * 150f);
            transform.rotation = desiredRot;
        }
        void ReturnSearchResources()
        {
            GameObject searchPoint = inventory.FindItemWithTag("SearchPoint");
            if (searchPoint)
            {
                GOAP_World.Instance.GetResourceQueue("SearchPoint").AddResource(searchPoint);
                GOAP_World.Instance.World.ModifyState("FreeSearchPoint", 1);
                inventory.RemoveItem(searchPoint);
            }
        }

        public void AnimationRotateRight()
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 90f, transform.localEulerAngles.z);
        }
        public void AnimationRotateLeft()
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y - 90f, transform.localEulerAngles.z);
        }
    }
}
