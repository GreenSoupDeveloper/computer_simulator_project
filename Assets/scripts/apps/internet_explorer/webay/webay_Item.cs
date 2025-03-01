using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class webay_Item : MonoBehaviour
{

    public string itemName;
    [Header("CPU/MOBO stuff")]
    public string itemSocket;
    public float itemSpeed;
    public int itemCores;
    public int itemThreads;
    public int itemTDP;
    public int itemPrice;
    public int launchYear;
    public string itemType;
    public Sprite itemImage;

    public GameObject itemPrefab;
    public TMP_Text pageItemText;
    public TMP_Text pageItemPrice;
    public Image pageItemImage;

    public void Start()
    {
        itemType = itemPrefab.GetComponent<objectScript>().type.ToString();
        itemName = itemPrefab.GetComponent<objectScript>().name;
        if (itemType == "CPU")
        {

            itemSocket = itemPrefab.GetComponent<objectScript>().cpuSocket.ToString().Replace("_", " ");
            
            itemCores = itemPrefab.GetComponent<objectScript>().cores;
            itemThreads = itemPrefab.GetComponent<objectScript>().threads;

        }
        if (itemType == "GPU")
        {
        }
        itemSpeed = itemPrefab.GetComponent<objectScript>().objSpeed;

        itemTDP = itemPrefab.GetComponent<objectScript>().tdp;
        itemPrice = itemPrefab.GetComponent<objectScript>().price;
        launchYear = itemPrefab.GetComponent<objectScript>().launchYear;
        pageItemText.text = itemName;
        pageItemPrice.text = itemPrice + "$";
        pageItemImage.sprite = itemImage;

    }
}