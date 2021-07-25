using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public GameObject canvas;
    public Button stageButton;

    [SerializeField]
    private Button startButton = null
                 , selectButton = null
                 , volumeButton = null
                 , gameCloseButton = null
                 , delYesButton = null
                 , delNoButton = null;

    [SerializeField]
    private OnClick onClick = null;

    public Text screenText;
    public GameObject screenPanel;

    public Slider seSlider, bgmSlider;

    public GameObject stagePanel
                    , selectPanel
                    , delPanel
                    , yesButton
                    , noButton
                    , closeButton
                    , optionPanel;

    public static TitleManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        // スタートボタンをセット
        startButton.onClick.SetListener(onClick.NewGameButton);

        // セレクトボタンをセット
        selectButton.onClick.SetListener(onClick.SelectButton);

        // 音量調整ボタンをセット
        volumeButton.onClick.SetListener(onClick.OptionButton);

        // ゲーム終了ボタンをセット
        gameCloseButton.onClick.SetListener(onClick.Quit);

    }

    // Start is called before the first frame update
    void Start()
    {
        //GameManager.maxStage = PlayerPrefs.GetInt("Stage", 1);
        //GameManager.maxStage = PlayerPrefs.GetInt("Stage", 10);

        AudioManager.instance.PlayBGM(0);

        //yesButton.SetActive(true);
        //noButton.SetActive(true);
        closeButton.SetActive(false);
        stagePanel.SetActive(false);
        delPanel.SetActive(false);

        screenPanel.SetActive(false);
        optionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AudioManager.instance.SeSliderVolume(seSlider.normalizedValue);
        AudioManager.instance.BgmSliderVolume(bgmSlider.normalizedValue);
    }

    public void ScreenPanelButton()
    {
        AudioManager.instance.PlaySE(1);

        screenPanel.SetActive(true);

        int width = Screen.width;
        int height = Screen.height;

        screenText.text = "画面サイズ：" + width + " × " + height;
    }

    public void ScreenPanelNotButton()
    {
        AudioManager.instance.PlaySE(1);

        screenPanel.SetActive(false);
    }
}
