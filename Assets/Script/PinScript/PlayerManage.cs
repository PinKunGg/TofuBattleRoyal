using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManage : MonoBehaviour
{
    bool isLocalPause;

    public List<Behaviour> PlayerScript;

    [SerializeField]
    int[] activeScriptList;

    private void Start()
    {
        activeScriptList = new int[PlayerScript.Count];
        CheckActiveScript();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isLocalPause = !isLocalPause;
            FindObjectOfType<PlayerCam>().SetisPause = isLocalPause;

            if (isLocalPause)
            {
                DisablePlayerScript();
            }
            else
            {
                EnablePlayerScript();
            }
        }
    }

    void CheckActiveScript()
    {
        for (int i = 0; i < PlayerScript.Count; i++)
        {
            if (PlayerScript[i].enabled)
            {
                activeScriptList[i] = 1;
            }
            else
            {
                activeScriptList[i] = 0;
            }
        }
    }

    void EnablePlayerScript()
    {
        for (int i = 0; i < PlayerScript.Count; i++)
        {
            if (activeScriptList[i] == 1)
            {
                PlayerScript[i].enabled = true;
            }
            else
            {
                PlayerScript[i].enabled = false;
            }
        }
    }
    void DisablePlayerScript()
    {
        CheckActiveScript();

        foreach (var script in PlayerScript)
        {
            script.enabled = false;
        }
    }
}
