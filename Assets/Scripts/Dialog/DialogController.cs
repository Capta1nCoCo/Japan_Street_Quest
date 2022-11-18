using UnityEngine;
using TMPro;

public class DialogController : MonoBehaviour
{
    [SerializeField] private DialogTrigger dialogTrigger;
    [SerializeField] private TextMeshProUGUI dialogTextWindow;

    private Animator dialogNPCAnimator;

    private void Awake()
    {
        dialogTextWindow.gameObject.SetActive(false);
    }

    public void StartDialog()
    {
        dialogNPCAnimator = dialogTrigger.getQuestGiver.GetComponent<Animator>();
        dialogTrigger.ShowDialogTip(false);
        dialogNPCAnimator.SetBool("isTalking", true);
        dialogTextWindow.gameObject.SetActive(true);
    }
}
