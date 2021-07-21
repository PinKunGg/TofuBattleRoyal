using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    [SerializeField]
    Transform refPos;
    public Vector3 OffSet;
    private void Update() {
        //this.transform.position = refPos.position + OffSet;
        //this.transform.rotation = Camera.main.transform.rotation;
    }
}
