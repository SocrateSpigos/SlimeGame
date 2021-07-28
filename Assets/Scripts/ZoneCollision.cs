using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCollision : MonoBehaviour
{
    public BlockColor zoneColor = BlockColor.Nil;

    public Transform[] Visibles;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Crossroad.LookAtManager.LightColor.GetComponent<Renderer>().material = transform.GetComponent<Renderer>().material;
            Crossroad.backpackManager.RemoveColor(zoneColor); //wipe away every carried block of this color
        }
    }

    public void Config(BlockColor inputColor)       //gotta know what to wipe out, and look the part
    {
        zoneColor = inputColor;
        this.GetComponent<MeshRenderer>().material = Crossroad.mats[(int)zoneColor];
        foreach (Transform Visible in Visibles)
        {
            Visible.GetComponent<MeshRenderer>().material = Crossroad.mats[(int)zoneColor];
        }
    }

}
