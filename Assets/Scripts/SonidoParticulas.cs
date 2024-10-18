using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoParticulas : MonoBehaviour
{

    private ParticleSystem particleSys;

    private int numOfParticles = 0;

    public AudioSource audioSource;

    public AudioClip[] Generate;
    public AudioClip[] Destroy;

    public bool boomSound;

    // Start is called before the first frame update
    void Start()
    {
        particleSys = this.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var amount = Mathf.Abs(numOfParticles - particleSys.particleCount);
        if (boomSound)
        {
            if (particleSys.particleCount < numOfParticles)
            {
                audioSource.PlayOneShot(Generate[0]);
            }
        }
        if (!boomSound)
        {
            if (particleSys.particleCount > numOfParticles)
            {
                audioSource.PlayOneShot(Destroy[Random.Range(0, Destroy.Length)]);
            }
        }

        numOfParticles = particleSys.particleCount;
    }



}
