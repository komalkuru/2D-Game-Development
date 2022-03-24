using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject particles;

    public void PlayWinEffect()
    {
        particles.SetActive(true);
        //Invoke("StopWinEffect", 3f);
    }

}
