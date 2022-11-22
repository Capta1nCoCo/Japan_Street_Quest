using UnityEngine;

[CreateAssetMenu(fileName = "QuestData", menuName = "Quest/QuestData", order = 2)]
public class QuestData : ScriptableObject
{
    [SerializeField] private string questName;
    [SerializeField] private int requiredItemsNum;

    public string getQuestName { get { return questName; } }
    public int getRequiredItemsNum { get { return requiredItemsNum; } }
}
