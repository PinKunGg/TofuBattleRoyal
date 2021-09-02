using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

public class DropTest : NetworkBehaviour
{
    public GameObject DropItem;
    GameObject a;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && IsLocalPlayer)
        {
            SpawnItemServerRpc(this.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            DeSpawnItemServerRpc();
        }
    }

    [ServerRpc]
    void SpawnItemServerRpc(Vector3 pos)
    {
        a = Instantiate(DropItem, pos + new Vector3(0f, 1f, 5f), Quaternion.identity);
        a.GetComponent<NetworkObject>().Spawn();
    }

    [ServerRpc]
    void DeSpawnItemServerRpc()
    {
        try
        {
            Debug.Log("1 = " + a.name);
            a.GetComponent<NetworkObject>().Despawn();
            Destroy(a);
        }
        catch
        {
            Debug.Log("Bruhhhhh");
        }
    }
}
