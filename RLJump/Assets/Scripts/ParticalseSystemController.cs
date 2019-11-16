using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
public class ParticalseSystemController : MonoBehaviour
{
    [SerializeField] private ParticleSystem mef;
    [SerializeField] private ParticleSystem jef;
    private PlayerMovement plM;


    private void Start()
    {
        plM = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (plM.isJumping && !jef.isPlaying) jef.Play();
        else jef.Stop();

        if (plM.isMagniting && !mef.isPlaying) mef.Play();
        else mef.Stop();

    }
}
