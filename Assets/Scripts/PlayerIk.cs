using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIk : MonoBehaviour
{
    public Transform LfootPos, RfootPos;
    public Transform LhandPos, RhandPos;

    public Transform HoverBoard;
    public Transform HoverBoardPosition;
    public float HoverSpeed;

    public Transform Handle;
    public Transform HandlePosition;
    public float HandleSpeed;



    public Animator Anim;

    [Range(0, 1)]
    public float LfootIkWeight;
    [Range(0, 1)]
    public float RfootIkWeight;



    // Start is called before the first frame update
    void Start()
    {
        Anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        HoverBoard.position = Vector3.Lerp(HoverBoard.position, HoverBoardPosition.position, Time.deltaTime * HoverSpeed);
        Handle.position = Vector3.Lerp(Handle.position, HandlePosition.position, Time.deltaTime * HandleSpeed);


    }

    private void OnAnimatorIK(int layerIndex)
    {

        if (Anim)
        {
            //Left Foot
            Anim.SetIKPosition(AvatarIKGoal.LeftFoot, LfootPos.position);
            Anim.SetIKRotation(AvatarIKGoal.LeftFoot, LfootPos.rotation);
            Anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, LfootIkWeight);
            Anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, LfootIkWeight);

            //Right Foot
            Anim.SetIKPosition(AvatarIKGoal.RightFoot, RfootPos.position);
            Anim.SetIKRotation(AvatarIKGoal.RightFoot, RfootPos.rotation);
            Anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, RfootIkWeight);
            Anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, RfootIkWeight);

            //Left Hand
            Anim.SetIKPosition(AvatarIKGoal.LeftHand, LhandPos.position);
            Anim.SetIKRotation(AvatarIKGoal.LeftHand, LhandPos.rotation);
            Anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, LfootIkWeight);
            Anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, LfootIkWeight);

            //Right Hand
            Anim.SetIKPosition(AvatarIKGoal.RightHand, RhandPos.position);
            Anim.SetIKRotation(AvatarIKGoal.RightHand, RhandPos.rotation);
            Anim.SetIKPositionWeight(AvatarIKGoal.RightHand, RfootIkWeight);
            Anim.SetIKRotationWeight(AvatarIKGoal.RightHand, RfootIkWeight);



        }



    }


}
