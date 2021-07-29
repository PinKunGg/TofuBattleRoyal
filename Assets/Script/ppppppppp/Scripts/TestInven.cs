using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestInven : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    Vector3 ori_pos;
    public InvenManager InvenManager;
    public GameObject pic;

    public Sprite No_Item_pic;
    public Sprite Lock_Item_pic;
    public Sprite[] Item_pic = new Sprite[9];
    public string[] All_Item_Name = new string[9];
    public string Item_Name;
    public string Item_Type;
    public int Item_Value = 0;
    public Text Item_Value_Text;
    public bool Inven_Lock = false;
    public bool Can_Drag;
    void Start()
    {
        ori_pos = this.gameObject.transform.position;
        InvenManager = (InvenManager)FindObjectOfType(typeof(InvenManager));
        pic.GetComponent<Image>().sprite = No_Item_pic;
    }

    // Update is called once per frame
    void Update()
    {
        if (Item_Value > 0 && Item_Name != null)
        {
            Can_Drag = true;
            Item_Value_Text.text = Item_Value.ToString();
            for (int y = 0; y < All_Item_Name.Length; y++) 
            {
                if (Item_Name == All_Item_Name[y])
                {
                    pic.GetComponent<Image>().sprite = Item_pic[y];
                }
            }
        }
        else 
        {
            Can_Drag = false;
            pic.GetComponent<Image>().sprite = No_Item_pic;
            Item_Value_Text.text = "";
        }
        if (Inven_Lock == true) 
        {
            pic.GetComponent<Image>().sprite = Lock_Item_pic;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Can_Drag == true) 
        {
            InvenManager.SlotSeclect = this.gameObject;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (Can_Drag == true)
        {
            pic.transform.position = Input.mousePosition;
            pic.GetComponentInParent<Canvas>().sortingOrder = 2;
            pic.GetComponentInParent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Can_Drag == true)
        {
            pic.transform.position = ori_pos;
            pic.GetComponentInParent<Canvas>().sortingOrder = 1;
            pic.GetComponentInParent<CanvasGroup>().blocksRaycasts = true;
            InvenManager.SlotSeclect = null;
        }
    }
}
