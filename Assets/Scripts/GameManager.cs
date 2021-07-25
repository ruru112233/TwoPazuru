using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    // 最高ステージ
    public static int maxStage = 0;

    // 現在のステージ
    public static int currentStage = 0;

    // 最終ステージ
    public int lastStage = 10;

    // テスト用
    [SerializeField]
    private int stageNo = 0;

    public GameObject canvas;
    public GameObject numPanelPrefab;
    public GameObject numPanel;

    public Text troubleCount;
    public int trouble = 0;

    [SerializeField] GameObject clearPanel;
    [SerializeField] StageManager stageManager;
    [SerializeField] GameObject tutorialManager;
    public GameObject blindPanel;

    [SerializeField]
    private SaveData saveData = null;
    
    // チュートリアルとステージクリア字の文字
    [SerializeField] GameObject tutorialImage, stageImg;

    // メッセージマネージャー
    [SerializeField]
    private MessageManager messageManager = null;

    [SerializeField]
    private OnClick onClick = null;

    [SerializeField]
    private Button menuButton = null
   　　　　　    , resetButton = null
                 , volumeButton = null
                 , titleButton = null
                 , volumeCloseButton = null;

    [SerializeField] GameObject lastClearText,nextButton;

    public Slider seSlider, bgmSlider;

    int count = 0;

    GameObject[] panels;

    Text[] canvasText;

    [SerializeField] Text stageNumText;

    // クリアの判定
    public bool clearFlag = false;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        // メニューボタンのセット
        menuButton.onClick.SetListener(onClick.MenuButton);

        // リセットボタンのセット
        resetButton.onClick.SetListener(onClick.ResetButton);

        // 音量調節ボタンのセット
        volumeButton.onClick.SetListener(onClick.VolumeButton);

        // タイトルボタンのセット
        titleButton.onClick.SetListener(onClick.TitleButton);

        // 音量の閉じるボタン
        volumeCloseButton.onClick.SetListener(onClick.GameCloseButton);

    }

    // Start is called before the first frame update
    void Start()
    {

        clearFlag = false;
        clearPanel.SetActive(false);
        lastClearText.SetActive(false);

        // テスト用
        // currentStage = stageNo;
        
        stageManager.GeneratePanel(currentStage);
        //stageManager.GeneratePanel(0);
        //StartCoroutine(stageManager.GeneratePanel(1));

        tutorialImage.SetActive(false);
        stageImg.SetActive(false);

        blindPanel.SetActive(false);

        canvasText = numPanel.GetComponentsInChildren<Text>();

        if (currentStage == 0)
        {
            tutorialManager.SetActive(true);
        }
        else
        {
            tutorialManager.SetActive(false);
        }

        AudioManager.instance.PlayBGM(0);

    }

    // Update is called once per frame
    void Update()
    {
        // クリア時
        if (clearFlag && count == 0)
        {
            AudioManager.instance.PlaySE(4);

            // 1回だけ処理するためのカウント
            count++;

            StartCoroutine(StageClear());
            GetComponent<AnimeDoTween>().RectAnime();


        }

        AudioManager.instance.SeSliderVolume(seSlider.normalizedValue);
        AudioManager.instance.BgmSliderVolume(bgmSlider.normalizedValue);

    }

    IEnumerator StageClear()
    {
        yield return new WaitForSeconds(0.6f);

        AudioManager.instance.PlaySE(3);

        GameObject[] panelsObj = GameObject.FindGameObjectsWithTag("Panel");

        foreach (GameObject panelObj in panelsObj)
        {
            Rigidbody2D rb = panelObj.GetComponent<Rigidbody2D>();
            rb.gravityScale = 50;
            rb.AddForce(ClearForce());
        }

        yield return new WaitForSeconds(0.8f);
        
        clearPanel.SetActive(true);

        if (currentStage == 0)
        {
            tutorialImage.SetActive(true);
        }
        else
        {
            stageImg.SetActive(true);
            stageNumText.text = (currentStage).ToString();
        }

        AudioManager.instance.PlaySE(5);
        currentStage++;

        if (currentStage < lastStage)
        {
            nextButton.SetActive(true);
        }
        else if(currentStage > lastStage)
        {
            nextButton.SetActive(false);
        }

        // 最大ステージ数
        if (currentStage < lastStage)
        {
            maxStage++;

            // セーブ
            if (maxStage < lastStage)
            {
                onClick.saveData.DataSave(maxStage);
            }
        }

        yield return new WaitForSeconds(0.1f);

        LastMessage();

    }

    async void LastMessage()
    {
        if (lastStage < currentStage)
        {
           await messageManager.GameClearMessage();
        }
    }


    Vector3 ClearForce()
    {
        Vector3 force = new Vector3(0, 0, 0);

        float randForceX = Random.Range(-1500f, 1500f);
        float randForceY = Random.Range(4000f, 8000f);
        
        force = new Vector3(randForceX, randForceY, 0);

        return force;
    }

    public bool NumCheck()
    {
        bool numFlag = true;

        for (int i = 0; i < canvasText.Length; i++)
        {
            if (canvasText[i].text != "2")
            {
                numFlag = false;
            }
        }
        return numFlag;
    }

    


}
