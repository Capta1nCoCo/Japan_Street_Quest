using System.Collections;
using UnityEngine;
using TMPro;

public class QuestDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueWindow;
    [SerializeField] private DialogueScript[] textScripts;

    private string[] questDialog;

    private int questIndex = 0;
    private float delayInSeconds = 3f;

    private bool initialDialog;
    private bool questObjectiveCompleted;

    private void Awake()
    {
        dialogueWindow.gameObject.SetActive(false);
        initialDialog = true;

        GameEvents.QuestObjectiveCompleted += OnQuestObjectiveCompleted;
    }

    private void OnDestroy()
    {
        GameEvents.QuestObjectiveCompleted -= OnQuestObjectiveCompleted;
    }

    public void RunDialogue()
    {
        questDialog = textScripts[questIndex].getLines;
        if (initialDialog)
        {
            initialDialog = false;
            StartCoroutine(ShowDialogueLinesWithDelay());
        }
        else if (questObjectiveCompleted)
        {
            StartCoroutine(ShowLineWithDelay(textScripts[questIndex].getQuestRewardLine));
            GameEvents.QuestCompleted();
        }
        else
        {
            StartCoroutine(ShowLineWithDelay(questDialog[questDialog.Length - 1]));
        }
    }

    private IEnumerator ShowDialogueLinesWithDelay()
    {
        dialogueWindow.gameObject.SetActive(true);
        for (int i = 0; i < questDialog.Length; i++)
        {
            dialogueWindow.text = questDialog[i];
            yield return new WaitForSeconds(delayInSeconds);
        }
        dialogueWindow.gameObject.SetActive(false);
        GameEvents.FinishDialog();
        GameEvents.QuestAccepted();
    }

    private IEnumerator ShowLineWithDelay(string line)
    {
        dialogueWindow.gameObject.SetActive(true);
        dialogueWindow.text = line;
        yield return new WaitForSeconds(delayInSeconds);
        dialogueWindow.gameObject.SetActive(false);
        GameEvents.FinishDialog();
    }

    private void OnQuestObjectiveCompleted()
    {
        questObjectiveCompleted = true;
    }
}
