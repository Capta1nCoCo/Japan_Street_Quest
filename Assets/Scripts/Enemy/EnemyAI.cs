using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    private const string _isAttacking = "isAttacking";
    private const string _isWalking = "isWalking";

    private Vector3 startingPoint;

    private bool isEngaging;

    private StarterAssets.ThirdPersonController player;
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private void Awake()
    {
        player = FindObjectOfType<StarterAssets.ThirdPersonController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

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
        animator.SetBool(_isAttacking, false);
        animator.SetBool(_isWalking, false);
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
        animator.SetBool(_isAttacking, true);
    }

    private void ChasePlayer()
    {
        navMeshAgent.SetDestination(player.transform.position);
        animator.SetBool(_isWalking, true);
    }

    // Methods below are used by Animation Envents
    private void StopMovement()
    {
        navMeshAgent.isStopped = true;
    }

    private void ResumeMovement()
    {
        animator.SetBool(_isAttacking, false);
        navMeshAgent.isStopped = false;
    }
}
