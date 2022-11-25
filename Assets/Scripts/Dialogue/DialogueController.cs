using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private DialogueTrigger dialogueTrigger;

    private const string _isTalking = "isTalking";
    private const string _QuestCompleted = "QuestCompleted";

    private Animator dialogueNPCAnimator;
    private QuestDialogue questDialogue;

    private void Awake()
    {
        questDialogue = GetComponent<QuestDialogue>();
        dialogueNPCAnimator = dialogueTrigger.getQuestGiver.GetComponent<Animator>();

        GameEvents.FinishDialog += OnFinishDialog;
        GameEvents.QuestCompleted += OnQuestCompleted;
    }

    private void OnDestroy()
    {
        GameEvents.FinishDialog -= OnFinishDialog;
        GameEvents.QuestCompleted -= OnQuestCompleted;
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

    private void OnQuestCompleted()
    {
        dialogueNPCAnimator.SetBool(_QuestCompleted, true);
    }
}
