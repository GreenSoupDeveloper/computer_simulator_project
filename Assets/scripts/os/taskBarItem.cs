using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class taskBarItem : MonoBehaviour
{
    public GameObject windowObj;
    public GameObject windowManager;
    public GameObject focusedParent;
    public GameObject unfocusedParent;
    public void FocusWindow()
    {

        appMain[] focusedWindows = focusedParent.GetComponentsInChildren<appMain>();
        if (focusedWindows.Length > 0)
        {

            for (int i = 0; i < focusedWindows.Length; i++)
            {
                focusedWindows[i].gameObject.transform.parent = unfocusedParent.transform;
            }
        }

        windowObj.transform.parent = focusedParent.transform;
        windowManager.transform.parent = focusedParent.transform;
    }
}