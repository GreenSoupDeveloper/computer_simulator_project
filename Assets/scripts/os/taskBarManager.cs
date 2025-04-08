using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class taskBarManager : MonoBehaviour
{
    public List<GameObject> appObjs;

    public GameObject taskBarItemPrefab;
    public GameObject parent;
    public GameObject focusedParent;
    public GameObject unfocusedParent;
    public void AddItem(GameObject windowManager)
    {
        for (int i = 0; i < appObjs.Count; i++)
        {
            if (appObjs[i].gameObject.GetComponentInChildren<TMP_Text>().text == windowManager.GetComponent<appMain>().windowName)
            {
                return;
            }
        }
        var newObj = GameObject.Instantiate(taskBarItemPrefab);
        newObj.transform.parent = parent.gameObject.transform;

        newObj.transform.localScale = new Vector3(1f, 1f, 1f);
        newObj.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        newObj.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
        newObj.GetComponentInChildren<TMP_Text>().text = windowManager.GetComponent<appMain>().windowName;

        newObj.GetComponent<taskBarItem>().windowManager = windowManager;
        newObj.GetComponent<taskBarItem>().windowObj = windowManager.GetComponent<appMain>().windowObj;
        newObj.GetComponent<taskBarItem>().focusedParent = focusedParent;
        newObj.GetComponent<taskBarItem>().unfocusedParent = unfocusedParent;
        appObjs.Add(newObj);

    }
    public void RemoveItem(string appName)
    {
        for (int i = 0; i < appObjs.Count; i++)
        {
            if (appObjs[i].gameObject.GetComponentInChildren<TMP_Text>().text == appName)
            {

                Destroy(appObjs[i].gameObject);
                appObjs.RemoveAt(i);
            }
        }
    }


}