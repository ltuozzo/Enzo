using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkWall : MonoBehaviour
{
  private playerController player;
  public Transform target;
  float offset = 0.45f; //Distance to border of sprite

  void Start(){
    player = gameObject.GetComponentInParent<playerController>();
  }

  void OnTriggerEnter2D(Collider2D col){
    player.againstWall = true;
  }

  void OnTriggerExit2D(Collider2D col){
    player.againstWall = false;
  }

  public void ChangeDirection(){
    offset = -offset;
    transform.position = new Vector3 (target.position.x + offset, target.position.y, target.position.z);
  }
}
