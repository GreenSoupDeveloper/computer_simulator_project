using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class webay_Main : MonoBehaviour
{
    public GameObject webay_MainObj;
     public GameObject objects;
    public GameObject checkOutObj;
        public GameObject checkOutBuyPrefab;
    public Image checkOutImage;
    public TMP_Text checkOutInfo;
    public TMP_Text checkOutName;
    public TMP_Text checkOutPrice;
    public internet_explorer_Main browser;
    public bool webay_MainOpened = false;
    public GameObject spawnPoint;

    [Header("main")]

    public Button processorPageBtn;
    public Button gpuPageBtn;
    public Button motherboardPageBtn;
    public Button ramPageBtn;
    public Button psuPageBtn;
    public Button casePageBtn;
    public Button hddPageBtn;
    public Button fansPageBtn;
    public Button monitorsPageBtn;


    public GameObject processorPage;
    public GameObject gpuPage;
    public GameObject motherboardPage;
    public GameObject ramPage;
    public GameObject psuPage;
    public GameObject casePage;
    public GameObject hddPage;
    public GameObject fansPage;
    public GameObject monitorsPage;

    public string url = "https://www.webay.com";
    void Start()
    {
        webay_MainObj.SetActive(false);
         objects.SetActive(true);
        checkOutObj.SetActive(false);
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
        checkOutObj.SetActive(false);
    }
    public void open()
    {
        webay_MainOpened = true;
        checkOutObj.SetActive(false);
    }
    public void checkOut(webay_Item item)
    {
         
        checkOutInfo.text = "Socket: "+item.itemSocket + "\nSpeed: " + item.itemSpeed + "GHz\nCores: " + item.itemCores + "\nThreads: " + item.itemThreads + "\nTDP: " + item.itemTDP + " Watts";
        checkOutName.text = item.itemName;
        checkOutPrice.text = item.itemPrice + "$";
        checkOutImage.sprite = item.itemImage;
        checkOutBuyPrefab = item.itemPrefab;
        checkOutObj.SetActive(true);
    }
     public void buyitem()
    {
      Instantiate(checkOutBuyPrefab, spawnPoint.transform.position, Quaternion.identity);
        
    }
     public void unCheckOut()
    {
      checkOutBuyPrefab = null;
        checkOutObj.SetActive(false);
    }
}