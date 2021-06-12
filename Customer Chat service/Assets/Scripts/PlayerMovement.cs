using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    public float groundDistance = 0f;
    public LayerMask WhatIsGround;
    public float speed = 5f;

    public CharacterController controller;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", v);
        animator.SetFloat("TurningSpeed", h);

        Vector3 direction = new Vector3(h, 0f, v).normalized;

        if (direction.magnitude > 0.1f)
        {
            float targetAngel = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angal = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angal, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, angal, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);


        }


        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, groundDistance, WhatIsGround))
        {
            animator.SetBool("grounded", true);
            animator.applyRootMotion = true;
        }

        else
        {
            animator.SetBool("grounded", false);
        }
    }
}
