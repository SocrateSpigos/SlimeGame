using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    private float distance;
    private Vector3 direction;
    public Transform target;
    public float speedMult;
    
    void Start()
    {
        //Distance away from player you want to be at.
        distance = (this.transform.position - target.position).magnitude;
        //Direction from the player you want to  be at.
        direction = (this.transform.position - target.position).normalized;
    }

    void Update()
    {

        //distance * direction; scales the unit vector to a constant size of distance behind the player.
        Vector3 targetPosition = target.position + distance * direction;
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, targetPosition.x, Time.deltaTime * speedMult),
            targetPosition.y,
            Mathf.Lerp(transform.position.z, targetPosition.z, Time.deltaTime * speedMult));
    }
}
