using UnityEngine;

public class webBrowser : MonoBehaviour
{
    public GameObject browserObj;
    public bool browserOpened = false;
    void Start()
    {
        browserObj.SetActive(false);
    }
    void Update()
    {
       
        if(browserOpened){
           
            browserObj.SetActive(true);

        }else{
            browserObj.SetActive(false);
        }
    }
    public void close(){
        browserOpened = false;
    }
}