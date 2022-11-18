using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private RectTransform dialogTip;
    [SerializeField] private Transform questGiver;

    private StarterAssets.StarterAssetsInputs assetsInputs;

    private void Awake()
    {
        dialogTip.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnableDialogInteraction(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        EnableDialogInteraction(other, false);
    }

    private void EnableDialogInteraction(Collider other, bool active)
    {
        if (other.gameObject.layer == Constants.Layers.Player)
        {
            CachePlayerInputs(other);
            ShowDialogTip(active);
        }
    }

    private void CachePlayerInputs(Collider other)
    {
        if (assetsInputs == null)
        {
            assetsInputs = other.GetComponent<StarterAssets.StarterAssetsInputs>();
        }
    }

    public void ShowDialogTip(bool active)
    {
        dialogTip.gameObject.SetActive(active);
        SetInteractionTarget(active);
    }

    private void SetInteractionTarget(bool active)
    {
        assetsInputs.interactionIsPossible = active;
        assetsInputs.target = active ? questGiver : null;
    }

    public Transform getQuestGiver { get { return questGiver; } }
}
