using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public float speed = 30.0f;

    private Rigidbody2D rb;

    private Vector2 moveAmount;


    private Animator anim;
    private bool animAvail;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 0.0f;

        anim = GetComponent<Animator>();
        animAvail = anim != null;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoveAmount();
        if (animAvail)
            UpdateMoveAnim();
    }

    void UpdateMoveAmount()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;
    }

    void UpdateMoveAnim()
    {
        if (moveAmount != Vector2.zero)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
}
