using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour{

    public int playerspeed = 5;
    public bool facingRight = true;
    public int playerjumppower = 100;
    public float moveX;
    private bool isGrounded;
    private Rigidbody2D rb;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask WhatIsGround;
    private int extraJumps;
    public int extraJumpsValue;


    void start(){
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }



    void Update() {
        playerMove();
        
        if(isGrounded == true){
            extraJumps = 2;

        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0){
            rb.velocity = Vector2.up * playerjumppower;
            extraJumps--;
        } else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true){
            rb.velocity = Vector2.up * playerjumppower;
        }
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, WhatIsGround);
    }

    
    void playerMove() {
        moveX = Input.GetAxis("Horizontal");
        if (moveX < 0.0f && facingRight == true) {
            FlipPlayer();
        }else if (moveX > 0.0f && facingRight == false) {
            FlipPlayer();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerspeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void FlipPlayer() {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    
}

        
    
