using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyZone : MonoBehaviour
{
    [SerializeField] private EnemyAI enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Constants.Layers.Player)
        {
            enemy.MoveTowardsPlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == Constants.Layers.Player)
        {
            enemy.MoveToStartingPoint();
        }
    }
}
