using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - target.position; //We are getting the distance in 3D Vector. Basically a line from point A to point B
    }

    private void LateUpdate() //Use for camera movement. Called every frame if the behavior is enabled
    {
        transform.position = target.position + offset; //Remember the offset is the diagnol line we created on awake.
    }
}
