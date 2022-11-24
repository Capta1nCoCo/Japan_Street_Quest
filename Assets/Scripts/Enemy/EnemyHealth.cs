using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(EnemyAnimation))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 3;

    private int currentHitPoints;
    private bool isAlive;

    private EnemyAnimation enemyAnimation;

    private void Awake()
    {
        enemyAnimation = GetComponent<EnemyAnimation>();
        currentHitPoints = maxHitPoints;
        isAlive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAlive && other.gameObject.layer == Constants.Layers.Player)
        {
            Debug.Log("Enemy got hit!");
            currentHitPoints--;
            if (currentHitPoints <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        isAlive = false;
        enemyAnimation.Death();
    }

    // Method below is used by Animation Event
    private void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
}
