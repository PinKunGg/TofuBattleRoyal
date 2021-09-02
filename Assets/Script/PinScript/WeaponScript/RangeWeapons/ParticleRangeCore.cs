using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

public class ParticleRangeCore : NetworkBehaviour
{
    public GameObject ParticleGun;
    protected ParticleSystem parSys;

    protected virtual void Start() {
        parSys = ParticleGun.GetComponent<ParticleSystem>();
    }

    protected virtual void Shoot()
    {
        parSys.Play();
    }
}
