using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class webay_Item : MonoBehaviour
{

    public string itemName;
    [Header("CPU/MOBO stuff")]
    public string itemSocket;
    public float itemSpeed;

    public float itemSize;
   
    public int itemCores;
    public int itemThreads;
    public int itemTDP;
    public int itemPrice;
    public int launchYear;
    public string itemType;
    public string itemVersion;
    public string itemTMUs;
    public string itemROPS;
    public Sprite itemImage;

    public GameObject itemPrefab;
    public TMP_Text pageItemText;
    public TMP_Text pageItemPrice;
    public Image pageItemImage;

    public void Start()
    {
        itemType = itemPrefab.GetComponent<objectScript>().type.ToString();
        itemName = itemPrefab.GetComponent<objectScript>().name;
        itemSpeed = itemPrefab.GetComponent<objectScript>().objSpeed;
        if (itemType == "CPU")
        {

            itemSocket = itemPrefab.GetComponent<objectScript>().cpuSocket.ToString().Replace("_", " ");
            
            itemCores = itemPrefab.GetComponent<objectScript>().cores;
            itemThreads = itemPrefab.GetComponent<objectScript>().threads;

        }
        if (itemType == "GPU")
        {
            itemSize = itemPrefab.GetComponent<objectScript>().vram;
             itemVersion = itemPrefab.GetComponent<objectScript>().gpuType;
             itemTMUs = itemPrefab.GetComponent<objectScript>().tmus.ToString();
             itemROPS = itemPrefab.GetComponent<objectScript>().rops.ToString();
             itemSocket = itemPrefab.GetComponent<objectScript>().gpuSocket.ToString();

        }
     if (itemType == "RAM")
        {
            itemSize = itemPrefab.GetComponent<objectScript>().ramSize;
            
            itemVersion = itemPrefab.GetComponent<objectScript>().ramType;
        }
         if (itemType == "Monitor")
        {
            itemTMUs = itemPrefab.GetComponent<objectScript>().resolution;
            itemROPS = itemPrefab.GetComponent<objectScript>().ratio;
           
        }
        if (itemType == "Hard_Drive")
        {
            itemSize = itemPrefab.GetComponent<objectScript>().storage;
            itemVersion = itemPrefab.GetComponent<objectScript>().hddType;
            itemSocket = itemPrefab.GetComponent<objectScript>().hddInterface;
           
        }
        if (itemType == "CPU_Fan")
        {
            itemSocket = itemPrefab.GetComponent<objectScript>().compatibleSockets;
            itemSpeed = itemPrefab.GetComponent<objectScript>().fanSpeed;
           
        }
         if (itemType == "Case")
        {
            itemSocket = itemPrefab.GetComponent<objectScript>().moboFormFactor.ToString().Replace("_", " ");
            itemSize = itemPrefab.GetComponent<objectScript>().hddSpaces;
        }
        if (itemType == "Motherboard")
        {
            itemSocket = itemPrefab.GetComponent<objectScript>().moboSocket.ToString().Replace("_", " ");
            itemROPS = itemPrefab.GetComponent<objectScript>().moboFormFactor.ToString().Replace("_", " ");
            itemSize = itemPrefab.GetComponent<objectScript>().ramSpaces;
            itemVersion = itemPrefab.GetComponent<objectScript>().pciSlots.ToString();
            itemTMUs = itemPrefab.GetComponent<objectScript>().agpSlots.ToString();
        }

        

        itemTDP = itemPrefab.GetComponent<objectScript>().tdp;
        itemPrice = itemPrefab.GetComponent<objectScript>().price;
        launchYear = itemPrefab.GetComponent<objectScript>().launchYear;
        pageItemText.text = itemName;
        pageItemPrice.text = itemPrice + "$";
        pageItemImage.sprite = itemImage;

    }
}