using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class pcOS : MonoBehaviour
{

    public Camera OScam;
    public RenderTexture pcOSTex;
    public Canvas pcOSCanvas;
    public computerCase computer;
    public GameObject off;

    public GameObject black;
    public GameObject wallpaperimg;

    public GameObject taskBarStart;
    public GameObject exitBtn;
    public GameObject BSOD;
    public GameObject blackBars;
    public GameObject operativeSystem;
    public GameObject apps;

    public GameObject loadingOS;
    public GameObject loadingSession;

    public bool onBSOD = false;
    public bool noBootDevice = false;



    public bool startSequence = true;
    public TextMeshProUGUI texter;
    public AudioClip pcBootSound;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        off.SetActive(true);
        blackBars.SetActive(false);
        loadingSession.SetActive(false);

        exitBtn.SetActive(true);
        Debug.Log("start thing done");
    }
    void PlaySound(AudioClip clip)
    {
        if (computer.pcAudio != null)
            computer.pcAudio.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {

        if (!noBootDevice)
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

                    Invoke("loadingScreen", 1.5f);
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

                    Invoke("loadingScreen", 1.5f);
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
                loadingOS.SetActive(false);
                operativeSystem.SetActive(false);
                loadingSession.SetActive(false);

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
            if (computer != null)
            {
                if (computer.currentMonitor.monitorRatio == computerMonitor.Ratio.Square)
                    pcOSCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(960, 720);
                else
                    pcOSCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1280, 720);
                exitBtn.SetActive(false);
            }
        }
        if (computer != null)
        {
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

    }
    void loadingScreen()
    {
        if (computer.isPcON)
        {
           
            if (!noBootDevice)
            {
                black.SetActive(false);
                float timeme = (100 / computer.cpu.GetComponent<objectScript>().objSpeed) / 4;
                loadingOS.SetActive(true);
                Debug.Log("Time: " + timeme);
                Invoke("delayOs", timeme);
            }
            else
            {
                setOS();
            }
        }
    }
    void delayOs()
    {
        if (computer.isPcON)
        {
            loadingOS.SetActive(false);
            black.SetActive(true);
            StartCoroutine(setOS());
        }
    }
    public IEnumerator setOS()
    {
        yield return new WaitForSeconds(1f);
        if (computer != null)
        {
            if (computer.currentMonitor.monitorRatio == computerMonitor.Ratio.Square)
            {
                blackBars.SetActive(true);
            }
            else
            {
                blackBars.SetActive(false);
            }
        }
        black.SetActive(false);
        loadingSession.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        PlaySound(pcBootSound);
        yield return new WaitForSeconds(3.4f);
        loadingSession.SetActive(false);






        operativeSystem.SetActive(true);


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
