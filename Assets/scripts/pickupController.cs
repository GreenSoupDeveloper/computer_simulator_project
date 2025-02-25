using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class pickupController : MonoBehaviour
{

    public Transform followPoint;
    public Transform parent;
    public static GameObject heldObj;
    public static Rigidbody heldObjRB;
    public TextMeshProUGUI infotxt;
    public LayerMask componentColliderExclude;

    public float pickupRange = 5.0f;
    public float pickupForce = 750.0f;
    public float objRotationForce = 250.0f;
    public float pickedObjDistance = 0.1f;
    public static bool pickedObject = false;
    public static bool objIsOnPC = false;
    public LayerMask objLayer;
    public static bool canRotate = false;
    public static bool disarmMode = false;
    RaycastHit hitted;

    [Header("Pc Parts")]
    public Transform moboParent;

    [Header("Pc OS stuff")]
    public static bool isOnPCOS = false;
    public pcOS currPCOS;
    public pcOS lastPCOS;
    public Material orgPcOSMat;
    public Material replacePcOSMat;
    public static bool linkScreenMode = false;
    public int linkStep = 0;
    void Start()
    {
        infotxt.text = "";
        currPCOS = null;
    }

    void Update()
    {
        //if (GameControls.inPrimary)
        if (!isOnPCOS)
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (heldObj == null)
                {

                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitted, pickupRange, objLayer))
                    {

                        //pickup obj
                        if (!disarmMode)
                        {
                            if (hitted.transform.gameObject.GetComponent<objectScript>().isOnPC == false)
                            {
                                objIsOnPC = false;
                                pickedObject = true;

                            }
                            else
                            {
                                objIsOnPC = true;
                                pickedObject = false;

                                StartCoroutine(main.setErrorMessage("Can't pick up a part that is on a PC!"));
                                Debug.Log("Can't pick up a part that is on a PC!");
                            }
                        }
                        else
                        {
                            if (hitted.transform.gameObject.GetComponent<objectScript>().isOnPC == true)
                            {
                                hitted.transform.gameObject.GetComponent<Rigidbody>().useGravity = false;
                                hitted.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;

                                if (hitted.transform.gameObject.GetComponent<objectScript>().type == objectScript.CompType.Motherboard)
                                {
                                    hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<objDetecter>().curcase.hasMOBO = false;
                                    hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<objDetecter>().curcase.mobo = null;
                                }
                                else if (hitted.transform.gameObject.GetComponent<objectScript>().type == objectScript.CompType.Power_Supply)
                                {
                                    hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<objDetecter>().curcase.hasPowerSupply = false;
                                    hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<objDetecter>().curcase.powerSupply = null;
                                }
                                else if (hitted.transform.gameObject.GetComponent<objectScript>().type == objectScript.CompType.Hard_Drive)
                                {
                                    if (hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<objDetecter>().hddIndex == 0)
                                    {
                                        hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<objDetecter>().curcase.hasHDD1 = false;
                                        hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<objDetecter>().curcase.hdd1 = null;
                                        hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<objDetecter>().curcase.hddList.Remove(hitted.transform.gameObject);
                                    }
                                    else if (hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<objDetecter>().hddIndex == 1)
                                    {
                                        hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<objDetecter>().curcase.hasHDD2 = false;
                                        hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<objDetecter>().curcase.hdd2 = null;
                                        hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<objDetecter>().curcase.hddList.Remove(hitted.transform.gameObject);
                                    }
                                    else if (hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<objDetecter>().hddIndex == 2)
                                    {
                                        hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<objDetecter>().curcase.hasHDD3 = false;
                                        hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<objDetecter>().curcase.hdd3 = null;
                                        hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<objDetecter>().curcase.hddList.Remove(hitted.transform.gameObject);
                                    }

                                }
                                else if (hitted.transform.gameObject.GetComponent<objectScript>().type == objectScript.CompType.CPU)
                                {
                                    hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<moboObjDetecter>().curMobo.hasCPU = false;
                                    hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<moboObjDetecter>().curMobo.cpu = null;
                                }
                                else if (hitted.transform.gameObject.GetComponent<objectScript>().type == objectScript.CompType.RAM)
                                {
                                    if (hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<moboObjDetecter>().isRam1)
                                    {
                                        hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<moboObjDetecter>().curMobo.hasRAM1 = false;
                                        hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<moboObjDetecter>().curMobo.ram1 = null;
                                    }
                                    else
                                    {
                                        hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<moboObjDetecter>().curMobo.hasRAM2 = false;
                                        hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<moboObjDetecter>().curMobo.ram2 = null;
                                    }
                                }
                                else if (hitted.transform.gameObject.GetComponent<objectScript>().type == objectScript.CompType.CPU_Fan)
                                {
                                    hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<moboObjDetecter>().curMobo.hasCPUFan = false;
                                    hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<moboObjDetecter>().curMobo.cpuFan = null;
                                }
                                else if (hitted.transform.gameObject.GetComponent<objectScript>().type == objectScript.CompType.GPU)
                                {
                                    hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<moboObjDetecter>().curMobo.hasGPU = false;
                                    hitted.transform.gameObject.GetComponent<objectScript>().parent.transform.gameObject.GetComponent<moboObjDetecter>().curMobo.gpu = null;
                                }
                                hitted.transform.gameObject.GetComponent<objectScript>().isOnPC = false;
                                hitted.transform.gameObject.GetComponent<Collider>().excludeLayers = componentColliderExclude;
                                objIsOnPC = false;
                                pickedObject = true;

                            }
                            else
                            {

                                objIsOnPC = false;
                                pickedObject = true;

                            }
                        }

                    }
                }
                else
                {
                    pickedObject = false;
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitted, pickupRange, objLayer))
            {
                if (hitted.transform.gameObject.GetComponentInParent<computerCase>() != null)
                {
                    if (hitted.transform.gameObject.GetComponentInParent<computerCase>().isPcON)
                    {
                        hitted.transform.gameObject.GetComponentInParent<computerCase>().isPcON = false;
                    }
                    else
                    {
                        if (hitted.transform.gameObject.GetComponentInParent<computerCase>().hasMOBO)
                        {
                            if (hitted.transform.gameObject.GetComponentInParent<computerCase>().hasCPU)
                            {
                                if (hitted.transform.gameObject.GetComponentInParent<computerCase>().hasPowerSupply)
                                {
                                    if (hitted.transform.gameObject.GetComponentInParent<computerCase>().hasRAM1 || hitted.transform.gameObject.GetComponentInParent<computerCase>().hasRAM2)
                                    {
                                        hitted.transform.gameObject.GetComponentInParent<computerCase>().isPcON = true;
                                    }
                                    else
                                    {
                                        StartCoroutine(main.setErrorMessage("Can't turn on the PC without RAM!"));
                                        Debug.Log("Can't turn on the PC without RAM!");
                                    }
                                }
                                else
                                {
                                    StartCoroutine(main.setErrorMessage("Can't turn on the PC without a Power Supply!"));
                                    Debug.Log("Can't turn on the PC without a Power Supply!");
                                }
                            }
                            else
                            {
                                StartCoroutine(main.setErrorMessage("Can't turn on the PC without a CPU!"));
                                Debug.Log("Can't turn on the PC without a CPU!");
                            }
                        }
                        else
                        {
                            StartCoroutine(main.setErrorMessage("Can't turn on the PC without a Motherboard!"));
                            Debug.Log("Can't turn on the PC without a Motherboard!");
                        }
                    }
                }
                else
                {
                    Debug.Log("this is not a computer!");
                    StartCoroutine(main.setErrorMessage("This is not a computer!"));
                }
            }
        }
        if (linkScreenMode)
        {
            if (linkStep == 0)
            {
                infotxt.text = "Choose a Case or Motherboard";
            }
            if (linkStep == 1)
            {
                infotxt.text = "Choose a Monitor";
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitted, pickupRange, objLayer))
                {
                    if (linkStep == 0)
                    {
                        if (hitted.transform.gameObject.GetComponent<computerCase>() != null)
                        {
                            if (hitted.transform.gameObject.GetComponentInChildren<moboScript>() != null)
                            {
                                currPCOS = hitted.transform.gameObject.GetComponent<computerCase>().pcOS;
                                linkStep++;
                            }
                            else
                            {
                                Debug.Log("this is pc doesnt have a mobo!");
                                StartCoroutine(main.setErrorMessage("This Case doesn't have a Motherboard!"));
                                linkStep = 0;
                            }



                        }
                        else if (hitted.transform.gameObject.GetComponent<moboScript>() != null)
                        {
                            if (hitted.transform.gameObject.GetComponentInParent<computerCase>() != null)
                            {
                                currPCOS = hitted.transform.gameObject.GetComponentInParent<computerCase>().pcOS;
                            }
                            else
                            {
                                Debug.Log("this is mobo is not on a pc!");
                                StartCoroutine(main.setErrorMessage("This Motherboard is not on a computer!"));
                                linkStep = 0;
                            }

                        }
                        else
                        {
                            Debug.Log("this is not a computer!");
                            StartCoroutine(main.setErrorMessage("This is not a computer!"));
                            linkStep = 0;
                        }

                    }
                    else if (linkStep == 1)
                    {

                        if (hitted.transform.gameObject.GetComponent<computerMonitor>() != null)
                        {


                            computerMonitor monitor = hitted.transform.gameObject.GetComponent<computerMonitor>();


                            computerCase[] computers = FindObjectsOfType<computerCase>();



                            foreach (computerCase cp in computers)
                            {
                                if (cp.currentMonitor == monitor)
                                {
                                    monitor.currpcOS = null;
                                    cp.currentMonitor.clear = true;
                                    cp.currentMonitor.onLeComputahr = false;
                                    cp.currentMonitor.skipDiddy = false;
                                    if (cp.currentMonitor.currpcOS != null)
                                        cp.currentMonitor.currpcOS.pcOSCanvas.worldCamera = null;
                                    cp.pcOS.pcOSCanvas.worldCamera = null;
                                    cp.currentMonitor.currpcOS = null;
                                    cp.currentMonitor = null;

                                }
                            }


                            currPCOS.GetComponentInParent<computerCase>().currentMonitor = monitor;






                            currPCOS.OScam = monitor.gameObject.GetComponentInChildren<Camera>();
                            currPCOS.pcOSCanvas.worldCamera = monitor.gameObject.GetComponentInChildren<Camera>();
                            currPCOS.computer = currPCOS.GetComponentInParent<computerCase>();




                            monitor.monitorScreen.material = monitor.monitorMat;
                            currPCOS.gameObject.GetComponent<pcOS>().OScam = monitor.monitorCam;
                            currPCOS.OScam.targetTexture = monitor.monitorTex;


                            linkStep++;
                        }
                        else
                        {
                            Debug.Log("this is not a display!");
                            StartCoroutine(main.setErrorMessage("This is not a display!"));
                            linkStep = 0;
                        }

                    }
                    if (linkStep > 1)
                    {
                        linkScreenMode = false;
                        linkStep = 0;
                    }

                }
            }
        }
        if (GameControls.inSecondary)
        {


            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitted, pickupRange, objLayer))
            {

                if (hitted.transform.gameObject.tag == "ComputerOS")
                {
                    if (hitted.transform.gameObject.GetComponent<computerMonitor>().onLeComputahr == true)
                    {


                        /*if (hitted.transform.GetComponent<computerMonitor>().monitorScreen.material != replacePcOSMat)
                        {
                            //hitted.transform.gameObject.GetComponentInChildren<Camera>().targetTexture = pcOSTex;
                            //hitted.transform.gameObject.GetComponentInChildren<Camera>().targetTexture = null;
                            hitted.transform.gameObject.GetComponentInChildren<Camera>().targetDisplay = 0;
                            */
                        //hitted.transform.GetComponent<computerMonitor>().currPCOS = hitted.transform.gameObject.GetComponentInChildren<Camera>();
                        isOnPCOS = true;
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        hitted.transform.GetComponent<computerMonitor>().monitorCam.targetTexture = null;
                        hitted.transform.GetComponent<computerMonitor>().monitorCam.targetDisplay = 0;

                        Debug.Log("entered to os!");
                    }


                }
            }

        }
        if (!GameControls.inPrimary)
        {
            pickedObject = false;

        }
        if (Input.GetKeyDown(KeyCode.F))
            canRotate = true;
        if (Input.GetKeyUp(KeyCode.F))
            canRotate = false;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (linkScreenMode)
                linkScreenMode = false;
            else
                linkScreenMode = true;

            infotxt.text = "Screen Link mode: " + linkScreenMode + "\nDisarm mode: " + disarmMode;
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (disarmMode)
            {
                disarmMode = false;

            }
            else
            {
                disarmMode = true;
            }
            infotxt.text = "Screen Link mode: " + linkScreenMode + "\nDisarm mode: " + disarmMode;
        }





        float mousewheel = Input.GetAxis("Mouse ScrollWheel");
        if (mousewheel > 0)
        {

            followPoint.position += transform.forward * 0.25f;

        }
        if (mousewheel < 0)
        {
            followPoint.position -= transform.forward * 0.25f;

        }

        if (pickedObject)
        {

            PickupObject(hitted.transform.gameObject);

        }
        else
        {
            DropObject();
        }

        if (pickedObject || heldObj != null)
        {
            //move obj
            MoveObject();
        }
    }
    void MoveObject()
    {
        //followPoint.transform.position = heldObj.transform.position;
        if (Vector3.Distance(heldObj.transform.position, followPoint.position) > 0.1f)
        {

            Vector3 moveDirection = (followPoint.position - heldObj.transform.position) * pickedObjDistance;
            heldObjRB.AddForce(moveDirection * pickupForce);
            if (canRotate)
            {
                Vector3 thingerer = new Vector3(0f, -GameControls.cameraAxis.y, -GameControls.cameraAxis.x);
                heldObj.transform.Rotate(thingerer * objRotationForce * Time.deltaTime);
            }
        }


    }
    void PickupObject(GameObject pickObj)
    {
        if (!objIsOnPC)
        {
            if (pickObj.GetComponent<Rigidbody>())
            {
                infotxt.text = pickObj.GetComponent<objectScript>().name + "\n" + pickObj.GetComponent<objectScript>().other;
                heldObjRB = pickObj.GetComponent<Rigidbody>();

                heldObjRB.linearDamping = 10;
                if (canRotate)
                {
                    heldObjRB.constraints = RigidbodyConstraints.None;
                }
                else
                {
                    heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;
                }
                heldObjRB.transform.parent = parent;
                heldObj = pickObj;

            }
        }
        else
        {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObj = pickObj;

        }
    }
    void DropObject()
    {


        if (heldObjRB != null && heldObj != null)
        {
            infotxt.text = "";


            heldObjRB.useGravity = true;
            heldObjRB.linearDamping = 1;
            heldObjRB.constraints = RigidbodyConstraints.None;
            heldObjRB.transform.gameObject.GetComponent<Collider>().excludeLayers = 0;
            heldObjRB.transform.parent = null;
            heldObj = null;
        }

    }
}
