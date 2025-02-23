using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float FollowSpeed = 2f;
    public Transform target;
    public int offset = 4;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + offset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }
}
