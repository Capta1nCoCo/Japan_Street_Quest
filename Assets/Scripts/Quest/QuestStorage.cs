using UnityEngine;

public class QuestStorage : MonoBehaviour
{
    public static QuestStorage Instance;

    [SerializeField] private QuestData[] questDataStorage;

    private void Awake()
    {
        Instance = this;
    }

    public QuestData[] getQuestDataStorage { get { return questDataStorage; } }
}
