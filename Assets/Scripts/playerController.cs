using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
  //Movement variables
  public float maxSpeed;
  public float moveDir;
  float prevDir = 1;
  bool goingRight = true;

  //Jumping variables
  public bool grounded = true;
  public float jumpHeight;

  //Wall jump
  public bool againstWall = false;
  public checkWall wall;

  Rigidbody2D myRB;

  void Start() {
    myRB = GetComponent<Rigidbody2D>();

    moveDir = 1;
  }

  void FixedUpdate() {

    //Jump left if left button is pressed
    if (Input.GetButtonDown("Left")){
      moveDir = Movement(-1);
    }

    //Jump right if right button is pressed
    if (Input.GetButtonDown("Right")){
      moveDir = Movement(1);
    }

    //Set movement direction depending on jump
    myRB.velocity = new Vector2(moveDir*maxSpeed, myRB.velocity.y);
  }

  float Movement (float move) {
    //Check if you are jumping from the ground or wall jumping
    if (grounded){
      //Change directions and jump if they press a button
      if (move < 0 && move != 0){
        Jump(move);
        return -1;
      } else if (move != 0) {
        Jump(move);
        return 1;
      }
    } else {
      //Walljump if in the air
      if (move < 0 && againstWall && goingRight){
        Jump(move);
        return -1;
      } else if (move > 0 && againstWall && !goingRight) {
        Jump(move);
        return 1;
      }
    }
    return moveDir;
  }

  void Jump(float move){
    myRB.velocity = Vector2.up * jumpHeight;

    if (move != prevDir){
      wall.ChangeDirection();
      prevDir = move;
      goingRight = !goingRight;
    }
  }
}
