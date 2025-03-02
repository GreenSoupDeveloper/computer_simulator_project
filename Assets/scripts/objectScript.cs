using UnityEngine;

public class objectScript : MonoBehaviour
{
    public Transform parent;
    public bool isOnPC = false;
    public bool isObjDamaged = false;
    public CompType type;
    public enum CompType { Case, CPU, GPU, Motherboard, Power_Supply, Hard_Drive, RAM, CPU_Fan, Nothing };
    public string name = "Thinger";
    public string other = "";
    public int value = 100;
    public int life = 100;
    [Header("Common stuff")]
    public int price = 100;
    public int launchYear = 2000;
    public float objSpeed = 2.2f;
    public int tdp = 84;


 [Header("GPU Stuff")]
    public GPUBrand gpuBrand;
    public int vram = 256;
    public string gpuType = "DDR1";
    public int tmus = 4;
    public int rops = 4;

    public enum GPUBrand { Nvidia, AMD, ATI };
    [Header("RAM Stuff")]

    public int ramSize = 1024;
    public string ramType = "DDR2";

    [Header("CPU Stuff")]
    public CPUBrand cpuBrand;
    public enum CPUBrand { Intel, AMD };
    public CPUSocket cpuSocket;
    public int cores = 1;
    public int threads = 2;
    
    public enum CPUSocket { Socket_A, Socket_478, Socket_939, LGA775, Socket_754,Socket_423 };

   

    [Header("Fan stuff")]

    public GameObject fanObj;
    public float speed = 12f;
    float speedtemp = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!isOnPC)
        {
            if (speedtemp > 0f)
            {
                speedtemp -= 0.1f;
            }
            else
            {
                speedtemp = 0f;
            }

            if (this.gameObject.transform.position.y < -0.1f)
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0.03f, this.gameObject.transform.position.z);
            }
        }
        else
        {
            if (type == CompType.CPU_Fan || type == CompType.GPU || type == CompType.Power_Supply)
            {
                if (parent.GetComponentInParent<computerCase>() != null)
                {
                    if (parent.GetComponentInParent<computerCase>().isPcON)
                    {
                        if (speedtemp < speed)
                        {
                            speedtemp += 0.25f;
                        }

                    }
                    else
                    {
                        if (speedtemp > 0f)
                        {
                            speedtemp -= 0.1f;
                        }
                        else
                        {
                            speedtemp = 0f;
                        }
                    }
                }
                else
                {
                    if (speedtemp > 0f)
                    {
                        speedtemp -= 0.1f;
                    }
                    else
                    {
                        speedtemp = 0f;
                    }
                }
            }
        }
        if (fanObj != null)
            fanObj.transform.Rotate(0, 0, speedtemp);
    }
}
