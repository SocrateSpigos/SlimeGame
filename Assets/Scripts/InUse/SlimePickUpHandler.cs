using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePickUpHandler : MonoBehaviour
{
    public Transform vacuum;
    [SerializeField]
    private int slimeCapacity;
    [SerializeField]
    private List<GameObject> slimes;
    [SerializeField]
    private List<Renderer> slimeRenderers;
    [SerializeField]
    private GameObject lid;
    [SerializeField]
    private List<Material> slimeMaterials = new List<Material>();

    private int slimeCount;
    
    public bool IsFull()
    {
        return slimeCount == slimeCapacity;
    }

    public int GetSlimeCount()
    {
        return slimeCount;
    }

    public Material GetSlimeMaterial(int index)
    {
        Material mat = slimeMaterials[slimeMaterials.Count - 1];
        slimeMaterials.RemoveAt(slimeMaterials.Count - 1);
        return mat;
    }

    public void AddSlime(Material mat)
    {
        slimeMaterials.Add(mat);
        slimeCount++;
        slimes[slimeCount - 1].SetActive(true);
        slimeRenderers[slimeCount - 1].material = mat;

        if (IsFull())
        {
            lid.SetActive(true);
        }
    }

    public void RemoveSlimes()
    {
        slimeCount = 0;
        slimes[slimeCount - 1].SetActive(false);
        //slimeMaterials.Clear();
        lid.SetActive(false);
    }
}
