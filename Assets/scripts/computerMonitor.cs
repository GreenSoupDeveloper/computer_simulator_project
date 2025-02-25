using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class computerMonitor : MonoBehaviour
{
    public pcOS currpcOS;
    public Camera monitorCam;
    public RenderTexture monitorTex;
    public Material monitorMat;
    public Material monitorEmptyMat;
    public MeshRenderer monitorScreen;
    public computerMonitor[] monitores;
    public computerCase[] computers;
    public bool onLeComputahr = false;
    public bool skipDiddy = false;
    public bool clear = false;

    void Start()
    {
        monitorTex = new RenderTexture(1280, 720, 24);

        // Step 2: Configure the Render Texture (optional)
        monitorTex.format = RenderTextureFormat.ARGB32; // Set the format
        monitorTex.autoGenerateMips = false;            // Disable auto mipmaps
        monitorTex.Create();
        Shader urpShader = Shader.Find("Universal Render Pipeline/Lit");
        monitorMat = new Material(urpShader);
        //Set Texture on the material
        monitorMat.SetTexture("_BaseMap", monitorTex);
        monitorMat.SetFloat("_Smoothness", 0f);

        monitorCam.targetTexture = monitorTex;
        monitorScreen.material = monitorMat;
    }
    void Update()
    {
        monitores = FindObjectsOfType<computerMonitor>();
        computers = FindObjectsOfType<computerCase>();
        if (onLeComputahr)
        {

        }
        else
        {
            if (currpcOS != null)
                currpcOS.pcOSCanvas.worldCamera = null;
        }


        foreach (computerCase cp in computers)
        {

            if (cp.currentMonitor == this)
            {
                onLeComputahr = true;
                currpcOS = cp.pcOS;
                skipDiddy = true;
                currpcOS.OScam = monitorCam;

                foreach (computerMonitor mn in monitores)
                {
                    if (mn.gameObject != this.gameObject)
                    {
                        if (mn.currpcOS != null)
                        {
                            if (mn.currpcOS.pcOSCanvas.worldCamera == monitorCam)
                            {

                                Debug.Log(mn.currpcOS.pcOSCanvas.worldCamera + " = " + monitorCam);
                                mn.currpcOS = null;
                            }
                        }
                    }



                }
            }
            else
            {
                if (!skipDiddy)
                {
                    onLeComputahr = false;
                    

                }
            }
        }
        if (!onLeComputahr)
        {
            if (currpcOS != null)
            {
                Debug.Log("monitor is for some reason off andn different to null");
                currpcOS.pcOSCanvas.worldCamera = null;
            }
            currpcOS = null;
        }
        else
        {
            currpcOS.pcOSCanvas.worldCamera = monitorCam;
        }
       

        skipDiddy = false;
        if(clear){
            currpcOS.pcOSCanvas.worldCamera = null;
            clear = false;
        }
       





    }


}