using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private Transform target;
    public Animator animator;
    public float damage;

    // Flags to ensure actions are only triggered once per attack cycle
    private bool isAttacking = false;
    private bool damageDealt = false;

    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
        rb.freezeRotation = true;
        speed = speed * Random.Range(0.50f, 1.5f);
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

    // This runs when the player's collider enters the detection collider.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply damage only if it hasn't been dealt during this cycle.
            if (!damageDealt)
            {
                Debug.Log("Player hit by detection collider – reducing health!");
                playerHealthController.instance.TakeDamage(damage);
                damageDealt = true; // Ensure damage is applied only once per entry.
            }

            // Trigger attack if not already in an attack sequence.
            if (!isAttacking)
            {
                Debug.Log("Player detected – selecting attack!");
                isAttacking = true;
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;

                int randomAttack = Random.Range(0, 2); // Randomly pick 0 or 1.
                animator.SetInteger("AttackIndex", randomAttack);
                Debug.Log("Selected AttackIndex: " + randomAttack);

                animator.SetBool("isAttacking", true); // Tell the Animator to switch to an attack state.
                StartCoroutine(ResetAttack());
            }
        }
    }

    // This will reset our attack/damage state after the attack animation completes.
    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(1.5f); // Adjust based on your attack animation length.
        isAttacking = false;
        rb.isKinematic = false;
        animator.SetBool("isAttacking", false);

        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > 2f)
        {
            Debug.Log("Player moved away – resuming chase!");
            animator.Play("Move"); // Switch back to move animation.
            rb.velocity = (target.position - transform.position).normalized * speed;
        }
    }

    // Use OnTriggerExit to reset the damage flag so the player can be hit again on reentry.
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damageDealt = false;
            Debug.Log("Player exited detection collider – damage reset.");
        }
    }
}











