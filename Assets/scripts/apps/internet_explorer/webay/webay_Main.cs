using UnityEngine;

public class webay_Main : MonoBehaviour
{
    public GameObject webay_MainObj;
    public internet_explorer_Main browser;
    public bool webay_MainOpened = false;

    public string url = "https://www.webay.com";
    void Start()
    {
        webay_MainObj.SetActive(false);
    }
    void Update()
    {

        if (webay_MainOpened)
        {
           browser.urlInput.text = url;

            webay_MainObj.SetActive(true);

        }
        else
        {
            webay_MainObj.SetActive(false);
        }
        if (gameObject.GetComponentInParent<pcOS>().computer != null)
        {
            if (!gameObject.GetComponentInParent<pcOS>().computer.isPcON)
            {
                webay_MainOpened = false;
            }
        }
    }
    public void close()
    {
        webay_MainOpened = false;
    }
    public void open()
    {
        webay_MainOpened = true;
    }
}