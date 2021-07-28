using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneLookAt : MonoBehaviour
{

    public Transform[] Bones;
    public Transform Target;
    public float Spring;
    public Quaternion of;
    public Transform LightColor;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform bn in Bones)
        {
            bn.gameObject.AddComponent<BoneSpringWeight>();

        }
    }

    // Update is called once per frame
    void Update()
    {

        var newRotation = Quaternion.LookRotation(transform.transform.position - Target.position).eulerAngles;
        newRotation.z = 0;
        Target.rotation = Quaternion.Lerp(Target.rotation, Quaternion.Euler(newRotation ), Time.deltaTime * Spring);
        Target.position = Vector3.Lerp(Target.position,new Vector3( transform.position.x, Target.position.y, transform.position.z), Time.deltaTime * 4);
        for (int i = 0; i < Bones.Length; i++)
        {

            Bones[i].rotation = Quaternion.Lerp(Bones[i].rotation, Target.rotation  * of, Time.deltaTime * 5);


        }

    }
}
