using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyAnimation))]
public class EnemyAI : MonoBehaviour
{
    private Vector3 startingPoint;

    private bool isEngaging;

    private StarterAssets.ThirdPersonController player;
    private NavMeshAgent navMeshAgent;
    private EnemyAnimation enemyAnimation;

    private void Awake()
    {
        player = FindObjectOfType<StarterAssets.ThirdPersonController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimation = GetComponent<EnemyAnimation>();

        startingPoint = transform.position;
    }

    private void Update()
    {
        EngagePlayer();
    }

    public void MoveTowardsPlayer()
    {
        isEngaging = true;
    }

    public void MoveToStartingPoint()
    {
        isEngaging = false;
        navMeshAgent.SetDestination(startingPoint);
        enemyAnimation.Attack(false);
        enemyAnimation.Walk(false);
    }

    private void EngagePlayer()
    {
        if (isEngaging)
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            if (distanceToPlayer <= navMeshAgent.stoppingDistance)
            {
                AttackPlayer();
            }
            else
            {
                ChasePlayer();
            }
        }
    }

    private void AttackPlayer()
    {
        transform.LookAt(player.transform.position);
        enemyAnimation.Attack(true);
    }

    private void ChasePlayer()
    {
        navMeshAgent.SetDestination(player.transform.position);
        enemyAnimation.Walk(true);
    }

    // Methods below are used by Animation Envents
    private void StopMovement()
    {
        navMeshAgent.isStopped = true;
    }

    private void ResumeMovement()
    {
        enemyAnimation.Attack(false);
        navMeshAgent.isStopped = false;
    }

    private void StopAllActions()
    {
        isEngaging = false;
    }
}
