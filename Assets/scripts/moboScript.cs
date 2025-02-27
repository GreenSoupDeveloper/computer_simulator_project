using UnityEngine;

public class moboScript : MonoBehaviour
{

      public LayerMask moboLayer;

      public bool hasRAM1 = false;
      public bool hasRAM2 = false;
      public bool hasCPU = false;
      public bool hasGPU = false;
      public bool hasCPUFan = false;

      public GameObject cpu;
      public GameObject ram1;
      public GameObject ram2;
      public GameObject gpu;
      public GameObject cpuFan;
      public enum MoboCpuSocket { Socket_A,S478,  S939, S775 };
      public MoboCpuSocket moboCpuSocket;
}
