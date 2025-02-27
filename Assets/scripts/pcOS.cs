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
    public GameObject wallpaperimg;

    public GameObject taskBar;
    public GameObject taskBarStart;
    public GameObject exitBtn;
    public GameObject BSOD;
    public GameObject blackBars;
    public GameObject operativeSystem;
    public GameObject apps;

    public bool onBSOD = false;
    public bool isANoOsScreen = false;



    public bool startSequence = true;
    public TextMeshProUGUI texter;
    [Header("No Bootable Device")]
    public GameObject noBootDevice;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        off.SetActive(true);
        blackBars.SetActive(false);

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


                    //texter.text = "CPU: " + cpuname + "\nGPU: " + gpuname + "\nRAM: " + ramamount + "MB\nVRAM: " + vramamount + "MB\nStorage: " + storage + "GB";


                    startSequence = false;
                    blackBars.SetActive(true);
                    Invoke("setOS", 1f);
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
                    blackBars.SetActive(true);

                    Invoke("setOS", 1f);
                }
                else
                {

                }
                exitBtn.SetActive(false);
            }
        }
        if (computer != null)
        {
            if (!computer.isPcON)
            {
                onBSOD = false;
                BSOD.SetActive(false);
                startSequence = true;
                black.SetActive(true);

                if (!isANoOsScreen)
                {
                    taskBar.SetActive(false);
                }
                off.SetActive(true);
                blackBars.SetActive(false);
            }
            else
            {
                off.SetActive(false);
            }
        }
        else
        {
            onBSOD = false;
            BSOD.SetActive(false);
            startSequence = true;
            black.SetActive(true);

            if (!isANoOsScreen)
            {
                taskBar.SetActive(false);
            }
            off.SetActive(true);
            blackBars.SetActive(false);
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
            pcOSCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1280, 720);
        }
        else
        {
            if (computer.currentMonitor.monitorRatio == computerMonitor.Ratio.Square)
                pcOSCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(960, 720);
            else
                pcOSCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1280, 720);
            exitBtn.SetActive(false);
        }


        if (computer.currentMonitor.monitorRatio == computerMonitor.Ratio.Square)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("OSScalable");

            foreach (GameObject thing in gameObjects)
            {
                thing.GetComponent<RectTransform>().sizeDelta = new Vector2(960, 720);
            }
            blackBars.SetActive(true);

            taskBarStart.GetComponent<RectTransform>().anchoredPosition = new Vector2(-3f, -1.500002f);
            apps.GetComponent<RectTransform>().anchoredPosition = new Vector2(161f, 0f);


        }
        else
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("OSScalable");

            foreach (GameObject thing in gameObjects)
            {
                thing.GetComponent<RectTransform>().sizeDelta = new Vector2(1280, 720);
            }
            blackBars.SetActive(false);

            taskBarStart.GetComponent<RectTransform>().anchoredPosition = new Vector2(-55f, -1.500002f);
            apps.GetComponent<RectTransform>().anchoredPosition = new Vector2(8f, 0f);

        }

    }
    void setOS()
    {
        if (computer.currentMonitor.monitorRatio == computerMonitor.Ratio.Square)
        {
            blackBars.SetActive(true);
        }

        black.SetActive(false);
        wallpaperimg.SetActive(true);

        if (!isANoOsScreen)
        {

            taskBar.SetActive(true);
        }
        Debug.Log("os loaded actived thinger");
    }
    public void CloseOS()
    {
        if (computer.currentMonitor.monitorRatio == computerMonitor.Ratio.Square)
            pcOSCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(960, 720);
        OScam.targetTexture = OScam.gameObject.GetComponentInParent<computerMonitor>().monitorTex;
        OScam.targetDisplay = 1;
        pickupController.isOnPCOS = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
