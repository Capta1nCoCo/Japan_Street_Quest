using System.Collections;
using UnityEngine;
using TMPro;

public class QuestTitle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private QuestProgress questInProgress;

    private float delayInSeconds = 2f;

    private void Awake()
    {
        titleText.gameObject.SetActive(false);

        GameEvents.FinishDialog += OnFinishDialog;
    }

    private void OnDestroy()
    {
        GameEvents.FinishDialog -= OnFinishDialog;
    }

    private void OnFinishDialog()
    {
        titleText.text = QuestStorage.Instance.getQuestDataStorage[0].getQuestName;
        StartCoroutine(ShowQuestTitle());
    }

    private IEnumerator ShowQuestTitle()
    {
        titleText.gameObject.SetActive(true);
        yield return new WaitForSeconds(delayInSeconds);
        titleText.gameObject.SetActive(false);
        questInProgress.gameObject.SetActive(true);
    }
}
