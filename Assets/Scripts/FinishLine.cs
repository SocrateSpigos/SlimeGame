using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    public ParticleSystem[] WinParticles;

    public bool endgame;
    private bool PlayParticle=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void PlayParticles()
    {
        if (PlayParticle)
        {
            foreach (ParticleSystem Par in WinParticles)
            {

                Par.Play();
            }
            PlayParticle = false;
        }
    }
}
