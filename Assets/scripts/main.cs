using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class main : MonoBehaviour
{
    public TextMeshProUGUI texter;
    public static TextMeshProUGUI errortxt;


    public static TextMeshProUGUI infotxt;
        public static int fps;
        public static bool errorfade = true;
        public static bool infofade = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        errortxt = GameObject.Find("errortxt").GetComponent<TextMeshProUGUI>();
        errortxt.text = "";

        infotxt = GameObject.Find("centerInfoText").GetComponent<TextMeshProUGUI>();
        infotxt.text = "";
        fpsUpd();
    }
    public static IEnumerator setErrorMessage(string thinger){
        main.errortxt.text = thinger;
        main.infotxt.text = "";
        main.infofade = true;
        main.errorfade = false;
        main.errortxt.alpha = 1f;
        yield return new WaitForSeconds(2f);
        main.errorfade = true;
        
    }

    public static IEnumerator setInfoMessage(string thinger){
        main.infotxt.text = thinger;
        main.errortxt.text = "";
        main.errorfade = true;
        main.infofade = false;
        main.infotxt.alpha = 1f;
        yield return new WaitForSeconds(2f);
        main.infofade = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void fpsUpd()
    {
        if(errorfade){
            errortxt.alpha -= 0.25f;
        }
        if(infofade){
            infotxt.alpha -= 0.25f;
        }

        fps = (int)(1f / Time.unscaledDeltaTime);
        
       
            texter.text = "FPS: " + fps;
        
        Invoke("fpsUpd", 0.25f);
    }
}
