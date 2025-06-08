using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private Transform target;
    public Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (!isAttacking)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isAttacking)
        {
            //bug.Log("Player detected – selecting attack!");
            isAttacking = true;

            rb.velocity = Vector3.zero;
            rb.isKinematic = true;

            int randomAttack = Random.Range(0, 2); // Pick attack type first
            animator.SetInteger("AttackIndex", randomAttack); // Set animation index
            //bug.Log("Selected AttackIndex: " + randomAttack); // Debugging

            animator.SetBool("isAttacking", true); // Set attacking state AFTER index
            StartCoroutine(ResetAttack());
        }
    }


    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(1.5f); // Adjust based on animation length
        isAttacking = false;

        rb.isKinematic = false;
        animator.SetBool("isAttacking", false); // Transition back to Move state

        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > 2f)
        {
            Debug.Log("Player moved away – resuming chase!");
            animator.Play("Move"); // Manually force Move animation
            rb.velocity = (target.position - transform.position).normalized * speed;
        }
    }
}









