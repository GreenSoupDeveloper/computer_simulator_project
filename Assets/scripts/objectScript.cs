using UnityEngine;

public class objectScript : MonoBehaviour
{
    public Transform parent;
    public bool isOnPC = false;
    public CompType type;
    public enum CompType { Case, CPU, GPU, Motherboard, Power_Supply, Hard_Drive, RAM, CPU_Fan, Nothing };
    public string name = "Thinger";
    public string other = "";
    public int value = 100;
    public int life = 100;
    
    [Header("CPU Stuff")]
    public CPUBrand cpuBrand;

    public enum CPUBrand {Intel, AMD};

    [Header("GPU Stuff")]
    public GPUBrand gpuBrand;

    public enum GPUBrand {Nvidia, AMD, ATI};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isOnPC)
        {
            if (this.gameObject.transform.position.y < -0.1f)
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0.5f, this.gameObject.transform.position.z);
            }
        }
    }
}
