using UnityEngine;
namespace AI.Rat 
{
    public class Rat : GOAP_Agent
    {
        SubGoal eatCheese;
        SubGoal askGoal;
        SubGoal DoGoal;
        SubGoal moveOutFromPlayer;
        SubGoal hideOut;
        new void Start()
        {
            base.Start();

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject exitDoor = GameObject.FindGameObjectWithTag("ExitDoor");
            GameObject monsterArea = GameObject.FindGameObjectWithTag("MonsterArea");
            if(monsterArea != null)
            {
                inventory.AddItem(monsterArea);
            }
            if(exitDoor != null)
            {
                inventory.AddItem(exitDoor);
            }
            if(player != null)
            {
                inventory.AddItem(player);
            }
            eatCheese = new SubGoal("EatCheese", 1, true);
            askGoal = new SubGoal("AskGoal", 1, true);
            moveOutFromPlayer = new SubGoal("MoveOut", 1, true);
            DoGoal = new SubGoal("DoneGoal", 1, false);
            hideOut = new SubGoal("HideOut", 1, true);

            goals.Add(eatCheese, 1);
            goals.Add(askGoal, 2);
            goals.Add(moveOutFromPlayer, 3);
            goals.Add(DoGoal, 4);
            goals.Add(hideOut, 3);
        }
    }
}
