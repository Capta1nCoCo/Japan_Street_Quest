using System.Collections;
using UnityEngine;
using TMPro;

public class QuestDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueWindow;
    [SerializeField] private DialogueScript[] textScripts;

    private string[] questDialog;

    private float delayInSeconds = 3f;

    private void Awake()
    {
        dialogueWindow.gameObject.SetActive(false);
    }

    public void RunDialogue()
    {
        questDialog = textScripts[0].getLines;
        StartCoroutine(ShowDialogueLinesWithDelay());
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
    }
}
