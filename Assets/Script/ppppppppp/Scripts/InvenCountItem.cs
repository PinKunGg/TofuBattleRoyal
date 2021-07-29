using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenCountItem : MonoBehaviour
{
    public string[] All_Item_Name = new string[9];
    public int[] All_Item_Value = new int[9];
    InvenManager InvenManage;

    void Start()
    {
        InvenManage = this.GetComponent<InvenManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            Check_Item();
        }
    }

    public void Check_Item() 
    {
        for (int z = 0; z < All_Item_Value.Length; z++) 
        {
            All_Item_Value[z] = 0;
        }
        for (int x = 0; x < InvenManage.InvenSlot.Length ; x++) 
        {
            for (int y = 0; y < All_Item_Name.Length ; y++) 
            {
                if (InvenManage.CheckInvenName(x) == All_Item_Name[y]) 
                {
                    All_Item_Value[y] += InvenManage.CheckItemValue(x);
                    break;
                }
            }
        }
    }
}
