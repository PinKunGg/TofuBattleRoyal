using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSCO",menuName = "ScriptableObject/Weapons")]
public class WeaponSCO : ScriptableObject
{
    [Tooltip("1-Range\n2-Melee\n3-Grenade")]
    public int WeaponType;
    [Tooltip("1-Particle Shoot\n2-Raycast Shoot")]
    public int WeaponIndex;
    public float Damage;
    [Tooltip("Particle angle")]
    public float Recoil;
    [Tooltip("Particle angle")]
    public float MoveRecoil;
    [Tooltip("Particle angle")]
    public float ZoomRecoil;
    [Tooltip("Particle startSpeed")]
    public float Distance;
    public float FireRate;
    [Tooltip("Particle simulationSpeed")]
    public float BulletSpeed;
}
