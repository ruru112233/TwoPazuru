using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text text;

    public CanvasScaler canvas;

    // Start is called before the first frame update
    void Start()
    {

        text.text = "Screen Width : " + Screen.width + "Screen  height: " + Screen.height;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
