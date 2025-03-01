using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class boot : MonoBehaviour
{
    void Start(){
        if(!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "/hard_drives")){
            Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "/hard_drives");
        }
    }
}