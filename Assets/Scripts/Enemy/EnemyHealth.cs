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
        if (isAlive && other.gameObject.layer == Constants.Layers.PlayersHitCollider)
        {
            currentHitPoints--;
            if (currentHitPoints <= 0)
            {
                Die();
            }
            else
            {
                enemyAnimation.HitReaction();
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
        GameEvents.UpdateQuestProgress();
        gameObject.SetActive(false);
    }
}
