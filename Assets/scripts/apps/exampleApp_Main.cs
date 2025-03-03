using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class exampleApp_Main : MonoBehaviour
{
    public GameObject windowObj;
    
    public bool windowOpened = false;

    
    
  
    void Start()
    {
        windowObj.SetActive(false);
    }
    void Update()
    {
    

        if (windowOpened)
        {

            windowObj.SetActive(true);

        }
        else
        {
            windowObj.SetActive(false);
        }
      

        if (gameObject.GetComponentInParent<pcOS>().computer != null)
        {
            if (!gameObject.GetComponentInParent<pcOS>().computer.isPcON)
            {
                windowOpened = false;
                
            }
        }
        else
        {
            windowOpened = false;
        }
    }
    public void CloseApp()
    {
        windowOpened = false;
    }
    public void OpenApp()
    {
        windowOpened = true;
    }

}