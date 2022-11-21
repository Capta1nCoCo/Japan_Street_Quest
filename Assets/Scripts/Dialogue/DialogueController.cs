using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private DialogueTrigger dialogueTrigger;

    private Animator dialogueNPCAnimator;
    private QuestDialogue questDialogue;

    private void Awake()
    {
        questDialogue = GetComponent<QuestDialogue>();
    }

    public void StartDialog()
    {
        dialogueNPCAnimator = dialogueTrigger.getQuestGiver.GetComponent<Animator>();
        dialogueTrigger.ShowDialogueTip(false);
        dialogueNPCAnimator.SetBool("isTalking", true);
        questDialogue.RunDialogue();
    }
}
