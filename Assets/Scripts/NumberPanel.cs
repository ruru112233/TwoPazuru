using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UI;

public class NumberPanel : MonoBehaviour
{

    [SerializeField] Text numText;

    [SerializeField] GameObject up, right, down, left;

    [SerializeField] int InitializeNum = 0;

    Vector3 startUpPos;
    Vector3 startRightPos;
    Vector3 startDownPos;
    Vector3 startLeftPos;

    Color defoColor = new Color(0, 0, 0, 255);
    Color twoColor = new Color(255, 0, 0);

    private int num = 0;

    public int Num
    {
        get { return num; }
        set { num = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Num = InitializeNum;
        //numText.text = Num.ToString();

        startUpPos = up.transform.position;
        startRightPos = right.transform.position;
        startDownPos = down.transform.position;
        startLeftPos = left.transform.position;

        ColOff();
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.troubleCount.text = GameManager.instance.trouble.ToString();
        numText.text = Num.ToString();

        if (Num == 2)
        {
            numText.color = twoColor;
            numText.fontSize = 50;
        }
        else
        {
            numText.color = defoColor;
            numText.fontSize = 40;
        }

    }

    public void PanelClick()
    {
        GameManager.instance.trouble++;

        AudioManager.instance.PlaySE(0);

        StartCoroutine(ColOn());
    }

    /*
    IEnumerator ButtonClick()
    {
        ColOn();

        yield return new WaitForSeconds(30.1f);

        ColOff();
    }
    */

    public void ColOff()
    {
        up.SetActive(false);
        right.SetActive(false);
        down.SetActive(false);
        left.SetActive(false);
    }

    IEnumerator ColOn()
    {

        up.SetActive(true);
        right.SetActive(true);
        down.SetActive(true);
        left.SetActive(true);

        up.transform.position += new Vector3(0, 12.0f, 0);
        right.transform.position += new Vector3(12.0f, 0, 0);
        down.transform.position += new Vector3(0, -12.0f, 0);
        left.transform.position += new Vector3(-12.0f, 0, 0);

        yield return new WaitForSeconds(0.1f);

        GameManager.instance.clearFlag = GameManager.instance.NumCheck();

        up.transform.position = startUpPos;
        right.transform.position = startRightPos;
        down.transform.position = startDownPos;
        left.transform.position = startLeftPos;

        ColOff();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Col")
        {
            Num = Num * 2;

            if (Num > 10)
            {
                Num = Num - 10;
            }
        }
    }
}
