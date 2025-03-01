using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class webay_Category : MonoBehaviour
{
    public enum Category { CPU, GPU, Motherboard, RAM, Power_Supply, Hard_Drive, Case, CPU_Fan };


    [Header("CPU stuff")]
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;

    public ScrollRect scrollRect;


    public void Start()
    {


        filter1();
    }
    public void filter1()
    {

        obj1.SetActive(true);
        scrollRect.content = obj1.GetComponent<RectTransform>();

        obj2.SetActive(false);
    }
    public void filter2()
    {

        obj1.SetActive(false);
        scrollRect.content = obj2.GetComponent<RectTransform>();

        obj2.SetActive(true);
    }
}