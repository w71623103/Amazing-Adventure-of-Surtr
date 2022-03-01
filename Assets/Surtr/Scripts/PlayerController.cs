using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    public PlayerModel model;

    public PlayerController(PlayerModel newMod)
    {
        model = newMod;
    }

    //control player sprite facing left/right
    public void scaleControl()
    {
        if (model.attackState == model.atkStateDefault)
        {
            if (model.horizontalMovement < 0)
                model.isLeft = true;
            else if (model.horizontalMovement > 0)
                model.isLeft = false;
        }
        
    }

    public void hMovement()
    {
        model.playerRB.velocity = new Vector2(model.horizontalMovement, model.playerRB.velocity.y);
    }

    //control jump
    public void Jump()
    {
        //jump action has a CD, makes it only able to jump once per 0.5 second
        if (model.jumpTimer < 0)
        {
            if (Input.GetKey(KeyCode.K) && model.isGrounded && !Input.GetKey(KeyCode.S)) //on the ground and get the input
            {
                model.jumpTimer = model.jumpCD; //reset timer
                
                model.playerRB.AddForce(new Vector2(0, model.jumpSpeed), ForceMode2D.Impulse); //jump
            }
            else if (Input.GetKey(KeyCode.K) && model.isGrounded && Input.GetKey(KeyCode.S)) //on the ground and get the input
            {
                model.jumpTimer = model.jumpCD * 0.1f; //reset timer with a very minimum time

                model.playerRB.AddForce(new Vector2(0, model.jumpSpeed * 0.3f), ForceMode2D.Impulse); //jump with a very small force
            }
        }

    }
}
