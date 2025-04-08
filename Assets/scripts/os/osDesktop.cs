using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.EventSystems;
public class osDesktop : MonoBehaviour
{
    public TMP_Text hourText;
    public pcOS pcOs;
    public Sprite currentWallpaper;
    public GameObject wallpaperObj;
    void Start()
    {

    }
    void Update()
    {
        if (pcOs.booted)
        {
            wallpaperObj.GetComponent<Image>().sprite = currentWallpaper;
            hourText.text = System.DateTime.Now.ToString("HH:mm tt").ToUpper().Replace(". ", "").Replace(".", "");

        }
    }
}