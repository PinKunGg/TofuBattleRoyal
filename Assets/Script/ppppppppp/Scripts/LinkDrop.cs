using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

public class LinkDrop : NetworkBehaviour
{
    public GameObject ammo, medkit, grenade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drop(string name, string type, int value, Vector3 pos)
    {
        SpawnItemServerRpc(name, type, value, pos);
    }

    [ServerRpc]
    void SpawnItemServerRpc(string name, string type, int value, Vector3 pos)
    {
        if (type == "ammo")
        {
            GameObject a = Instantiate(ammo, pos + new Vector3(0f, 1f, 5f), Quaternion.identity);
            a.GetComponent<NetworkObject>().Spawn();
            a.GetComponent<Item>().Item_Name = name;
            a.GetComponent<Item>().Item_Type = type;
            a.GetComponent<Item>().Item_Value = value;
        }
        else if (type == "medkit")
        {
            GameObject m = Instantiate(medkit, pos + new Vector3(0f, 1f, 5f), Quaternion.identity);
            m.GetComponent<NetworkObject>().Spawn();
            m.GetComponent<Item>().Item_Name = name;
            m.GetComponent<Item>().Item_Type = type;
            m.GetComponent<Item>().Item_Value = value;
        }
        else if (type == "grenade")
        {
            GameObject g = Instantiate(grenade, pos + new Vector3(0f, 1f, 5f), Quaternion.identity);
            g.GetComponent<NetworkObject>().Spawn();
            g.GetComponent<Item>().Item_Name = name;
            g.GetComponent<Item>().Item_Type = type;
            g.GetComponent<Item>().Item_Value = value;
        }
    }

    //[ClientRpc]
    //void SpawnItemClientRpc(string name, string type, int value, Vector3 pos)
    //{
    //    if (type == "ammo")
    //    {
    //        GameObject a = Instantiate(ammo, pos + new Vector3(0f, 1f, 5f), Quaternion.identity);
    //        //if (IsServer)
    //        //{
    //        //    a.GetComponent<NetworkObject>().Spawn();
    //        //}
    //        a.GetComponent<Item>().Item_Name = name;
    //        a.GetComponent<Item>().Item_Type = type;
    //        a.GetComponent<Item>().Item_Value = value;
    //    }
    //    else if (type == "medkit")
    //    {
    //        GameObject m = Instantiate(medkit, pos + new Vector3(0f, 1f, 5f), Quaternion.identity);
    //        //if (IsServer)
    //        //{
    //        //    m.GetComponent<NetworkObject>().Spawn();
    //        //}
    //        m.GetComponent<Item>().Item_Name = name;
    //        m.GetComponent<Item>().Item_Type = type;
    //        m.GetComponent<Item>().Item_Value = value;
    //    }
    //    else if (type == "grenade")
    //    {
    //        GameObject g = Instantiate(grenade, pos + new Vector3(0f, 1f, 5f), Quaternion.identity);
    //        //if (IsServer)
    //        //{
    //        //    g.GetComponent<NetworkObject>().Spawn();
    //        //}
    //        g.GetComponent<Item>().Item_Name = name;
    //        g.GetComponent<Item>().Item_Type = type;
    //        g.GetComponent<Item>().Item_Value = value;
    //    }
    //}
}
