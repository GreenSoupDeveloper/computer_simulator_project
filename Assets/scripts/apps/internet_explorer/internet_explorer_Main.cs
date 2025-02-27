using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class internet_explorer_Main : MonoBehaviour
{
    public GameObject browserObj;
    public GameObject homePageObj;
    public bool browserOpened = false;

    public bool homePageOpened = false;
    public List<GameObject> historyBack = new List<GameObject>();
    public List<GameObject> historyForward = new List<GameObject>();
    public string currentURL = "https://www.coogle.com";
    
    public TMP_InputField urlInput;
    void Start()
    {
        browserObj.SetActive(false);
        openHome();
    }
    void Update()
    {
        currentURL = urlInput.text;

        if (browserOpened)
        {

            browserObj.SetActive(true);

        }
        else
        {
            browserObj.SetActive(false);
        }
        if (homePageOpened)
        {
            urlInput.text = "https://www.coogle.com";
            homePageObj.SetActive(true);

        }
        else
        {
            homePageObj.SetActive(false);
        }

        if (gameObject.GetComponentInParent<pcOS>().computer != null)
        {
            if (!gameObject.GetComponentInParent<pcOS>().computer.isPcON)
            {
                browserOpened = false;
                homePageOpened = true;
            }
        }
        else
        {
            browserOpened = false;
        }
    }
    public void close()
    {
        browserOpened = false;
    }
    public void openHome()
    {
        homePageOpened = true;
    }
    public void closeHome()
    {
        homePageOpened = false;
    }
    public void openinternet_explorer_Main()
    {
        browserOpened = true;
    }
    
}