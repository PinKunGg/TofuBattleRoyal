using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    [SerializeField]
    Transform refPos;
    private void Update() {
        this.transform.position = refPos.position;
        this.transform.rotation = refPos.rotation;
    }
}
