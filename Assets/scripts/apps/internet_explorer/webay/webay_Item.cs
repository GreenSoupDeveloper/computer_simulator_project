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
    public Sprite itemImage;

    public GameObject itemPrefab;
    public TMP_Text pageItemText;
    public TMP_Text pageItemPrice;
    public Image pageItemImage;

    public void Start(){
        itemName = itemPrefab.GetComponent<objectScript>().name;
        itemSocket = itemPrefab.GetComponent<objectScript>().cpuSocket.ToString().Replace("_", " ");
        itemSpeed = itemPrefab.GetComponent<objectScript>().cpuSpeed;
        itemCores = itemPrefab.GetComponent<objectScript>().cores;
        itemThreads = itemPrefab.GetComponent<objectScript>().threads;
        itemTDP = itemPrefab.GetComponent<objectScript>().tdp;
        itemPrice = itemPrefab.GetComponent<objectScript>().price;
        pageItemText.text = itemName;
        pageItemPrice.text = itemPrice + "$";
        pageItemImage.sprite = itemImage;

    }
}