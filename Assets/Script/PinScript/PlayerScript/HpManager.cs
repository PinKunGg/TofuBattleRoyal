using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

public class HpManager : NetworkBehaviour
{
    float MaxHp = 100f;

    [SerializeField]
    private NetworkVariableFloat Hp = new NetworkVariableFloat(new NetworkVariableSettings
    {
        WritePermission = NetworkVariablePermission.ServerOnly,
        ReadPermission = NetworkVariablePermission.Everyone
    }, 0);

    private void OnEnable()
    {
        Hp.OnValueChanged += OnHpChange;
    }

    private void OnDisable()
    {
        Hp.OnValueChanged -= OnHpChange;
    }

    private void OnHpChange(float oldValue, float newValue)
    {
        if (!IsClient) { return; }
        Debug.Log("Hp = " + Hp.Value);
    }

    public override void NetworkStart()
    {
        Hp.Value = MaxHp;
    }

    [ServerRpc]
    public void TakeDamageServerRpc(float damage)
    {
        // Hp.Value -= damage;
        Debug.Log("1111111111111111111");
    }
}
