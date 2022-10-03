using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpModifier : MonoBehaviour
{

  public float fallMultiplier = 2.5f;
  //Commented code is to add a small if player releases jump button early.
  public float lowJumpMultiplier = 2f;

  Rigidbody2D rb;

  void Awake(){
    rb = GetComponent<Rigidbody2D>();
  }

  void Update(){
    if (rb.velocity.y < 0) {
      rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    } else if (rb.velocity.y > 0 && !Input.GetButton("Left") && !Input.GetButton("Right")){
      rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }
  }
}
