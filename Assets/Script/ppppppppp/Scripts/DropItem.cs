using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropItem : MonoBehaviour, IDropHandler
{
    public InvenManager InvenManage;
    public TestInven ThisInven;
    // Start is called before the first frame update
    void Start()
    {
        //ThisInven = GetComponentInParent<TestInven>();
        InvenManage = (InvenManager)FindObjectOfType(typeof(InvenManager));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(InvenManage.SlotSeclect != null && ThisInven.Inven_Lock == false)
        {
            Debug.Log("Drop");
            InvenManage.SawpItem(ThisInven);
        }
    }
}
