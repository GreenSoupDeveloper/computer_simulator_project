using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class startMenu : MonoBehaviour, ISelectHandler, IDeselectHandler
{

    public GameObject startMenuObj;
    public bool startMenuOpened = false;
    public int openCount = 0;
     public GameObject shutDownDialog;
     
    void Start(){
        startMenuObj.SetActive(false);
        shutDownDialog.SetActive(false);
    }
    void Update()
    {

        if (startMenuOpened)
            startMenuObj.SetActive(true);
        else
            startMenuObj.SetActive(false);

    }
    public void OpenShutDownDialog(){
        shutDownDialog.SetActive(true);
    }
    public void CloseShutDownDialog(){
        shutDownDialog.SetActive(false);
    }
    public void ShutDown(){
        shutDownDialog.SetActive(false);
        gameObject.GetComponentInParent<computerCase>().shutdownPc();
    }

    public void StartMenuOpen()
    {


        openCount++;


     if (openCount == 3)
        {
            EventSystem.current.SetSelectedGameObject(null);
            startMenuOpened = false;
            openCount = 0;
        }

    }
    public void OnSelect(BaseEventData eventData)
    {

        StartMenuOpen();
        startMenuOpened = true;
        Debug.Log("start menu selected");
    }

    public void OnDeselect(BaseEventData eventData)
    {
        //startMenuOpened = false;
        openCount = 0;
        Debug.Log("start menu deselected");
    }


}