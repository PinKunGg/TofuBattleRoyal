using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player_Camera_Pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player_Camera_Pos != null) 
        {
            transform.position = player_Camera_Pos.transform.position;
            transform.rotation = player_Camera_Pos.transform.rotation;
        }
    }

    public void SetCamera(GameObject pos) 
    {
        player_Camera_Pos = pos;
    }
}
