using UnityEngine;

public class objectScript : MonoBehaviour
{
    public Transform parent;
    public bool isOnPC = false;
    public bool isObjDamaged = false;
    public CompType type;
    public enum CompType { Case, CPU, GPU, Motherboard, Power_Supply, Hard_Drive, RAM, CPU_Fan, Nothing, Monitor, Speaker };
    public string name = "Thinger";
    public string other = "";
    public int value = 100;
    public int value2 = 100;
    public int life = 100;
    [Header("Common stuff")]
    public int price = 100;
    public int launchYear = 2000;
    public float objSpeed = 2.2f;
    public int tdp = 84;

    [Header("RAM Stuff")]

    public int ramSize = 1024;
    public RamType ramType;
    public enum RamType { SDR, DDR, DDR2, DDR3, None };

    [Header("Motherboard Stuff")]


    public MoboBrand moboBrand;
    public enum MoboBrand { Viostar, Megabyte, ASSRock, AZUZ, MZI, Entel };
    public CPUSocket moboSocket;
    public FormFactor moboFormFactor;
    public RamType moboRamType;
    public RamType moboRamTypeSec;
    public bool hasiGPU = false;
    public string moboChipset = "";

    public int ramSpaces = 2;
    public int pciSlots;
    public int pcieSlots = 0;
    public int agpSlots;
    [Header("GPU Stuff")]
    public GPUBrand gpuBrand;
    public enum GPUSocket { AGP, PCI, PCIe };
    public GPUSocket gpuSocket;
    public int vram = 256;
    public string gpuType = "DDR1";
    public int tmus = 4;
    public int rops = 4;

    public enum GPUBrand { Mvidia, AND, ATY };
    [Header("Case Stuff")]

    public FormFactor formFactor;
    public enum FormFactor { ATX, Micro_ATX, Mini_ITX, E_ATX };
    public int hddSpaces = 3;


    [Header("CPU Fan Stuff")]

    public string compatibleSockets = "Socket A/Socket 423/Socket 478/LGA775";
    public int fanSpeed = 1700;

    [Header("Monitor Stuff")]

    public string resolution = "800x600";
    public string ratio = "4:3";

    [Header("HDD Stuff")]

    public string hddType = "HDD";
    public int storage = 120;
    public string hddInterface = "IDE";





    [Header("CPU Stuff")]
    public CPUBrand cpuBrand;
    public enum CPUBrand { Entel, AND };
    public CPUSocket cpuSocket;
    public int cores = 1;
    public int threads = 2;

    public enum CPUSocket { Socket_A, Socket_478, Socket_939, LGA775, Socket_754, Socket_423 };



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
        if (type == CompType.CPU_Fan)
            speed = fanSpeed - 1000f;

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


                            speedtemp += 0.5f;
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
