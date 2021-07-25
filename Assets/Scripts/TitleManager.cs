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

        // �X�^�[�g�{�^�����Z�b�g
        startButton.onClick.SetListener(onClick.NewGameButton);

        // �Z���N�g�{�^�����Z�b�g
        selectButton.onClick.SetListener(onClick.SelectButton);

        // ���ʒ����{�^�����Z�b�g
        volumeButton.onClick.SetListener(onClick.OptionButton);

        // �Q�[���I���{�^�����Z�b�g
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

        screenText.text = "��ʃT�C�Y�F" + width + " �~ " + height;
    }

    public void ScreenPanelNotButton()
    {
        AudioManager.instance.PlaySE(1);

        screenPanel.SetActive(false);
    }
}
