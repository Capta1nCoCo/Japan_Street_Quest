using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private DialogueTrigger dialogueTrigger;

    private const string _isTalking = "isTalking";

    private Animator dialogueNPCAnimator;
    private QuestDialogue questDialogue;

    private void Awake()
    {
        questDialogue = GetComponent<QuestDialogue>();
        dialogueNPCAnimator = dialogueTrigger.getQuestGiver.GetComponent<Animator>();

        GameEvents.FinishDialog += OnFinishDialog;
    }

    private void OnDestroy()
    {
        GameEvents.FinishDialog -= OnFinishDialog;
    }

    public void StartDialog()
    {
        dialogueTrigger.ShowDialogueTip(false);
        dialogueNPCAnimator.SetBool(_isTalking, true);
        questDialogue.RunDialogue();
    }

    private void OnFinishDialog()
    {
        dialogueNPCAnimator.SetBool(_isTalking, false);
    }   
}
