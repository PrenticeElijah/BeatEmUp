using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float move_speed = 0.075f;
    
    public bool facing_right = true;

    Rigidbody2D rigid;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();    // Get the 2D Rigidbody attached to the player
    }

    // Update is called once per frame
    void Update()
    {
        // Call to move the player
        PlayerMovement();
    }

    // Moving the player
    void PlayerMovement()
    {
        // GetAxis is based on sensitivity, so the returned value is within a range between -1 and 1
        // Using GetAxisRaw instead of GetAxis to only return 1, 0, or -1
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            
            // Call to flip the player if the player if:
            // facing right while moving left or facing left while moving right
            if (((facing_right == true) && (Input.GetAxisRaw("Horizontal") == -1))
            || ((facing_right == false) && (Input.GetAxisRaw("Horizontal") == 1))) {
                FlipPlayer();
            }

            // Move the player horizontally
            rigid.MovePosition(new Vector2(transform.position.x + (move_speed * Input.GetAxisRaw("Horizontal")), transform.position.y));
        }
    }

    void FlipPlayer()
    {
        // Player now faces the opposite direction
        facing_right = !facing_right;

        // Flip the Player object
        this.gameObject.transform.localScale = new Vector2(-transform.localScale.x,transform.localScale.y);
    }
}