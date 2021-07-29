using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

public class PlayerGetItem : NetworkBehaviour
{
    [SerializeField] GameObject a;
    InvenCheckAddItem invenCheckAddItem;
    InvenManager invenManager;
    Item item;
    // Start is called before the first frame update
    void Start()
    {
        invenCheckAddItem = (InvenCheckAddItem)FindObjectOfType(typeof(InvenCheckAddItem));
        invenManager = (InvenManager)FindObjectOfType(typeof(InvenManager));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))//ตรงนี้
        {
            if (invenCheckAddItem.CheckAddItem(item.Item_Type, item.Item_Value, item.Item_Name) == true)
            {
                DeSpawnItemServerRpc();
            }
            else 
            {
                item.Item_Value = invenManager.Over_Value;
            }
        }
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
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("item")) 
        {
            item = other.GetComponent<Item>();
            a = other.gameObject;
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        a = null;
    }
}
