using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenCheckAddItem : MonoBehaviour
{
    InvenManager invenManager;
    void Start()
    {
        invenManager = this.GetComponent<InvenManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            CheckAddItem("ammo", 30, "Ammo_orange");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            CheckAddItem("grenade", 1, "Grenade");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            CheckAddItem("Bag", 3, "BagLv1");
        }

    }

    public bool CheckAddItem(string type, int value, string Name_Item) 
    {
        if (type == "Armor_Head")
        {
            return true;
        }
        else if (type == "Armor_Body")
        {
            return true;
        }
        else if (type == "Bag")
        {
            UpgradeBag(value, Name_Item);
            return true;
        }
        else 
        {
            if (invenManager.AddItem(type, value, Name_Item) == true)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }

    public void UpgradeBag(int level, string Name_Item) 
    {
        if (level == 1 || level == 2 || level == 3)
        {
            invenManager.InvenSlot[3].Inven_Lock = false;
            invenManager.InvenSlot[9].Inven_Lock = false;
        }
        if (level == 2 || level == 3) 
        {
            invenManager.InvenSlot[4].Inven_Lock = false;
            invenManager.InvenSlot[10].Inven_Lock = false;
        }
        if (level == 3)
        {
            invenManager.InvenSlot[5].Inven_Lock = false;
            invenManager.InvenSlot[11].Inven_Lock = false;
        }
    }
}
