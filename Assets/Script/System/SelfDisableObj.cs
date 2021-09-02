using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDisableObj : MonoBehaviour
{
    [SerializeField]
    float timer;

    private void OnEnable() {
        Invoke("SelfDiable",timer);
    }

    void SelfDiable()
    {
        this.gameObject.SetActive(false);
    }
}
