using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.EventSystems;
public class pcOS : MonoBehaviour
{
    public OperativeSystem operativeSystemType;
    public enum OperativeSystem { No_Boot_Device, None, Tinglows_XP, Tinglows_2000 };
    public OperativeSystemEdition operativeSystemEdition;
    public enum OperativeSystemEdition { Professional, Home };

    public Camera OScam;
    public RenderTexture pcOSTex;
    public Canvas pcOSCanvas;
    public computerCase computer;
    public GameObject off;


    public GameObject black;
    public GameObject exitBtn;
    public GameObject BSOD;
    public GameObject blackBars;
    public GameObject operativeSystem;

    public GameObject loadingOS;
    public GameObject loadingSession;
    public GameObject shuttingDown;




    public bool onBSOD = false;

    public bool shuttingDownBool = false;



    public bool startSequence = true;
    public bool booted = false;
    public TextMeshProUGUI texter;
    public AudioClip pcBootSound;
    public AudioClip pcShutdownSound;

    public string sessionID = "";

    bool createID = true;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        off.SetActive(true);
        blackBars.SetActive(false);
        loadingSession.SetActive(false);
        shuttingDown.SetActive(false);
        operativeSystem.SetActive(false);


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



        if (operativeSystemType != OperativeSystem.No_Boot_Device)
        {
            if (startSequence)
            {
                if (computer != null)
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
                if (pickupController.isOnPCOS)
                {
                  
                    CloseOS();
                }
                if(computer.currentMonitor != null)
                    computer.currentMonitor.allowEnter = false;

                onBSOD = false;
                BSOD.SetActive(false);
                startSequence = true;
                black.SetActive(true);
                loadingOS.SetActive(false);
                operativeSystem.SetActive(false);
                loadingSession.SetActive(false);


                off.SetActive(true);
                blackBars.SetActive(false);
                shuttingDown.SetActive(false);
                booted = false;
                if (computer.pcAudio != null)
                    computer.pcAudio.Stop();

                //too lazy to optimize this

                string thinger = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                sessionID = "";
                for (int i = 0; i < 4; i++)
                {
                    sessionID += thinger[UnityEngine.Random.Range(0, thinger.Length)];
                }




            }
            else
            {
                off.SetActive(false);
                if(computer.currentMonitor != null)
                    computer.currentMonitor.allowEnter = true;
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





            }
            else
            {
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("OSScalable");

                foreach (GameObject thing in gameObjects)
                {
                    thing.GetComponent<RectTransform>().sizeDelta = new Vector2(1280, 720);
                }
                blackBars.SetActive(false);




            }

        }

        if (shuttingDownBool)
        {

            operativeSystem.SetActive(false);
            black.SetActive(true);
            Invoke("tingle", 0.2f);

            //startSequence = true;


            shuttingDownBool = false;
        }
        if (booted)
        {

        }

    }
    void tingle()
    {
        black.SetActive(false);
        shuttingDown.SetActive(true);


        PlaySound(pcShutdownSound);
    }
    void loadingScreen()
    {
        if (computer.isPcON)
        {

            if (!onBSOD)
            {
                off.SetActive(false);

                if (operativeSystemType != OperativeSystem.No_Boot_Device)
                {
                    black.SetActive(false);
                    float timeme = (100 / computer.cpu.GetComponent<objectScript>().objSpeed) / 14;
                    if (computer.ram1 != null && computer.ram2 != null)
                    {
                        timeme += (1000 / computer.ram1.GetComponent<objectScript>().objSpeed) / 2;
                        timeme += (4096 / computer.ram1.GetComponent<objectScript>().ramSize) / 24;
                        timeme += (1000 / computer.ram2.GetComponent<objectScript>().objSpeed) / 2;
                        timeme += (4096 / computer.ram2.GetComponent<objectScript>().ramSize) / 24;
                    }
                    else if (computer.ram1 != null && computer.ram2 == null)
                    {
                        timeme += (1000 / computer.ram1.GetComponent<objectScript>().objSpeed);
                        timeme += (4096 / computer.ram1.GetComponent<objectScript>().ramSize) / 20;
                    }
                    else if (computer.ram1 == null && computer.ram2 != null)
                    {
                        timeme += (1000 / computer.ram2.GetComponent<objectScript>().objSpeed);
                        timeme += (4096 / computer.ram2.GetComponent<objectScript>().ramSize) / 20;
                    }


                    loadingOS.SetActive(true);
                    Debug.Log("Time: " + timeme);
                    StartCoroutine(delaying(sessionID, timeme));
                }
                else
                {
                    operativeSystem.SetActive(true);
                    black.SetActive(false);
                    booted = true;
                    Debug.Log("reached thinger dingle no hard drive");
                }
            }
        }
    }
    public IEnumerator delaying(string curID, float duration)
    {
        yield return new WaitForSeconds(duration);
        if (sessionID == curID)
        {
            delayOs();
        }
        else
        {
            Debug.Log("not current session");
        }
    }
    void delayOs()
    {
        if (!onBSOD)
        {
            if (computer.isPcON)
            {
                if (!booted)
                {
                    loadingOS.SetActive(false);
                    black.SetActive(true);
                    StartCoroutine(setOS());
                }
            }
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
        loadingOS.SetActive(false);
        black.SetActive(false);
        loadingSession.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        PlaySound(pcBootSound);
        float timeme = 0f;
        if (operativeSystemType == OperativeSystem.Tinglows_XP)
        {
            timeme = (100 / computer.cpu.GetComponent<objectScript>().objSpeed) / 16f;
        }
        else if (operativeSystemType == OperativeSystem.Tinglows_2000)
        {
            timeme = (100 / computer.cpu.GetComponent<objectScript>().objSpeed) / 20f;
        }
        else
        {
            timeme = (100 / computer.cpu.GetComponent<objectScript>().objSpeed) / 20f;
        }
        if (timeme < 5f)
            timeme = 5f;
        yield return new WaitForSeconds(timeme);
        loadingSession.SetActive(false);






        operativeSystem.SetActive(true);
        booted = true;


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
