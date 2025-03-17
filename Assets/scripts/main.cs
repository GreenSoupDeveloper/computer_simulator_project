using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using Newtonsoft.Json;
public class main : MonoBehaviour
{
    public TextMeshProUGUI texter;

    public static TextMeshProUGUI errortxt;




    public static TextMeshProUGUI infotxt;
    public static int fps;
    public static bool errorfade = true;
    public static bool infofade = true;
    public static string levelName = "tingledingle";
    public static level levelthing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        errortxt = GameObject.Find("errortxt").GetComponent<TextMeshProUGUI>();
        errortxt.text = "";

        infotxt = GameObject.Find("centerInfoText").GetComponent<TextMeshProUGUI>();
        infotxt.text = "";
        fpsUpd();
    }

    public static void createLevel()
    {
        if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "/saveFiles"))
        {
            Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "/saveFiles");
        }
    }
    public static void saveProgress()
    {


        levelthing = new level();
        GameObject[] objs = FindObjectsOfType<GameObject>();
        List<GameObject> objList = new List<GameObject>();
        int objLayer = LayerMask.NameToLayer("GrabbableObj");
        int pcLayer = LayerMask.NameToLayer("PcCaseLayer");
        int moboLayer = LayerMask.NameToLayer("MoboLayer");
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].layer == objLayer || objs[i].layer == pcLayer || objs[i].layer == moboLayer)
            {
                if (objs[i].GetComponent<objectScript>() != null)
                {
                    objList.Add(objs[i]);
                }
                else
                {
                    continue;
                }
            }
        }

        levelthing.levelObjs = new levelObject[objList.Count];




        for (int i = 0; i < objList.Count; i++)
        {
            levelthing.levelObjs[i] = new levelObject();
            if (objList[i].GetComponent<objectScript>() != null)
            {
                string objName = objList[i].name;
                if (objName.Contains("("))
                {
                    objName = objName.Substring(0, (objName.IndexOf("(") - 1));
                    Debug.Log("objName: " + objName);
                }
                if (objList[i].GetComponent<objectScript>().type == objectScript.CompType.Case)
                {
                    levelthing.levelObjs[i].prefabLocation = "prefabs/cases/" + objName;
                }
                else if (objList[i].GetComponent<objectScript>().type == objectScript.CompType.Motherboard)
                {
                    levelthing.levelObjs[i].prefabLocation = "prefabs/mobos/" + objName;
                }
                else if (objList[i].GetComponent<objectScript>().type == objectScript.CompType.Power_Supply)
                {
                    levelthing.levelObjs[i].prefabLocation = "prefabs/powersupply/" + objName;
                }
                else if (objList[i].GetComponent<objectScript>().type == objectScript.CompType.GPU)
                {
                    levelthing.levelObjs[i].prefabLocation = "prefabs/gpus/" + objName;
                }
                else if (objList[i].GetComponent<objectScript>().type == objectScript.CompType.CPU)
                {
                    if (objList[i].GetComponent<objectScript>().cpuBrand == objectScript.CPUBrand.Entel)
                    {
                        GameObject test1 = (GameObject)Resources.Load("prefabs/cpus/intel/penthium_4/" + objName);
                        if (test1 != null)
                        {
                            levelthing.levelObjs[i].prefabLocation = "prefabs/cpus/intel/penthium_4/" + objName;
                        }
                        else
                        {
                            GameObject test2 = (GameObject)Resources.Load("prefabs/cpus/intel/penthium_3/" + objName);
                            if (test2 != null)
                            {
                                levelthing.levelObjs[i].prefabLocation = "prefabs/cpus/intel/penthium_3/" + objName;
                            }
                            else
                            {
                                levelthing.levelObjs[i].prefabLocation = "prefabs/cpus/intel/seleron/" + objName;
                            }
                        }

                    }
                    else
                    {
                        GameObject test1 = (GameObject)Resources.Load("prefabs/cpus/amd/buron/" + objName);
                        if (test1 != null)
                        {
                            levelthing.levelObjs[i].prefabLocation = "prefabs/cpus/amd/buron/" + objName;
                        }
                        else
                        {
                            GameObject test2 = (GameObject)Resources.Load("prefabs/cpus/amd/cempron/" + objName);
                            if (test2 != null)
                            {
                                levelthing.levelObjs[i].prefabLocation = "prefabs/cpus/amd/cempron/" + objName;
                            }
                            else
                            {
                                GameObject test3 = (GameObject)Resources.Load("prefabs/cpus/amd/ethlon_64/" + objName);
                                if (test3 != null)
                                {
                                    levelthing.levelObjs[i].prefabLocation = "prefabs/cpus/amd/ethlon_64/" + objName;
                                }
                                else
                                {
                                    GameObject test4 = (GameObject)Resources.Load("prefabs/cpus/amd/ethlon_64_X2/" + objName);
                                    if (test4 != null)
                                    {
                                        levelthing.levelObjs[i].prefabLocation = "prefabs/cpus/amd/ethlon_64_X2/" + objName;
                                    }else{
                                        levelthing.levelObjs[i].prefabLocation = "prefabs/cpus/amd/ethlon_xp/" + objName;
                                    }
                                }
                            }
                        }
                    }

                }
                else if (objList[i].GetComponent<objectScript>().type == objectScript.CompType.RAM)
                {


                    GameObject test1 = (GameObject)Resources.Load("prefabs/rams/sdr/" + objName);
                    if (test1 != null)
                    {
                        levelthing.levelObjs[i].prefabLocation = "prefabs/rams/sdr/" + objName;
                    }
                    else
                    {
                        GameObject test2 = (GameObject)Resources.Load("prefabs/rams/ddr1/" + objName);
                        if (test2 != null)
                        {
                            levelthing.levelObjs[i].prefabLocation = "prefabs/rams/ddr1/" + objName;
                        }
                        else
                        {
                            levelthing.levelObjs[i].prefabLocation = "prefabs/rams/ddr2/" + objName;
                        }
                    }


                }
                else if (objList[i].GetComponent<objectScript>().type == objectScript.CompType.Hard_Drive)
                {
                    levelthing.levelObjs[i].prefabLocation = "prefabs/hdds/" + objName;

                }
                else if (objList[i].GetComponent<objectScript>().type == objectScript.CompType.CPU_Fan)
                {
                    levelthing.levelObjs[i].prefabLocation = "prefabs/fans/" + objName;
                }
                else if (objList[i].GetComponent<objectScript>().type == objectScript.CompType.Speaker)
                {
                    levelthing.levelObjs[i].prefabLocation = "prefabs/speakers/" + objName;
                }
                else if (objList[i].GetComponent<objectScript>().type == objectScript.CompType.Monitor)
                {
                    levelthing.levelObjs[i].prefabLocation = "prefabs/screens/" + objName;
                }
                else if (objList[i].GetComponent<objectScript>().type == objectScript.CompType.Nothing)
                {
                    levelthing.levelObjs[i].prefabLocation = "prefabs/misc/" + objName;
                }
                else
                {
                    levelthing.levelObjs[i].prefabLocation = objName;
                    Debug.Log("obj '" + objName + "' was weird when saving..");
                    continue;
                }
            }
            else
            {
                Debug.Log("obj '" + objList[i].name + "' doesnt have a objectscript..");
                continue;
            }


            levelthing.levelObjs[i].objPosX = objList[i].transform.position.x;
            levelthing.levelObjs[i].objPosY = objList[i].transform.position.y;
            levelthing.levelObjs[i].objPosZ = objList[i].transform.position.z;
            levelthing.levelObjs[i].objRotX = objList[i].transform.rotation.x;
            levelthing.levelObjs[i].objRotY = objList[i].transform.rotation.y;
            levelthing.levelObjs[i].objRotZ = objList[i].transform.rotation.z;
        }

        Debug.Log("Saving progress...");
        if (!Application.isEditor)
        {
            if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "/saveFiles"))
            {
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "/saveFiles");
            }

            Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "/saveFiles/" + levelName);
            hardDrive[] hdds = FindObjectsOfType<hardDrive>();
            for (int i = 0; i < hdds.Length; i++)
            {
                if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "/saveFiles/" + levelName + "/" + hdds[i].hdName))
                    Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "/saveFiles/" + levelName + "/" + hdds[i].hdName);
            }
            File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + "/saveFiles/" + levelName + "/level.json", JsonConvert.SerializeObject(levelthing));

        }
        else
        {
            File.WriteAllText("Assets/saveFiles/" + levelName + "/level.json", JsonConvert.SerializeObject(levelthing));
        }



    }
    public static void loadProgress()
    {
        levelthing = new level();
        if (!Application.isEditor)
        {
            levelthing = JsonConvert.DeserializeObject<level>(File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "/saveFiles/" + levelName + "/level.json"));
        }
        else
        {
            levelthing = JsonConvert.DeserializeObject<level>(File.ReadAllText("Assets/saveFiles/" + levelName + "/level.json"));
        }

        for (int i = 0; i < levelthing.levelObjs.Length; i++)
        {
            if (levelthing.levelObjs[i].prefabLocation != null)
            {
                GameObject curObj = (GameObject)Resources.Load(levelthing.levelObjs[i].prefabLocation + "");
                if (curObj != null)
                    Instantiate(curObj, new Vector3(levelthing.levelObjs[i].objPosX, levelthing.levelObjs[i].objPosY, levelthing.levelObjs[i].objPosZ), new Quaternion(levelthing.levelObjs[i].objRotX, levelthing.levelObjs[i].objRotY, levelthing.levelObjs[i].objRotZ, 0));
                else
                    Debug.Log("'" + levelthing.levelObjs[i].prefabLocation + "' prefab doesnt exist!");
            }
        }








    }
    public static IEnumerator setErrorMessage(string thinger)
    {
        main.errortxt.text = thinger;
        main.infotxt.text = "";
        main.infofade = true;
        main.errorfade = false;
        main.errortxt.alpha = 1f;
        yield return new WaitForSeconds(1.7f);
        main.errorfade = true;

    }

    public static IEnumerator setInfoMessage(string thinger)
    {
        main.infotxt.text = thinger;
        main.errortxt.text = "";
        main.errorfade = true;
        main.infofade = false;
        main.infotxt.alpha = 1f;
        yield return new WaitForSeconds(1.7f);
        main.infofade = true;

    }

    // Update is called once per frame

    void fpsUpd()
    {
        if (errorfade)
        {
            errortxt.alpha -= 0.25f;
        }
        if (infofade)
        {
            infotxt.alpha -= 0.25f;
        }

        fps = (int)(1f / Time.unscaledDeltaTime);


        //texter.text = "FPS: " + fps;

        Invoke("fpsUpd", 0.25f);
    }
}
