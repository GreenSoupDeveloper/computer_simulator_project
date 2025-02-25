using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class pcOS : MonoBehaviour
{

    public Camera OScam;
    public RenderTexture pcOSTex;
    public Canvas pcOSCanvas;
    public computerCase computer;
    public GameObject off;
    public Image wallpaper;
    public GameObject black;
    public Sprite wallpaperimg;
    public GameObject taskBar;
    public GameObject exitBtn;
    public GameObject BSOD;
    public GameObject operativeSystem;
    public bool onBSOD = false;
    public bool isANoOsScreen = false;


    public bool startSequence = true;
    public TextMeshProUGUI texter;
    public shop currShop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        off.SetActive(true);
       
        if (!isANoOsScreen)
        {
            taskBar.SetActive(false);
        }
        exitBtn.SetActive(true);
         Debug.Log("start thing done");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isANoOsScreen)
        {
            if (startSequence)
            {
                if (computer.isPcON)
                {
                    string cpuname = "None";
                    string gpuname = "None";
                    int ramamount = 0;
                    int vramamount = 0;

                    int storage = 0;
                    if (computer.cpu != null)
                    {
                        cpuname = computer.cpu.GetComponent<objectScript>().name + " " + computer.cpu.GetComponent<objectScript>().other;
                    }
                    if (computer.gpu != null)
                    {
                        gpuname = computer.gpu.GetComponent<objectScript>().name;
                        vramamount = computer.gpu.GetComponent<objectScript>().value;
                    }

                    if (computer.ram1 != null)
                    {
                        ramamount += computer.ram1.GetComponent<objectScript>().value;
                    }
                    if (computer.ram2 != null)
                    {
                        ramamount += computer.ram2.GetComponent<objectScript>().value;
                    }

                    if (computer.hdd1 != null)
                    {
                        storage += computer.hdd1.GetComponent<objectScript>().value;
                    }
                    if (computer.hdd2 != null)
                    {
                        storage += computer.hdd2.GetComponent<objectScript>().value;
                    }
                    if (computer.hdd3 != null)
                    {
                        storage += computer.hdd3.GetComponent<objectScript>().value;
                    }


                    texter.text = "CPU: " + cpuname + "\nGPU: " + gpuname + "\nRAM: " + ramamount + "MB\nVRAM: " + vramamount + "MB\nStorage: " + storage + "GB";


                    startSequence = false;
                    Invoke("setWallpaper", 1f);
                }
                else
                {

                }
                exitBtn.SetActive(false);
            }
        }
        else
        {
            if (startSequence)
            {
                if (computer.isPcON)
                {
                    startSequence = false;
                    Invoke("setWallpaper", 1f);
                }
                else
                {

                }
                exitBtn.SetActive(false);
            }
        }
        if (!computer.isPcON)
        {
            onBSOD = false;
            BSOD.SetActive(false);
            startSequence = true;
            black.SetActive(true);
            currShop.shopOpened = false;
            if (!isANoOsScreen)
            {
                taskBar.SetActive(false);
            }
            off.SetActive(true);
        }
        else
        {
            off.SetActive(false);
        }
        if (onBSOD)
        {
            BSOD.SetActive(true);
        }
        else
        {
            BSOD.SetActive(false);
        }
        if (pickupController.isOnPCOS)
        {
            exitBtn.SetActive(true);
        }
        else
        {
            exitBtn.SetActive(false);
        }

    }
    void setWallpaper()
    {

        black.SetActive(false);
        if (!isANoOsScreen)
        {

            taskBar.SetActive(true);
        }
         Debug.Log("os loaded actived thinger");
    }
    public void CloseOS()
    {
        OScam.targetTexture = OScam.gameObject.GetComponentInParent<computerMonitor>().monitorTex;
        OScam.targetDisplay = 1;
        pickupController.isOnPCOS = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void openShop(){
        currShop.shopOpened = true;
    }
}
