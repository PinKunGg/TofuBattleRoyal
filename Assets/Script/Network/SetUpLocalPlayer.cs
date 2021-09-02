using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

public class SetUpLocalPlayer : NetworkBehaviour
{
    public Transform playerHead;
    PlayerCam playerCam;

    public List<Behaviour> PlayerScript;
    public override void NetworkStart()
    {
        if (IsLocalPlayer)
        {
            this.gameObject.tag = "LocalPlayer";
            playerCam = GameObject.Find("MainCamera").GetComponent<PlayerCam>();
            playerCam.SetRefPos = playerHead;
            playerCam.enabled = true;
            playerCam.transform.SetParent(playerHead);
            playerCam.SetPlayerBody = this.transform;

            GameObject.Find("Menu Cam").SetActive(false);
        }

        else
        {
            this.gameObject.tag = "OtherPlayer";
            foreach (var item in PlayerScript)
            {
                item.enabled = false;
            }
        }
    }
}
