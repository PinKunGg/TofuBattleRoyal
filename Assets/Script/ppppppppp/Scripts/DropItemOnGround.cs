using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

public class DropItemOnGround : NetworkBehaviour, IPointerEnterHandler ,IPointerExitHandler ,IPointerDownHandler
{
    LinkDrop linkDrop;
    TestInven testInven;
    InvenCountItem invenCountItem;
    InvenManager invenManager;
    public GameObject ammo, medkit, grenade;
    void Start()
    {
        testInven = this.GetComponent<TestInven>();
        invenCountItem = (InvenCountItem)FindObjectOfType(typeof(InvenCountItem));
        invenManager = invenCountItem.GetComponentInParent<InvenManager>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        linkDrop = invenManager.Player.GetComponent<LinkDrop>();
        if (Input.GetMouseButtonDown(1))
        {
            linkDrop.Drop(testInven.Item_Name, testInven.Item_Type, testInven.Item_Value ,invenManager.Player.transform.position);
            testInven.Item_Name = "";
            testInven.Item_Type = "";
            testInven.Item_Value = 0;
            invenCountItem.Check_Item();
        }
    }
}
