using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyZone : MonoBehaviour
{
    [SerializeField] private EnemyAI enemy;

    private void OnTriggerEnter(Collider other)
    {
        ProvokeEnemy(other);
    }

    private void OnTriggerExit(Collider other)
    {
        SuppressEnemy(other);
    }

    private void ProvokeEnemy(Collider other)
    {
        if (other.gameObject.layer == Constants.Layers.Player)
        {
            enemy.MoveTowardsPlayer();
        }
    }

    private void SuppressEnemy(Collider other)
    {
        if (other.gameObject.layer == Constants.Layers.Player)
        {
            enemy.MoveToStartingPoint();
        }
    }
}
