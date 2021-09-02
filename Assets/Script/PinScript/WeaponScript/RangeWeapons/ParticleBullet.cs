using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

public class ParticleBullet : NetworkBehaviour
{
    public float Damage = 5f;
    public ParticleSystem par;
    public List<ParticleCollisionEvent> collisionEvents;
    public GameObject Player;

    GameObject HitFx;

    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        if (!other.CompareTag(Player.gameObject.tag))
        {
            try
            {
                var hp = other.transform.Find("PlayerUI").Find("HpBar").GetComponent<HpManager>();

                if (hp)
                {
                    hp.TakeDamageServerRpc(Damage);

                    int numCollisionEvents = par.GetCollisionEvents(other, collisionEvents);

                    for (int i = 0; i < numCollisionEvents; i++)
                    {
                        Vector3 hitPoint = collisionEvents[i].intersection;

                        // HitFx = ObjectPoller.ObjPollInstance.SpawnFromPool("BulletHitFx", hitPoint, Quaternion.identity);
                        // if (HitFx != null)
                        // {
                        //     HitFx.transform.Find("Canvas").Find("Text2").GetComponent<Text>().text = Damage.ToString();
                        // }

                        SpawnHitFxServerRpc(hitPoint,Damage.ToString());
                    }
                }
            }
            catch
            {
                int numCollisionEvents = par.GetCollisionEvents(other, collisionEvents);

                for (int i = 0; i < numCollisionEvents; i++)
                {
                    Vector3 hitPoint = collisionEvents[i].intersection;

                    // HitFx = ObjectPoller.ObjPollInstance.SpawnFromPool("BulletHitFx", hitPoint, Quaternion.identity);
                    // if (HitFx != null)
                    // {
                    //     HitFx.transform.Find("Canvas").Find("Text2").GetComponent<Text>().text = "";
                    // }
                    
                    SpawnHitFxServerRpc(hitPoint,"");
                }
            }
        }
    }

    [ServerRpc]
    void SpawnHitFxServerRpc(Vector3 hitPoint, string dmg)
    {
        SpawnHitFxClientRpc(hitPoint,dmg);
    }

    [ClientRpc]
    void SpawnHitFxClientRpc(Vector3 hitPoint, string dmg)
    {
        if(!IsClient)
        {
            return;
        }

        //ObjectPoller.ObjPollInstance.SpawnFromPool("BulletHitFx", hitPoint, Quaternion.identity);
        HitFx = ObjectPoller.ObjPollInstance.SpawnFromPool("BulletHitFx", hitPoint, Quaternion.identity);
        if (HitFx != null)
        {
            HitFx.transform.Find("Canvas").Find("Text2").GetComponent<Text>().text = dmg;
        }
    }
}