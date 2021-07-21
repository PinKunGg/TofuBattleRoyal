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
            playerCam = GameObject.Find("MainCamera").GetComponent<PlayerCam>();
            playerCam.SetRefPos = playerHead;
            playerCam.enabled = true;
            playerCam.transform.SetParent(playerHead);
            playerCam.SetPlayerTrans = this.transform;

            GameObject.Find("Menu Cam").SetActive(false);
        }

        else
        {
            foreach (var item in PlayerScript)
            {
                item.enabled = false;
            }
        }
    }
}
