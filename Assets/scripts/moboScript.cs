using UnityEngine;

public class moboScript : MonoBehaviour
{

      public LayerMask moboLayer;

      public bool hasRAM1 = false;
      public bool hasRAM2 = false;
      public bool hasCPU = false;
      public bool hasGPU1 = false;
      public bool hasGPU2 = false;
      public bool hasGPU3 = false;
      public bool hasCPUFan = false;

      public GameObject cpu;
      public GameObject ram1;
      public GameObject ram2;
      public GameObject gpu1;
      public GameObject gpu2;
      public GameObject gpu3;
      public GameObject cpuFan;
      public enum MoboCpuSocket { Socket_A, Socket_478, Socket_939, LGA775, Socket_754, Socket_423 };
      public MoboCpuSocket moboCpuSocket;
}
