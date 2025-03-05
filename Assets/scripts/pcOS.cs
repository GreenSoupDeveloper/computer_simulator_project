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
    public GameObject shuttingDown;

    public bool onBSOD = false;
    public bool noBootDevice = false;

    public bool shuttingDownBool = false;



    public bool startSequence = true;
    public bool booted = false;
    public TextMeshProUGUI texter;
    public AudioClip pcBootSound;
    public AudioClip pcShutdownSound;




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

        if (!noBootDevice)
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
                shuttingDown.SetActive(false);
                booted = false;
                computer.pcAudio.Stop();
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

        if (shuttingDownBool)
        {

            operativeSystem.SetActive(false);
            black.SetActive(true);
            Invoke("tingle", 0.2f);

            //startSequence = true;


            shuttingDownBool = false;
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

                if (!noBootDevice)
                {
                    black.SetActive(false);
                    float timeme = (100 / computer.cpu.GetComponent<objectScript>().objSpeed) / 6;
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
        float timeme = (100 / computer.cpu.GetComponent<objectScript>().objSpeed) / 10f;
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
