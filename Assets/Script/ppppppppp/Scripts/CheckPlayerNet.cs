using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

public class CheckPlayerNet : NetworkBehaviour
{
    public GameObject Pos_Camera;
    public GameObject InvenUI;
    public GameObject bullet;
    public bool IsLocal = false;
    InvenManager invenManager;
    CameraControl cameracon;
    bool canuseInven,InvenIsOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        if (IsLocalPlayer) 
        {
            Debug.Log("IsLocalPlayer");
            cameracon = (CameraControl)FindObjectOfType(typeof(CameraControl));
            InvenUI = GameObject.FindGameObjectWithTag("InvenUI");
            invenManager = InvenUI.GetComponentInParent<InvenManager>();
            invenManager.Player = this.gameObject;
            InvenUI.SetActive(false);
            cameracon.SetCamera(Pos_Camera);
            canuseInven = true;
            IsLocal = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && canuseInven == true) 
        {
            if (InvenIsOpen == false)
            {
                InvenUI.SetActive(true);
                InvenIsOpen = true;
            }
            else if (InvenIsOpen == true) 
            {
                InvenUI.SetActive(false);
                InvenIsOpen = false;
            }
        }

        //if (Input.GetKeyDown(KeyCode.O) && IsLocalPlayer)
        //{
        //    SpawnItemServerRpc(this.transform.position);
        //}
    }

    //[ServerRpc]
    //void SpawnItemServerRpc(Vector3 pos)
    //{
    //    SpawnItemClientRpc(pos);
    //}

    //[ClientRpc]
    //void SpawnItemClientRpc(Vector3 pos)
    //{
    //    Instantiate(bullet, pos + new Vector3(0f, 1f, 5f), Quaternion.identity);
    //}
}
