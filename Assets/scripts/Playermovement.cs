using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour{

    public int playerspeed = 10;
    public bool facingRight = true;
    public int playerjumppower = 1250;
    public float moveX;

    void Update() {
        playerMove();
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

    void Jump() {

    }

    void FlipPlayer() {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
        
    
