using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private RectTransform dialogueTip;
    [SerializeField] private Transform questGiver;

    private StarterAssets.StarterAssetsInputs assetsInputs;

    private void Awake()
    {
        assetsInputs = FindObjectOfType<StarterAssets.StarterAssetsInputs>();
        dialogueTip.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnableDialogueInteraction(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        EnableDialogueInteraction(other, false);
    }

    private void EnableDialogueInteraction(Collider other, bool active)
    {
        if (other.gameObject.layer == Constants.Layers.Player)
        {
            ShowDialogueTip(active);
        }
    }

    public void ShowDialogueTip(bool active)
    {
        dialogueTip.gameObject.SetActive(active);
        SetInteractionTarget(active);
    }

    private void SetInteractionTarget(bool active)
    {
        assetsInputs.interactionIsPossible = active;
        assetsInputs.target = active ? questGiver : null;
    }

    public Transform getQuestGiver { get { return questGiver; } }
}
