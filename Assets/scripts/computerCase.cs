using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class computerCase : MonoBehaviour
{
  public pcOS pcOS;
  public pcOS noOS;
  public computerMonitor currentMonitor;
  public bool hasHDD1 = false;
  public bool hasHDD2 = false;
  public bool hasHDD3 = false;
  public bool hasMOBO = false;
  public bool hasPowerSupply = false;
  public bool hasCPU = false;
  public bool hasRAM1 = false;
  public bool hasRAM2 = false;
  public bool hasGPU = false;
  public bool hasCPUFan = false;

  [Header("past pc parts")]

  public bool hadGPU = false;
  public bool hadHDD1 = false;
  public bool hadHDD2 = false;
  public bool hadHDD3 = false;
  public bool hadRAM1 = false;
  public bool hadRAM2 = false;
  public GameObject hdd1;
  public GameObject hdd2;
  public GameObject hdd3;
  public GameObject mobo;
  public GameObject powerSupply;
  public GameObject cpu;
  public GameObject ram1;
  public GameObject ram2;
  public GameObject gpu;
  public GameObject cpuFan;
  public GameObject onLight;
  public List<GameObject> hddList;


  public LayerMask caseLayer;
  bool cpuFanChecked = false;
  [Header("pcos thing")]
  public bool isPcON = false;

    [Header("audio thing")]
    public AudioSource pcAudio;

  //other

  objectScript cpuBeforeBurning;

  void Start()
  {
    noOS.gameObject.SetActive(true);
  }


  void Update()
  {
    if (hasMOBO)
    {
      ram1 = mobo.GetComponent<moboScript>().ram1;
      ram2 = mobo.GetComponent<moboScript>().ram2;
      cpu = mobo.GetComponent<moboScript>().cpu;
      gpu = mobo.GetComponent<moboScript>().gpu;
      cpuFan = mobo.GetComponent<moboScript>().cpuFan;

      hasCPU = mobo.GetComponent<moboScript>().hasCPU;
      hasGPU = mobo.GetComponent<moboScript>().hasGPU;
      hasRAM1 = mobo.GetComponent<moboScript>().hasRAM1;
      hasRAM2 = mobo.GetComponent<moboScript>().hasRAM2;
      hasCPUFan = mobo.GetComponent<moboScript>().hasCPUFan;
    }
    else
    {
      ram1 = null;
      ram2 = null;
      cpu = null;
      gpu = null;
      cpuFan = null;

      hasCPU = false;
      hasGPU = false;
      hasRAM1 = false;
      hasRAM2 = false;
      hasCPUFan = false;
    }
    if (isPcON)
    {

      if (hasMOBO && hasPowerSupply && hasCPU)
      {
        if (cpu.GetComponent<objectScript>().isObjDamaged == true)
        {
          //cpu is damaged
          StartCoroutine(main.setErrorMessage("CPU is burned!"));
          isPcON = false;

        }
        else
          onLight.SetActive(true);

        if (hadRAM1)
        {
          if (!hasRAM1)
          {
            pcOS.onBSOD = true;
          }
        }
        if (!hadRAM1)
        {
          if (hasRAM1)
          {
            pcOS.onBSOD = true;
          }
        }

        if (hadRAM2)
        {
          if (!hasRAM2)
          {
            pcOS.onBSOD = true;
          }
        }
        if (!hadRAM2)
        {
          if (hasRAM2)
          {
            pcOS.onBSOD = true;
          }
        }

        if (hadGPU)
        {
          if (!hasGPU)
          {
            pcOS.onBSOD = true;
          }
        }
        if (!hadGPU)
        {
          if (hasGPU)
          {
            pcOS.onBSOD = true;
          }
        }

        if (hadHDD1)
        {
          if (!hasHDD1)
          {
            pcOS.onBSOD = true;
          }
        }
        if (!hadHDD1)
        {
          if (hasHDD1)
          {
            pcOS.onBSOD = true;
          }
        }

        if (hadHDD2)
        {
          if (!hasHDD2)
          {
            pcOS.onBSOD = true;
          }
        }
        if (!hadHDD2)
        {
          if (hasHDD2)
          {
            pcOS.onBSOD = true;
          }
        }

        if (hadHDD3)
        {
          if (!hasHDD3)
          {
            pcOS.onBSOD = true;
          }
        }
        if (!hadHDD3)
        {
          if (hasHDD3)
          {
            pcOS.onBSOD = true;
          }
        }
        if (!hasCPUFan)
        {
          if (!cpuFanChecked)
          {
            if (cpu.GetComponent<objectScript>().isObjDamaged == false)
            {
              cpuBeforeBurning = cpu.GetComponent<objectScript>();
              Invoke("burnCpu", UnityEngine.Random.Range(3, 10));
              cpuFanChecked = true;
            }
          }

        }
        else
        {
          cpuFanChecked = false;
        }

      }
      else
      {
        isPcON = false;
      }
    }
    else
    {
      onLight.SetActive(false);

      hadGPU = hasGPU;
      hadHDD1 = hasHDD1;
      hadHDD2 = hasHDD2;
      hadHDD3 = hasHDD3;
      hadRAM1 = hasRAM1;
      hadRAM2 = hasRAM2;
      if (hddList.Count > 0)
      {

        pcOS = hddList[0].GetComponentInChildren<pcOS>();
        noOS.pcOSCanvas.worldCamera = null;
      }
      else
      {

        if (pcOS != null)
        {
          pcOS.pcOSCanvas.worldCamera = null;
        }





        pcOS = noOS;
      }
      if (hasRAM1 || hasRAM2)
      {

      }
      else
      {
        pcOS.pcOSCanvas.worldCamera = null;
      }




    }
  }
  public void burnCpu()
  {
    if (isPcON)
    {
      if (cpuBeforeBurning == cpu.GetComponent<objectScript>())
        cpu.GetComponent<objectScript>().isObjDamaged = true;
    }
  }
}