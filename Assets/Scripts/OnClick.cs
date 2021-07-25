using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using DG.Tweening;
using UnityEditor;

public class OnClick : MonoBehaviour
{
    TitleManager titleManager;

    [SerializeField] RectTransform rectTransform;

    [SerializeField] GameObject menuBackPanel, volumePanel;

    [SerializeField]
    Animator anime = null;

    public SaveData saveData = null;

    bool slideOnFlag = false;

    private void Start()
    {
        
        titleManager = TitleManager.instance;
        if (menuBackPanel != null)
        {
            menuBackPanel.SetActive(false);
        }

        if (volumePanel != null)
        {
            volumePanel.SetActive(false);
        }
    }

    public void TitleButton()
    {
        AudioManager.instance.PlaySE(1);
        saveData.DataSave(GameManager.maxStage);

        SceneManager.LoadScene("TitleScene");
    }

    public void NewGameButton()
    {
        
        AudioManager.instance.PlaySE(1);

        if (GameManager.maxStage != 0)
        {
            titleManager.delPanel.SetActive(true);
            titleManager.delPanel.GetComponentInChildren<Text>().text = "本当にデータを削除していいですか？";
            titleManager.yesButton.SetActive(true);
            titleManager.noButton.SetActive(true);
        }
        else
        {
            GameManager.currentStage = 0;
            NextStage();
        }
    }

    public void SelectButton()
    {

        if (GameManager.maxStage == 0)
        {
            Debug.Log("データがありません");
        }
        else
        {
            titleManager.stagePanel.SetActive(true);
            titleManager.closeButton.SetActive(true);

            AudioManager.instance.PlaySE(1);

            // ボタンを全て削除
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Stage");
            foreach (GameObject obj in objs)
            {
                Destroy(obj);
            }

            // ボタンの追加
            void AddStageButton(int idx)
            {
                Button button = Instantiate(titleManager.stageButton);
                button.transform.GetChild(0).GetComponent<Text>().text = idx.ToString();
                button.GetComponent<Button>().onClick.AddListener(() => GameButton(idx));
                button.transform.parent = titleManager.selectPanel.transform;
            }

            // ステージボタンの生成
            for (int i = 1; i <= GameManager.maxStage; i++)
            {
                AddStageButton(i);
            }
        }
        
    }

    public void GameButton(int currentStage)
    {
        AudioManager.instance.PlaySE(1);

        GameManager.currentStage = currentStage;
        SceneManager.LoadScene("GameScene");
    }

    public void DelButton()
    {
        titleManager.delPanel.SetActive(true);

        AudioManager.instance.PlaySE(1);

        if (PlayerPrefs.HasKey("Stage"))
        {
            titleManager.delPanel.GetComponentInChildren<Text>().text = "本当にデータを削除していいですか？";
            titleManager.yesButton.SetActive(true);
            titleManager.noButton.SetActive(true);
        }
        else
        {
            titleManager.delPanel.GetComponentInChildren<Text>().text = "データが存在しません";
            titleManager.closeButton.SetActive(true);
        }
    }

    public void DataDel()
    {
        GameManager.maxStage = 0;
        saveData.DataSave(GameManager.maxStage);
        GameManager.currentStage = 0;
        NextStage();
    }

    public void NoButton()
    {
        AudioManager.instance.PlaySE(1);

        titleManager.stagePanel.SetActive(false);
        titleManager.delPanel.SetActive(false);
        titleManager.yesButton.SetActive(false);
        titleManager.noButton.SetActive(false);
        titleManager.closeButton.SetActive(false);
        titleManager.optionPanel.SetActive(false);

        saveData.DataSave(GameManager.maxStage);

    }

    // 次のステージへ
    public void NextStage()
    {
        AudioManager.instance.PlaySE(1);
        saveData.DataSave(GameManager.maxStage);
        SceneManager.LoadScene("GameScene");
    }

    // リセットボタン
    public void ResetButton()
    {
        AudioManager.instance.PlaySE(1);

        SceneManager.LoadScene("GameScene");
    }

    // Twitterのボタン
    public void TwitterButton()
    {
        AudioManager.instance.PlaySE(1);

        string text1 = UnityWebRequest.EscapeURL("Stage");
        string text2 = UnityWebRequest.EscapeURL("を、");
        string text3 = UnityWebRequest.EscapeURL("手でクリアしました。");

        string url = "https://twitter.com/intent/tweet?text=" + text1 + (GameManager.currentStage - 1) + 
                     text2 + GameManager.instance.trouble + text3;

        //Twitter投稿画面の起動
        naichilab.UnityRoomTweet.Tweet("baibaipanic", "Stage" + (GameManager.currentStage - 1) + "を、" + GameManager.instance.trouble + "手でクリアしました！");

    }

    // Optionボタン
    public void OptionButton()
    {
        AudioManager.instance.PlaySE(1);

        titleManager.optionPanel.SetActive(true);
    }

    // GameSceneの音量調整
    public void VolumeButton()
    {
        AudioManager.instance.PlaySE(1);

        volumePanel.SetActive(true);
    }

    // GameSceneの閉じるボタン
    public void GameCloseButton()
    {
        AudioManager.instance.PlaySE(1);
        saveData.DataSave(GameManager.maxStage);

        volumePanel.SetActive(false);

    }

    // メニューボタン
    public void MenuButton()
    {
        slideOnFlag = !slideOnFlag;

        anime.SetBool("slideOn", slideOnFlag);

        if (slideOnFlag) 
        {
            GameManager.instance.blindPanel.SetActive(true);
        }
        else
        {
            GameManager.instance.blindPanel.SetActive(false);
        }

    }

    // VolumeSAVE
    //void VolumeSave()
    //{

    //    // 音量を格納
    //    Data volumeSave = new Data();

    //    volumeSave.bgmVolume = AudioManager.instance.GetBgmVolume();
    //    volumeSave.seVolume = AudioManager.instance.GetSeVolume();

    //    JsonDataManager.Save(volumeSave);

    //    Debug.Log("aaaa:   " + volumeSave.bgmVolume);

    //}

    public void Quit()
    {
      #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
      #elif UNITY_STANDALONE
        UnityEngine.Application.Quit();
      #endif

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }


}
