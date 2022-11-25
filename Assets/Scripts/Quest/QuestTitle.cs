using System.Collections;
using UnityEngine;
using TMPro;

public class QuestTitle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private QuestProgress questInProgress;
    [SerializeField] private GameObject questItems;

    private int questIndex = 0;
    private float delayInSeconds = 2f;

    private void Awake()
    {
        titleText.gameObject.SetActive(false);
        questInProgress.gameObject.SetActive(false);
        questItems.SetActive(false);

        GameEvents.QuestAccepted += OnQuestAccepted;
    }

    private void OnDestroy()
    {
        GameEvents.QuestAccepted -= OnQuestAccepted;
    }

    private void OnQuestAccepted()
    {
        titleText.text = QuestStorage.Instance.getQuestDataStorage[questIndex].getQuestName;
        StartCoroutine(ShowQuestTitle());
    }

    private IEnumerator ShowQuestTitle()
    {
        titleText.gameObject.SetActive(true);
        yield return new WaitForSeconds(delayInSeconds);
        titleText.gameObject.SetActive(false);
        questInProgress.gameObject.SetActive(true);
        questItems.SetActive(true);
    }
}
