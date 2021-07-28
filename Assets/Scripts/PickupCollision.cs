using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using DG.Tweening;

public class PickupCollision : MonoBehaviour
{
    public BlockColor blockColor = BlockColor.Nil; //needed a null value!

    public Transform DestroyParticle;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))                                             //if the player touches
        {
            BackpackBlock block = Instantiate(this.transform, Crossroad.backpackManager.transform)
                .gameObject.AddComponent<BackpackBlock>();                          //make a copy of the pickup for the backpack
            block.transform.GetComponentInChildren<PickupChangeCol>().picked=true;
            block.DestructionParticle = DestroyParticle;
           
            block.transform.localScale = new Vector3(block.transform.localScale.x,
                Crossroad.backpackManager.heightConstant,                           //height constant lets us reconfig the thickness with ease
                block.transform.localScale.z);                                      //make it flat enough
            block.Config(this.blockColor);                                             //color the block
            Destroy(this.gameObject);
            

        }
    }

    public void Config(BlockColor inputColor)
    {
        blockColor = inputColor;                                                        //get the color's name
        this.GetComponent<MeshRenderer>().material = Crossroad.mats[(int)blockColor];   //and assign the matching material
    }

 
   


}
