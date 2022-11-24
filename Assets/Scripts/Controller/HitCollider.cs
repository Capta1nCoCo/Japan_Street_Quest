using UnityEngine;

public class HitCollider : MonoBehaviour
{
    [SerializeField] private BoxCollider hitCollider;

    private void Awake()
    {
        DisableHitCollider();
    }

    // Methods below are used by Animation Events
    private void EnableHitCollider()
    {
        hitCollider.gameObject.SetActive(true);
    }

    private void DisableHitCollider()
    {
        hitCollider.gameObject.SetActive(false);
    }
}
