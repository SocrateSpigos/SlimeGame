using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBreak : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)     //once far enough from a segment for it to be invisible, off it
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DelayedBreak());
        }
    }

    IEnumerator DelayedBreak()                      //not delayed anymore, but that could have to change
    {
        yield return null;
        Destroy(transform.parent.gameObject);
    }
}
