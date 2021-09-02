using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    Transform playerHead;
    Transform playerBody;
    Transform weaponHandler;
    public Vector3 OffSet;

    float mouseX;
    float mouseY;
    float mouseSensitive = 100f;
    float xRotation = 0f;
    bool isPause;

    public Transform SetRefPos
    {
        set
        {
            playerHead = value;
        }
    }
    public Transform SetPlayerBody
    {
        set
        {
            playerBody = value;
        }
    }
    public Transform SetWeaponHandler
    {
        set
        {
            weaponHandler = value;
        }
    }
    public bool SetisPause
    {
        set
        {
            isPause = value;
        }
    }
    private void Awake()
    {
        this.enabled = false;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        if (playerHead == null)
        {
            return;
        }

        this.transform.position = playerHead.position + OffSet;
    }

    private void Update()
    {
        if (playerHead == null)
        {
            return;
        }

        if (isPause)
        {
            return;
        }
        else
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitive * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitive * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            //weaponHandler.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            //playerHead.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX, Space.World);
        }
    }
}
