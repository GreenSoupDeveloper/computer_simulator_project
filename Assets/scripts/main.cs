using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class main : MonoBehaviour
{
    public TextMeshProUGUI texter;
    public static TextMeshProUGUI errortxt;
        public static int fps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        errortxt = GameObject.Find("errortxt").GetComponent<TextMeshProUGUI>();
        errortxt.text = "";
        fpsUpd();
    }
    public static IEnumerator setErrorMessage(string thinger){
        main.errortxt.text = thinger;
        yield return new WaitForSeconds(2f);
        main.errortxt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void fpsUpd()
    {

        fps = (int)(1f / Time.unscaledDeltaTime);
         if (!Application.isEditor)
        {
        texter.text = "CPU: " + SystemInfo.processorType + "\nGPU: " + SystemInfo.graphicsDeviceName + "\nFPS: " + fps;
        }else{
            texter.text = "FPS: " + fps;
        }
        Invoke("fpsUpd", 0.25f);
    }
}
