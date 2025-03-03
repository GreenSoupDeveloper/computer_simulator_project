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
    public TMP_Text nomoney;
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

    public GameObject processorPageFilter;
    public GameObject gpuPageFilter;
    public GameObject motherboardPageFilter;
    public GameObject ramPageFilter;
    public GameObject psuPageFilter;
    public GameObject casePageFilter;
    public GameObject hddPageFilter;
    public GameObject fansPageFilter;
    public GameObject monitorsPageFilter;

    public string url = "https://www.webay.com";
    void Start()
    {
        webay_MainObj.SetActive(false);
        objects.SetActive(true);
        checkOutObj.SetActive(false);
        changeObjPage(0);
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
        nomoney.text = "";
        if (item.itemType == "CPU")
        {
            checkOutInfo.text = "Socket: " + item.itemSocket + "\nSpeed: " + item.itemSpeed + "GHz\nCores: " + item.itemCores + "\nThreads: " + item.itemThreads + "\nTDP: " + item.itemTDP + " Watts\nLaunch Year: " + item.launchYear;
        }
        else if (item.itemType == "GPU")
        {
            checkOutInfo.text = "Memory: " + item.itemSize + "MB " + item.itemVersion + "\nSpeed: " + item.itemSpeed + "MHz\nSocket: "+ item.itemSocket+"\nTMUs: " + item.itemTMUs +"\nROPs: "+ item.itemROPS + "\nTDP: " + item.itemTDP + " Watts\nLaunch Year: " + item.launchYear;
        }
        else if (item.itemType == "RAM")
        {
            checkOutInfo.text = "Memory: " + item.itemSize +" MB\nSpeed: " + item.itemSpeed + "MHz\nType: " + item.itemVersion;
        } else if (item.itemType == "Monitor")
        {
            checkOutInfo.text = "Resolution: " + item.itemTMUs +"p\nRatio: " + item.itemROPS;
        }
         else if (item.itemType == "Hard_Drive")
        {
            checkOutInfo.text = "Capacity: " + item.itemSize +" GB\nType: " + item.itemVersion + "\nInterface: " + item.itemSocket + "\nSpeed: "+ item.itemSpeed + " MB/s\nTDP: " + item.itemTDP + " Watts";
        }
        else if (item.itemType == "CPU_Fan")
        {
            checkOutInfo.text = "Compatible Sockets: " + item.itemSocket +"\nSpeed: " + item.itemSpeed + " RPM\nTDP: " + item.itemTDP + " Watts";
        }
        else if (item.itemType == "Power_Supply")
        {
            checkOutInfo.text = "Output: " + item.itemTDP + " Watts";
        }
        else if (item.itemType == "Case")
        {
            checkOutInfo.text = "Form-Factor: " + item.itemSocket + "\nHDD/SSD Slots: " + item.itemSize;
        }
        else if (item.itemType == "Motherboard")
        {
            checkOutInfo.text = "Socket: " + item.itemSocket + "\nForm-Factor: " + item.itemROPS + "\nRAM Slots: " + item.itemSize + "\nPCI Slots: " + item.itemVersion + "\nAGP Slots: " + item.itemTMUs;
        }

        checkOutName.text = item.itemName;
        checkOutPrice.text = item.itemPrice + "$";
        checkOutImage.sprite = item.itemImage;
        checkOutBuyPrefab = item.itemPrefab;
        checkOutObj.SetActive(true);
    }
    public void buyitem()
    {
        if(playerMove.playerMoney >= checkOutBuyPrefab.GetComponent<objectScript>().price)
        {
            playerMove.playerMoney -= checkOutBuyPrefab.GetComponent<objectScript>().price;
            
            Instantiate(checkOutBuyPrefab, new Vector3(spawnPoint.transform.position.x + UnityEngine.Random.Range(-0.5f, 0.5f), spawnPoint.transform.position.y, spawnPoint.transform.position.z + UnityEngine.Random.Range(-0.5f, 0.5f)), Quaternion.identity);
        }else{
            nomoney.text = "You don't have enough money!";
            
        }
        

    }
     public void unCheckOut()
    {
        checkOutBuyPrefab = null;
        checkOutObj.SetActive(false);
    }
    public void changeObjPage(int id)
    {
        if (id == 0)
        {
            processorPage.SetActive(true);
            gpuPage.SetActive(false);
            ramPage.SetActive(false);
            motherboardPage.SetActive(false);
            hddPage.SetActive(false);
            casePage.SetActive(false);
            monitorsPage.SetActive(false);
            fansPage.SetActive(false);
            psuPage.SetActive(false);

            processorPageFilter.SetActive(true);
            gpuPageFilter.SetActive(false);
            ramPageFilter.SetActive(false);
            motherboardPageFilter.SetActive(false);
            hddPageFilter.SetActive(false);
            casePageFilter.SetActive(false);
            monitorsPageFilter.SetActive(false);
            fansPageFilter.SetActive(false);
            psuPageFilter.SetActive(false);

            processorPage.GetComponent<webay_Category>().filter1();
        }
        if (id == 1)
        {
            processorPage.SetActive(false);
            gpuPage.SetActive(true);
            ramPage.SetActive(false);
            motherboardPage.SetActive(false);
            hddPage.SetActive(false);
            casePage.SetActive(false);
            monitorsPage.SetActive(false);
            fansPage.SetActive(false);
            psuPage.SetActive(false);

            processorPageFilter.SetActive(false);
            gpuPageFilter.SetActive(true);
            ramPageFilter.SetActive(false);
            motherboardPageFilter.SetActive(false);
            hddPageFilter.SetActive(false);
            casePageFilter.SetActive(false);
            monitorsPageFilter.SetActive(false);
            fansPageFilter.SetActive(false);
            psuPageFilter.SetActive(false);

            gpuPage.GetComponent<webay_Category>().filter1();
        }
        if (id == 2)
        {
            processorPage.SetActive(false);
            gpuPage.SetActive(false);
            ramPage.SetActive(true);
            motherboardPage.SetActive(false);
            hddPage.SetActive(false);
            casePage.SetActive(false);
            monitorsPage.SetActive(false);
            fansPage.SetActive(false);
            psuPage.SetActive(false);

            processorPageFilter.SetActive(false);
            gpuPageFilter.SetActive(false);
            ramPageFilter.SetActive(true);
            motherboardPageFilter.SetActive(false);
            hddPageFilter.SetActive(false);
            casePageFilter.SetActive(false);
            monitorsPageFilter.SetActive(false);
            fansPageFilter.SetActive(false);
            psuPageFilter.SetActive(false);

            ramPage.GetComponent<webay_Category>().filter1();
        }
        if (id == 3)
        {
            processorPage.SetActive(false);
            gpuPage.SetActive(false);
            ramPage.SetActive(false);
            motherboardPage.SetActive(true);
            hddPage.SetActive(false);
            casePage.SetActive(false);
            monitorsPage.SetActive(false);
            fansPage.SetActive(false);
            psuPage.SetActive(false);

            processorPageFilter.SetActive(false);
            gpuPageFilter.SetActive(false);
            ramPageFilter.SetActive(false);
            motherboardPageFilter.SetActive(true);
            hddPageFilter.SetActive(false);
            casePageFilter.SetActive(false);
            monitorsPageFilter.SetActive(false);
            fansPageFilter.SetActive(false);
            psuPageFilter.SetActive(false);

            motherboardPage.GetComponent<webay_Category>().filter1();
        }
        if (id == 4)
        {
            processorPage.SetActive(false);
            gpuPage.SetActive(false);
            ramPage.SetActive(false);
            motherboardPage.SetActive(false);
            hddPage.SetActive(true);
            casePage.SetActive(false);
            monitorsPage.SetActive(false);
            fansPage.SetActive(false);
            psuPage.SetActive(false);

            processorPageFilter.SetActive(false);
            gpuPageFilter.SetActive(false);
            ramPageFilter.SetActive(false);
            motherboardPageFilter.SetActive(false);
            hddPageFilter.SetActive(true);
            casePageFilter.SetActive(false);
            monitorsPageFilter.SetActive(false);
            fansPageFilter.SetActive(false);
            psuPageFilter.SetActive(false);

            hddPage.GetComponent<webay_Category>().filter1();
        }
        if (id == 5)
        {
            processorPage.SetActive(false);
            gpuPage.SetActive(false);
            ramPage.SetActive(false);
            motherboardPage.SetActive(false);
            hddPage.SetActive(false);
            casePage.SetActive(true);
            monitorsPage.SetActive(false);
            fansPage.SetActive(false);
            psuPage.SetActive(false);

            processorPageFilter.SetActive(false);
            gpuPageFilter.SetActive(false);
            ramPageFilter.SetActive(false);
            motherboardPageFilter.SetActive(false);
            hddPageFilter.SetActive(false);
            casePageFilter.SetActive(true);
            monitorsPageFilter.SetActive(false);
            fansPageFilter.SetActive(false);
            psuPageFilter.SetActive(false);

            casePage.GetComponent<webay_Category>().filter1();
        }
        if (id == 6)
        {
            processorPage.SetActive(false);
            gpuPage.SetActive(false);
            ramPage.SetActive(false);
            motherboardPage.SetActive(false);
            hddPage.SetActive(false);
            casePage.SetActive(false);
            monitorsPage.SetActive(true);
            fansPage.SetActive(false);
            psuPage.SetActive(false);

            processorPageFilter.SetActive(false);
            gpuPageFilter.SetActive(false);
            ramPageFilter.SetActive(false);
            motherboardPageFilter.SetActive(false);
            hddPageFilter.SetActive(false);
            casePageFilter.SetActive(false);
            monitorsPageFilter.SetActive(true);
            fansPageFilter.SetActive(false);
            psuPageFilter.SetActive(false);

            monitorsPage.GetComponent<webay_Category>().filter1();
        }
        if (id == 7)
        {
            processorPage.SetActive(false);
            gpuPage.SetActive(false);
            ramPage.SetActive(false);
            motherboardPage.SetActive(false);
            hddPage.SetActive(false);
            casePage.SetActive(false);
            monitorsPage.SetActive(false);
            fansPage.SetActive(true);
            psuPage.SetActive(false);

            processorPageFilter.SetActive(false);
            gpuPageFilter.SetActive(false);
            ramPageFilter.SetActive(false);
            motherboardPageFilter.SetActive(false);
            hddPageFilter.SetActive(false);
            casePageFilter.SetActive(false);
            monitorsPageFilter.SetActive(false);
            fansPageFilter.SetActive(true);
            psuPageFilter.SetActive(false);

            fansPage.GetComponent<webay_Category>().filter1();
        }
        if (id == 8)
        {
            processorPage.SetActive(false);
            gpuPage.SetActive(false);
            ramPage.SetActive(false);
            motherboardPage.SetActive(false);
            hddPage.SetActive(false);
            casePage.SetActive(false);
            monitorsPage.SetActive(false);
            fansPage.SetActive(false);
            psuPage.SetActive(true);

            processorPageFilter.SetActive(false);
            gpuPageFilter.SetActive(false);
            ramPageFilter.SetActive(false);
            motherboardPageFilter.SetActive(false);
            hddPageFilter.SetActive(false);
            casePageFilter.SetActive(false);
            monitorsPageFilter.SetActive(false);
            fansPageFilter.SetActive(false);
            psuPageFilter.SetActive(true);

            psuPage.GetComponent<webay_Category>().filter1();
        }
        unCheckOut();

    }

}