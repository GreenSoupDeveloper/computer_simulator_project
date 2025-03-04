using Unity.VisualScripting;
using UnityEngine;

public class moboObjDetecter : MonoBehaviour
{
    public moboScript curMobo;
    public MoboObjDetecterType thisObjType;
    public enum MoboObjDetecterType { CPU, GPU, RAM, CPU_Fan };
    public AudioSource audioSrc;
    public AudioClip pop;
    [Header("RAM stuff")]
    //if false: ram2, if true: ram1
    public int ramSlot = 1;
    public objectScript.RamType ramSocket;
    public objectScript.RamType ramSocketSec;
    [Header("GPU stuff")]
    //if false: ram2, if true: ram1
    public int gpuSlot = 1;
    public objectScript.GPUSocket gpuSocket;
    [Header("CPU stuff")]
    public objectScript.CPUSocket cpuSocket;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<objectScript>().type == objectScript.CompType.CPU && thisObjType == MoboObjDetecterType.CPU)
        {
            if (!curMobo.hasCPU)
            {
                if (!curMobo.hasCPUFan)
                {
                    if (other.gameObject.GetComponent<objectScript>().cpuSocket == cpuSocket)
                    {
                        other.gameObject.transform.parent = this.gameObject.transform;
                        other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        other.gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
                        other.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                        other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.015f, gameObject.transform.position.z);
                        curMobo.hasCPU = true;
                        other.gameObject.GetComponent<objectScript>().isOnPC = true;
                        other.gameObject.GetComponent<objectScript>().parent = this.gameObject.transform;
                        other.gameObject.GetComponent<Collider>().excludeLayers = curMobo.moboLayer;
                        if (pickupController.heldObj == other.gameObject)
                        {
                            pickupController.heldObj = null;
                            pickupController.pickedObject = false;
                            pickupController.heldObjRB = null;
                        }

                        curMobo.cpu = other.gameObject;
                        audioSrc.PlayOneShot(pop);
                    }
                    else
                    {
                        Debug.Log("cpu socket mismatch!");
                    }
                }
                else
                {
                    Debug.Log("mobo has a cpu fan, remove it!!");
                }

            }
            else
            {
                Debug.Log("mobo already has a cpu!");
            }
        }
        if (other.gameObject.GetComponent<objectScript>().type == objectScript.CompType.RAM && thisObjType == MoboObjDetecterType.RAM)
        {
            if (ramSlot == 1)
            {
                if (!other.gameObject.GetComponent<objectScript>().isOnPC)
                {

                    if (!curMobo.hasRAM1)
                    {
                        if (other.gameObject.GetComponent<objectScript>().ramType == ramSocket || other.gameObject.GetComponent<objectScript>().ramType == ramSocketSec)
                        {
                            other.gameObject.GetComponent<objectScript>().isOnPC = true;
                            other.gameObject.transform.parent = this.gameObject.transform;
                            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            other.gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
                            other.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                            other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.015f, gameObject.transform.position.z);
                            curMobo.hasRAM1 = true;

                            other.gameObject.GetComponent<objectScript>().parent = this.gameObject.transform;
                            other.gameObject.GetComponent<Collider>().excludeLayers = curMobo.moboLayer;
                            if (pickupController.heldObj == other.gameObject)
                            {
                                pickupController.heldObj = null;
                                pickupController.pickedObject = false;
                                pickupController.heldObjRB = null;
                            }

                            curMobo.ram1 = other.gameObject;
                            audioSrc.PlayOneShot(pop);
                        }
                        else
                        {
                            Debug.Log("ram socket mismatch!");
                        }
                    }
                    else
                    {
                        Debug.Log("mobo already has a ram 1 stick!");
                    }
                }
                else
                {
                    Debug.Log("mobo already has a ram 1 stick!");
                }
            }
            else if (ramSlot == 2)
            {
                if (!other.gameObject.GetComponent<objectScript>().isOnPC)
                {
                    if (!curMobo.hasRAM2)
                    {
                        if (other.gameObject.GetComponent<objectScript>().ramType == ramSocket || other.gameObject.GetComponent<objectScript>().ramType == ramSocketSec)
                        {
                            other.gameObject.transform.parent = this.gameObject.transform;
                            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            other.gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
                            other.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                            other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.015f, gameObject.transform.position.z);
                            curMobo.hasRAM2 = true;
                            other.gameObject.GetComponent<objectScript>().isOnPC = true;
                            other.gameObject.GetComponent<objectScript>().parent = this.gameObject.transform;
                            other.gameObject.GetComponent<Collider>().excludeLayers = curMobo.moboLayer;

                            if (pickupController.heldObj == other.gameObject)
                            {
                                pickupController.heldObj = null;
                                pickupController.pickedObject = false;
                                pickupController.heldObjRB = null;
                            }


                            curMobo.ram2 = other.gameObject;
                            audioSrc.PlayOneShot(pop);
                        }
                        else
                        {
                            Debug.Log("ram socket mismatch!");
                        }
                    }
                    else
                    {
                        Debug.Log("mobo already has a ram 2 stick!");
                    }
                }
                else
                {
                    Debug.Log("mobo already has a ram 2 stick!");
                }

            }
        }

        if (other.gameObject.GetComponent<objectScript>().type == objectScript.CompType.CPU_Fan && thisObjType == MoboObjDetecterType.CPU_Fan)
        {
            if (!curMobo.hasCPUFan)
            {
                other.gameObject.transform.parent = this.gameObject.transform;
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
                other.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.015f, gameObject.transform.position.z);
                curMobo.hasCPUFan = true;
                other.gameObject.GetComponent<objectScript>().isOnPC = true;
                other.gameObject.GetComponent<objectScript>().parent = this.gameObject.transform;
                other.gameObject.GetComponent<Collider>().excludeLayers = curMobo.moboLayer;
                if (pickupController.heldObj == other.gameObject)
                {
                    pickupController.heldObj = null;
                    pickupController.pickedObject = false;
                    pickupController.heldObjRB = null;
                }
                curMobo.cpuFan = other.gameObject;
                audioSrc.PlayOneShot(pop);
            }
            else
            {
                Debug.Log("mobo already has a cpu fan!");
            }
        }
        if (other.gameObject.GetComponent<objectScript>().type == objectScript.CompType.GPU && thisObjType == MoboObjDetecterType.GPU)
        {
            if (gpuSlot == 1)
            {
                if (!other.gameObject.GetComponent<objectScript>().isOnPC)
                {
                    if (!curMobo.hasGPU1)
                    {
                        if (other.gameObject.GetComponent<objectScript>().gpuSocket == gpuSocket)
                        {
                            other.gameObject.transform.parent = this.gameObject.transform;
                            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            other.gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
                            other.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                            other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.015f, gameObject.transform.position.z);
                            curMobo.hasGPU1 = true;
                            other.gameObject.GetComponent<objectScript>().isOnPC = true;
                            other.gameObject.GetComponent<objectScript>().parent = this.gameObject.transform;
                            other.gameObject.GetComponent<Collider>().excludeLayers = curMobo.moboLayer;
                            if (pickupController.heldObj == other.gameObject)
                            {
                                pickupController.heldObj = null;
                                pickupController.pickedObject = false;
                                pickupController.heldObjRB = null;
                            }
                            curMobo.gpu1 = other.gameObject;
                            audioSrc.PlayOneShot(pop);
                        }
                        else
                        {
                            Debug.Log("gpu socket mismatch!");
                        }
                    }
                    else
                    {
                        Debug.Log("mobo already has a gpu!");
                    }
                }
                else
                {
                    Debug.Log("mobo already has a gpu!");
                }
            }
            else if (gpuSlot == 2)
            {
                if (!other.gameObject.GetComponent<objectScript>().isOnPC)
                {
                    if (!curMobo.hasGPU2)
                    {
                        if (other.gameObject.GetComponent<objectScript>().gpuSocket == gpuSocket)
                        {


                            other.gameObject.transform.parent = this.gameObject.transform;
                            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            other.gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
                            other.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                            other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.015f, gameObject.transform.position.z);
                            curMobo.hasGPU2 = true;
                            other.gameObject.GetComponent<objectScript>().isOnPC = true;
                            other.gameObject.GetComponent<objectScript>().parent = this.gameObject.transform;
                            other.gameObject.GetComponent<Collider>().excludeLayers = curMobo.moboLayer;
                            if (pickupController.heldObj == other.gameObject)
                            {
                                pickupController.heldObj = null;
                                pickupController.pickedObject = false;
                                pickupController.heldObjRB = null;
                            }

                            curMobo.gpu2 = other.gameObject;
                            audioSrc.PlayOneShot(pop);
                        }
                        else
                        {
                            Debug.Log("gpu socket mismatch!");
                        }
                    }
                    else
                    {
                        Debug.Log("mobo already has a gpu!");
                    }
                }
                else
                {
                    Debug.Log("mobo already has a gpu!");
                }
            }
            else if (gpuSlot == 3)
            {
                if (!other.gameObject.GetComponent<objectScript>().isOnPC)
                {
                    if (!curMobo.hasGPU3)
                    {
                        if (other.gameObject.GetComponent<objectScript>().gpuSocket == gpuSocket)
                        {
                            other.gameObject.transform.parent = this.gameObject.transform;
                            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            other.gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
                            other.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                            other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.015f, gameObject.transform.position.z);
                            curMobo.hasGPU3 = true;
                            other.gameObject.GetComponent<objectScript>().isOnPC = true;
                            other.gameObject.GetComponent<objectScript>().parent = this.gameObject.transform;
                            other.gameObject.GetComponent<Collider>().excludeLayers = curMobo.moboLayer;
                            if (pickupController.heldObj == other.gameObject)
                            {
                                pickupController.heldObj = null;
                                pickupController.pickedObject = false;
                                pickupController.heldObjRB = null;
                            }

                            curMobo.gpu3 = other.gameObject;
                            audioSrc.PlayOneShot(pop);
                        }
                        else
                        {
                            Debug.Log("gpu socket mismatch!");
                        }
                    }
                    else
                    {
                        Debug.Log("mobo already has a gpu!");
                    }
                }
                else
                {
                    Debug.Log("mobo already has a gpu!");
                }
            }


        }
    }
}
