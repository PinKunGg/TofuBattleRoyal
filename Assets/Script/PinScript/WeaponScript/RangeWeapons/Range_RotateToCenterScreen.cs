using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

public class Range_RotateToCenterScreen : NetworkBehaviour
{
    Ray ray;
    RaycastHit hit;
    public Image UI_Crosshair;

    public override void NetworkStart()
    {
        if(!IsLocalPlayer)
        {
            this.enabled = false;
        }
    }

    private void Start()
    {
        UI_Crosshair = GameObject.Find("ui_CrossHair").GetComponent<Image>();
    }

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 dir = hit.point - transform.position;
            transform.rotation = Quaternion.LookRotation(dir);
        }
        else
        {
            Vector3 CenterPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 100f));
            transform.LookAt(CenterPos);
        }
    }
}
