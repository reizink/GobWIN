using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    Vector3 direction;
    Vector3 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        direction = transform.position - previousPosition;

        if (Mathf.Abs(direction.z) > Mathf.Abs(direction.x))
        {
            if (animator.GetBool("IsWalkingLeft") || animator.GetBool("IsWalkingRight"))
            {
                animator.SetBool("IsWalkingRight", false);
                animator.SetBool("IsWalkingLeft", false);
            }
            if (direction.z > 0)
            {
                animator.SetBool("IsWalkingUp", true);
                if (animator.GetBool("IsWalkingDown"))
                {
                    animator.SetBool("IsWalkingDown", false);
                }
            }
            else if (direction.z < 0)
            {
                animator.SetBool("IsWalkingDown", true);
                if (animator.GetBool("IsWalkingUp"))
                {
                    animator.SetBool("IsWalkingUp", false);
                }
            }
        }
        else if (Mathf.Abs(direction.z) < Mathf.Abs(direction.x))
        {
            if (animator.GetBool("IsWalkingUp") || animator.GetBool("IsWalkingDown"))
            {
                animator.SetBool("IsWalkingUp", false);
                animator.SetBool("IsWalkingDown", false);
            }
            if (direction.x > 0)
            {
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
                animator.SetBool("IsWalkingRight", true);
                if (animator.GetBool("IsWalkingLeft"))
                {
                    animator.SetBool("IsWalkingLeft", false);
                }
            }
            else if (direction.x < 0)
            {
                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
                animator.SetBool("IsWalkingLeft", true);
                if (animator.GetBool("IsWalkingRight"))
                {
                    animator.SetBool("IsWalkingRight", false);
                }
            }
        }
        else
        {
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingLeft", false);
            animator.SetBool("IsWalkingUp", false);
            animator.SetBool("IsWalkingDown", false);
        }
        previousPosition = transform.position;
    }
    public void AttackingAnimation(Vector3 direction)
    {
        print(direction);
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
        {
            if(direction.x > 0)
            {
                animator.SetBool("IsAttackingRight", true);
            }
            if(direction.x < 0)
            {
                animator.SetBool("IsAttackingLeft", true);
            }
        }
        if (Mathf.Abs(direction.x) < Mathf.Abs(direction.z))
        {
            if(direction.z > 0)
            {
                animator.SetBool("IsAttacking", true);
            }
            if(direction.z< 0)
            {
                animator.SetBool("IsAttackingDown", true);
            }
        }
    }
    public void CancelAttack()
    {
        animator.SetBool("IsAttackingDown", false);
        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsAttackingLeft", false);
        animator.SetBool("IsAttackingRight", false);

    }
}
    

