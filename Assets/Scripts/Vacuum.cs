using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    public Transform Slime;
    public Transform NewSlimePos;
    public float Speed = 1f;
  

    // Update is called once per frame
    void Update()
    {
        
    }

    void PositionChanging()
    {

        Slime.transform.position = Vector3.Lerp(Slime.position, NewSlimePos.position, Time.deltaTime * Speed);
        Slime.transform.rotation = Quaternion.Lerp(Slime.rotation, NewSlimePos.rotation, Time.deltaTime * Speed);

    }
}
