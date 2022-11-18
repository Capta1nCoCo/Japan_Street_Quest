using UnityEngine;

public class DialogController : MonoBehaviour
{
    [SerializeField] private DialogTrigger dialogTrigger;

    private Animator dialogNPCAnimator;

    public void StartDialog()
    {
        dialogNPCAnimator = dialogTrigger.getQuestGiver.GetComponent<Animator>();
        dialogTrigger.ShowDialogTip(false);
        dialogNPCAnimator.SetBool("isTalking", true);
    }
}
