using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimpleMovement : MonoBehaviour
{

    Transform playerPosition;
    [SerializeField] float speed = 2f;
    [SerializeField] Animator animator;
    [SerializeField] float minDistance;
    Rigidbody rb;
    public bool triggered = false;
    public bool isAttacking = false;

    private void Start()
    {
        playerPosition = PlayerManager.Instance.transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        checkDistance();
        
        if (triggered)
        {
            if(!isAttacking) ApplyMovement();
            ApplyRotation();
        }
        
    }

    void checkDistance()
    {
        float distance = Vector3.Distance(playerPosition.position, transform.position);
        if (distance <= minDistance) triggered = true;
    }

    void ApplyRotation()
    {
        transform.LookAt(playerPosition);
    }

    void ApplyMovement()
    {
        animator.SetFloat("Speed", speed);
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime); ;
    }

    public void setTriggered() { triggered = true;  }

}
