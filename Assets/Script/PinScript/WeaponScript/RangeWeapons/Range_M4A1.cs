using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
public class Range_M4A1 : ParticleRangeCore
{
    public WeaponSCO WeaponObj;
    bool isShoot;

    protected override void Start()
    {
        base.Start();

        var main = parSys.main;
        var mainshape = parSys.shape;

        main.startSpeed = WeaponObj.Distance;
        main.simulationSpeed = WeaponObj.BulletSpeed;
        mainshape.angle = WeaponObj.Recoil;
    }

    private void Update()
    {
        if(!IsLocalPlayer)
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(0) && !isShoot)
        {
            isShoot = true;
            ShootServerRpc();
        }
    }

    [ServerRpc]
    void ShootServerRpc()
    {
        ShootClientRpc();
    }

    [ClientRpc]
    void ShootClientRpc()
    {
        Shoot();
        Invoke("DelayFireRate",WeaponObj.FireRate);
    }

    void DelayFireRate()
    {
        isShoot = false;
    }
}
