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
          level levelthing = new level();
        levelthing.levelObjs = FindObjectsOfType<GameObject>();
        string levelData = JsonConvert.SerializeObject(levelthing);
        Debug.Log("Saving progress...");
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
      
        //File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + "/saveFiles/" + levelName + "/level.json", "HAAHA");
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
    void Update()
    {

    }
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
