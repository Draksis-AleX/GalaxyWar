using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshMovement : MonoBehaviour
{

    Vector3 playerPosition;
    public NavMeshAgent agent;
    [SerializeField] Animator animator;
    public bool triggered;
    [SerializeField] int minDistance = 10;
    public bool isAttacking;

    private void Start()
    {
        isAttacking = false;
        triggered = false;
    }

    private void Update()
    {

        playerPosition = PlayerManager.Instance.gameObject.transform.GetChild(0).transform.position;
        if (!triggered) checkDistance();

        if (triggered && !isAttacking)
        {
            agent.SetDestination(playerPosition);
            animator.SetFloat("Speed", agent.speed);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }

    void checkDistance()
    {
        float distance = Vector3.Distance(playerPosition, transform.position);
        //Debug.Log("Distance: " + distance);
        if (distance <= minDistance) triggered = true;
    }
}