using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSelection : MonoBehaviour
{
    public GameObject slimeFactory;

    public void spawnSlimeFactory()
    {
        Instantiate(slimeFactory);
    }
}
