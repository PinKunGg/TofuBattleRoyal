using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

public class SetUpLocalPlayer : NetworkBehaviour
{
    [SerializeField]
    Transform playerHead;
    PlayerCam playerCam;
    public override void NetworkStart()
    {
        if (IsLocalPlayer)
        {
            playerCam = Camera.main.GetComponent<PlayerCam>();
            playerCam.SetRefPos = playerHead;
            playerCam.enabled = true;
            playerCam.transform.SetParent(playerHead);
            playerCam.SetPlayerTrans = this.transform;

            GameObject.Find("Menu Cam").SetActive(false);
        }
    }
}
