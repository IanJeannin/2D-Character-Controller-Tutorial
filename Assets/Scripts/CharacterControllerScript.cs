﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour {

    public float maxSpeed = 10;
    private bool facingRight = true;
    private bool isOnGround;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    Animator anim;



	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.position,groundRadius,whatIsGround);
        anim.SetBool("Ground", isOnGround);

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if(move>0&&!facingRight)
        {
            Flip();
        }
        if(move<0&&facingRight)
        {
            Flip();
        }
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
