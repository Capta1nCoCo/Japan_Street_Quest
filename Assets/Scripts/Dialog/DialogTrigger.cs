using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DialogTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == Constants.Layers.Player)
        {
            Debug.Log("Press E to start dialog!");
        }
    }
}
