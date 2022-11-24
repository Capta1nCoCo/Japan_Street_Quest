using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    private const string _isAttacking = "isAttacking";
    private const string _isWalking = "isWalking";
    private const string _Death = "Death";

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Walk(bool isActive)
    {
        animator.SetBool(_isWalking, isActive);
    }

    public void Attack(bool isActive)
    {
        animator.SetBool(_isAttacking, isActive);
    }

    public void Death()
    {
        animator.SetTrigger(_Death);
    }
}
