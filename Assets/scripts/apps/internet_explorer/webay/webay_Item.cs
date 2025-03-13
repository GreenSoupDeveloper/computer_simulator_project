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
    public string itemSecond;
    public string itemThird;
    public string itemFourth;
    public string itemFifth;
    public string itemSixth;
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
            itemTDP = itemPrefab.GetComponent<objectScript>().tdp;
            itemVersion = itemPrefab.GetComponent<objectScript>().isx64 ? "x64" : "x86";
            itemThird = itemPrefab.GetComponent<objectScript>().cache.ToString();

        }
        else if (itemType == "GPU")
        {
            itemSize = itemPrefab.GetComponent<objectScript>().vram;
            itemVersion = itemPrefab.GetComponent<objectScript>().gpuType;
            itemTMUs = itemPrefab.GetComponent<objectScript>().tmus.ToString();
            itemROPS = itemPrefab.GetComponent<objectScript>().rops.ToString();
            itemSocket = itemPrefab.GetComponent<objectScript>().gpuSocket.ToString();

        }
        else if (itemType == "RAM")
        {
            itemSize = itemPrefab.GetComponent<objectScript>().ramSize;

            itemVersion = itemPrefab.GetComponent<objectScript>().ramType.ToString();
        }
        else if (itemType == "Monitor")
        {
            itemTMUs = itemPrefab.GetComponent<objectScript>().resolution;
            itemROPS = itemPrefab.GetComponent<objectScript>().ratio;

        }
        else if (itemType == "Hard_Drive")
        {
            itemSize = itemPrefab.GetComponent<objectScript>().storage;
            itemVersion = itemPrefab.GetComponent<objectScript>().hddType;
            itemSocket = itemPrefab.GetComponent<objectScript>().hddInterface;

        }
        else if (itemType == "CPU_Fan")
        {
            itemSocket = itemPrefab.GetComponent<objectScript>().compatibleSockets;
            itemSpeed = itemPrefab.GetComponent<objectScript>().fanSpeed;

        }
        else if (itemType == "Case")
        {
            itemSocket = itemPrefab.GetComponent<objectScript>().moboFormFactor.ToString().Replace("_", " ");
            itemSize = itemPrefab.GetComponent<objectScript>().hddSpaces;
        }
        else if (itemType == "Motherboard")
        {
            itemSocket = itemPrefab.GetComponent<objectScript>().moboSocket.ToString().Replace("_", " ");
            itemROPS = itemPrefab.GetComponent<objectScript>().moboFormFactor.ToString().Replace("_", " ");
            itemSize = itemPrefab.GetComponent<objectScript>().ramSpaces;
            itemVersion = itemPrefab.GetComponent<objectScript>().pciSlots.ToString();
            itemTMUs = itemPrefab.GetComponent<objectScript>().agpSlots.ToString();
            itemSecond = itemPrefab.GetComponent<objectScript>().pcieSlots.ToString();
            if (itemPrefab.GetComponent<objectScript>().moboRamTypeSec != objectScript.RamType.None)
                itemThird = itemPrefab.GetComponent<objectScript>().moboRamType.ToString() + ", " + itemPrefab.GetComponent<objectScript>().moboRamTypeSec.ToString();
            else
                itemThird = itemPrefab.GetComponent<objectScript>().moboRamType.ToString();

            if (itemPrefab.GetComponent<objectScript>().hasiGPU)
                itemFourth = itemPrefab.GetComponent<objectScript>().moboChipset;
            else
                itemFourth = itemPrefab.GetComponent<objectScript>().moboChipset + " (No iGPU)";

            itemFifth = itemPrefab.GetComponent<objectScript>().sataSlots.ToString();
            itemSixth = itemPrefab.GetComponent<objectScript>().ideSlots.ToString();
        }
       




        itemTDP = itemPrefab.GetComponent<objectScript>().tdp;
        itemPrice = itemPrefab.GetComponent<objectScript>().price;
        launchYear = itemPrefab.GetComponent<objectScript>().launchYear;
        pageItemText.text = itemName;
        pageItemPrice.text = itemPrice + "$";
        pageItemImage.sprite = itemImage;

    }
}