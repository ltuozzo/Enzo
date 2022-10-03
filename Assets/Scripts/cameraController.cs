using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
  public Transform target; //What camera is following
  public float smoothing;

  Vector3 offset; //Difference between the camara and the target

  float lowY;

  void Start(){
    offset = transform.position - target.position;

    //Lowest the camara will go.
    lowY = transform.position.y;
  }

  void FixedUpdate(){
    Vector3 targetCamPos = target.position + offset;

    transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing*Time.deltaTime);

    if(transform.position.y < lowY){
      transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
    }
  }
}
