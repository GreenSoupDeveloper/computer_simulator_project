using UnityEngine;

public class shop : MonoBehaviour
{
    public GameObject shopObj;
    public bool shopOpened = false;
    void Start()
    {
        shopObj.SetActive(false);
    }
    void Update()
    {
       
        if(shopOpened){
           
            shopObj.SetActive(true);

        }else{
            shopObj.SetActive(false);
        }
        if (gameObject.GetComponentInParent<pcOS>().computer != null)
        {
            if (!gameObject.GetComponentInParent<pcOS>().computer.isPcON)
            {
               shopOpened = false;
            }
        }
    }
    public void close(){
        shopOpened = false;
    }
    public void open(){
        shopOpened = true;
    }
}