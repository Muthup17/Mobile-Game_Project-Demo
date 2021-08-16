using UnityEngine;

[System.Serializable]
public class LearnItem
{
    public string name;
    public bool value;
}
[CreateAssetMenu(menuName = "Learn/UserLearn", fileName = "Create LearnItem", order = 8)]
public class LearnedItems : ScriptableObject
{
    public LearnItem[] learnItems;
}
