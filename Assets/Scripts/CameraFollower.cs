using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed=0.125f;//higher this value is our camera will faster move
    public Vector3 offset;
    void LateUpdate()
    {
      //for every frame we get the position that we want to snap to, Vector3.Lerp to get closer to snap position how much closer we get depends on smoothSpeed and
      //multiply with Time.deltatime to smoothing occurs at the same speed no matter frame rate is.
        
        Vector3 desired_position = target.position + offset;
        Vector3 smoothedPosition= Vector3.Lerp(transform.position, desired_position, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target);

    }
}
