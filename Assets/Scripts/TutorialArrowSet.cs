using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TutorialArrowSet : MonoBehaviour
{
    public GameObject panelArrow = null
                    , panelArrow2 = null
                    , menuArrow = null;

    // Start is called before the first frame update
    void Start()
    {
        panelArrow.SetActive(false);
        panelArrow2.SetActive(false);
        menuArrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
