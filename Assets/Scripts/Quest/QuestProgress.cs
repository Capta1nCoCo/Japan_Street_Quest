using UnityEngine;
using TMPro;

public class QuestProgress : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questName;
    [SerializeField] private TextMeshProUGUI progressConuter;

    private QuestData currentQuestData;
    private string currentQuestName;
    private int requiredItems;
    private int currentItems;

    private void OnEnable()
    {
        GetQuestData();
        UpdateQuestName();
        UpdateCounter();
    }

    private void GetQuestData()
    {
        currentQuestData = QuestStorage.Instance.getQuestDataStorage[0];
        currentQuestName = currentQuestData.getQuestName;
        requiredItems = currentQuestData.getRequiredItemsNum;
    }

    private void UpdateQuestName()
    {
        questName.text = currentQuestName;
    }

    private void UpdateCounter()
    {
        progressConuter.text = currentItems + "/" + requiredItems;
    }
}
