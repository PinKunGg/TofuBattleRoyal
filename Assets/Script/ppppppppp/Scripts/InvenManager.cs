using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenManager : MonoBehaviour
{
    public TestInven[] InvenSlot = new TestInven[12];
    public GameObject SlotSeclect;
    public GameObject Player;
    public int Over_Value;
    InvenCountItem invenCountItem;
    // Start is called before the first frame update
    void Start()
    {
        invenCountItem = this.GetComponent<InvenCountItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            UseItem("ammo", 1, "Ammo_orange");
        }
    }

    public bool AddItem(string type , int value , string Name_Item) 
    {
        int maxvalue = 0;
        if (type == "ammo")
        {
            maxvalue = 60;
        }
        else if (type == "medkit") 
        {
            maxvalue = 2;
        }
        else if (type == "grenade")
        {
            maxvalue = 1;
        }

        for (int x = 0; x < InvenSlot.Length; x++) 
        {
            if (InvenSlot[x].Inven_Lock == false) 
            {
                if (InvenSlot[x].Item_Value < maxvalue && (InvenSlot[x].Item_Type == type || InvenSlot[x].Item_Type == ""))
                {
                    if (InvenSlot[x].Item_Value + value <= maxvalue)
                    {
                        InvenSlot[x].Item_Value += value;
                        InvenSlot[x].Item_Type = type;
                        InvenSlot[x].Item_Name = Name_Item;
                        value = 0;
                        break;
                    }
                    else if (InvenSlot[x].Item_Value + value > maxvalue)
                    {
                        value -= (maxvalue - InvenSlot[x].Item_Value);
                        InvenSlot[x].Item_Value = maxvalue;
                        if (x == InvenSlot.Length - 1 && value >= 0)
                        {
                            Debug.Log("Value : " + value);
                        }
                    }
                }
            }
        }
        if (value > 0)
        {
            Debug.Log("Inven Full");
            Over_Value = value;
            return false;
        }
        else 
        {
            invenCountItem.Check_Item();
            return true;
        }
    }

    public void UseItem(string type, int value , string name_item)
    {
        for (int x = 0; x < InvenSlot.Length; x++)
        {
            if (InvenSlot[x].Item_Type == type && InvenSlot[x].Item_Value >= value && InvenSlot[x].Item_Name == name_item) 
            {
                InvenSlot[x].Item_Value -= value;
                if (InvenSlot[x].Item_Value <= 0) 
                {
                    InvenSlot[x].Item_Type = null;
                    InvenSlot[x].Item_Name = null;
                }
                value = 0;
                break;
            }
        }
        if (value > 0)
        {
            Debug.Log("No Item");
        }
        else 
        {
            invenCountItem.Check_Item();
        }
    }

    public void SawpItem(TestInven SlotDrop) 
    {
        TestInven select = SlotSeclect.GetComponent<TestInven>();
        if (select.Item_Type == SlotDrop.Item_Type)
        {
            int maxvalue = 0;
            if (select.Item_Type == "ammo")
            {
                maxvalue = 60;
            }
            else if (select.Item_Type == "medkit")
            {
                maxvalue = 2;
            }
            else if (select.Item_Type == "grenade")
            {
                maxvalue = 1;
            }

            if (select.Item_Value + SlotDrop.Item_Value <= maxvalue)
            {
                SlotDrop.Item_Value += select.Item_Value;
                select.Item_Value = 0;
                select.Item_Type = null;
                select.Item_Name = null;
            }
            else if (select.Item_Value + SlotDrop.Item_Value > maxvalue)
            {
                select.Item_Value -= (maxvalue - SlotDrop.Item_Value);
                SlotDrop.Item_Value = maxvalue;
            }
        }
        else if (select.Item_Type != SlotDrop.Item_Type) 
        {
            string select_item_type = select.Item_Type;
            string select_item_Name = select.Item_Name;
            int select_item_value = select.Item_Value;
            select.Item_Type = SlotDrop.Item_Type;
            select.Item_Value = SlotDrop.Item_Value;
            select.Item_Name = SlotDrop.Item_Name;
            SlotDrop.Item_Type = select_item_type;
            SlotDrop.Item_Value = select_item_value;
            SlotDrop.Item_Name = select_item_Name;
        }
        SlotSeclect = null;
    }

    public bool CheckInvenLock(int SlotNumber)
    {
        return InvenSlot[SlotNumber].Inven_Lock;
    }
    public string CheckInvenName(int SlotNumber)
    {
        return InvenSlot[SlotNumber].Item_Name;
    }
    public string CheckItemType(int SlotNumber)
    {
        return InvenSlot[SlotNumber].Item_Type;
    }
    public int CheckItemValue(int SlotNumber)
    {
        return InvenSlot[SlotNumber].Item_Value;
    }
}
