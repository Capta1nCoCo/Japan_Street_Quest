using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private RectTransform dialogTip;

    private void Awake()
    {
        dialogTip.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        ShowDialogTip(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        ShowDialogTip(other, false);
    }

    private void ShowDialogTip(Collider other, bool active)
    {
        if (other.gameObject.layer == Constants.Layers.Player)
        {
            dialogTip.gameObject.SetActive(active);
        }
    }
}
