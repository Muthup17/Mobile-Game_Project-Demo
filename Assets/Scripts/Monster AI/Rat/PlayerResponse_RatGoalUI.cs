using AI.Rat;
using UnityEngine;

public class PlayerResponse_RatGoalUI : MonoBehaviour
{
    bool isAsk;
    GOAP_Agent gRat;
    private void Awake()
    {
        WaitToPlayerResponse.OnRatAskingGoal += Ask;
        WaitToPlayerResponse.OnRatEndAskingGoal += EndAsk;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAsk)
        {
            transform.position = Camera.main.WorldToScreenPoint(gRat.transform.position);
        }
    }

    void Ask(GOAP_Agent rat)
    {
        isAsk = true;
        gameObject.SetActive(true);
        gRat = rat;
    }
    void EndAsk()
    {
        isAsk = false;
        gameObject.SetActive(false);
        gRat = null;
    }

    public void OnExitDoorButtonClicked()
    {
        gRat.beliefs.SetState("GoToExitDoor", 1);
        gRat.beliefs.SetState("HasGoal", 1);
        gRat.beliefs.RemoveState("AskGoalToPlayer");
        gRat.currentAction.skipImmediate = true;
        EndAsk();
    }
    public void OnMonsterAreaButtonClicked()
    {
        gRat.beliefs.SetState("GoToMonsterArea", 1);
        gRat.beliefs.SetState("HasGoal", 1);
        gRat.beliefs.RemoveState("AskGoalToPlayer");
        gRat.currentAction.skipImmediate = true;
        EndAsk();
    }
    private void OnDestroy()
    {
        WaitToPlayerResponse.OnRatAskingGoal -= Ask;
        WaitToPlayerResponse.OnRatEndAskingGoal -= EndAsk;
    }
}
