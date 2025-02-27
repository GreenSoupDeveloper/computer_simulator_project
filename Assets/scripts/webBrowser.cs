using UnityEngine;

public class webBrowser : MonoBehaviour
{
    public GameObject browserObj;
    public GameObject homePageObj;
    public bool browserOpened = false;

    public bool homePageOpened = false;
    void Start()
    {
        browserObj.SetActive(false);
        openHome();
    }
    void Update()
    {

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
    public void openWebBrowser()
    {
        browserOpened = true;
    }
}