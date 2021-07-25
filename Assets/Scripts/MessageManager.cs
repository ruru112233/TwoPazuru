using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    [SerializeField]
    private Navigator navigator = null;

    [SerializeField]
    private TutorialManager tutorialManager = null;

    [SerializeField]
    private TutorialArrowSet arrowObj = null;

    [SerializeField]
    private GameObject nextButton = null
                     , titleButton = null
                     , panelText = null;

    int layerCount = 0;

    bool flag1 = false;
    bool flag2 = false;


    private async void Start()
    {
        if (GameManager.currentStage == 0)
        {
            nextButton.SetActive(false);
            titleButton.SetActive(false);
            await TutorialMassege();
        }
        else
        {
            panelText.SetActive(false);
        }
        
    }

    async Task TutorialMassege()
    {
        tutorialManager.textPanel.SetActive(true);
        await PanelTapDown(9);

        await Task.Delay(1000);

        await navigator.Message(new string[] { "この度は、プレイしていただきありがとうございます。"
                                             , "このゲームの説明をします。" });

        await navigator.MessageObject(new string[] { "まずはじめに、こちらは、メニューボタンになります。"
                                                   , "メニューでは、リトライ、音量調整、タイトルに戻ることができます。"}, arrowObj.menuArrow);

        await navigator.Message(new string[] { "次に、ルールの説明です。"
                                             , "このゲームは、全てのパネルの数字を「2」にすることが目的のゲームです。" });

        await PanelTapDown(4);

        await navigator.Message(new string[] { "このパネルをタップしてみてください！" });

        while (true)
        {
            await Task.Delay(1);

            if (flag1)
            {
                flag1 = false;
                layerCount = 1;
                // パネルの初期化
                await PanelTapDown(9);
                await navigator.Message(new string[] { "パネルをクリックすると、上下、左右のパネルの数字が2倍になりますが、"
                                                     , "パネルの数字は、下1桁のみ表示されます。"
                                                     , "今回は、6×2で12となりますが、パネルには2だけ表示されます。"
                                                     , "ただし、クリックしたパネルの数字は変更されません。" });

                await PanelTapDown(3);

                await navigator.Message(new string[] { "次に、このパネルをタップしてください！" });

            }

            if (flag2)
            {
                layerCount = 2;

                // パネルの初期化
                await PanelTapDown(9);

                await navigator.Message(new string[] { "おめでとうございます！！" 
                                                     , "全て2になったのでクリアです。"
                　　　　　　　　　　　　　　　　　　 , "これで、ゲームの説明は終了です。"
                                                     , "引き続き、ゲームをお楽しみください！"
                                                     , ""});

                tutorialManager.tutorialPanel.SetActive(false);
                tutorialManager.textPanel.SetActive(false);

                nextButton.SetActive(true);
                titleButton.SetActive(true);
                break;
            }
        }

    }

    public async Task GameClearMessage()
    {
        await Task.Delay(1000);

        tutorialManager.textPanel.SetActive(true);

        await Task.Delay(100);

        await navigator.Message(new string[] { "ここまでプレイしていただきまして、ありがとうございました！"
                                             , "現在は、このステージが最終となります。"
                                             , "アップデートまでお待ちください。"
                                             , "ありがとうございました。"
                                             , ""});

        tutorialManager.textPanel.SetActive(false);
    }

    // パネルタップの操作
    async Task PanelTapDown(int i)
    {
        // 全パネルを取得
        GameObject[] panels = GameObject.FindGameObjectsWithTag("Panel");
        List<Button> panelsButton = new List<Button>();

        // ボタンを非表示にする
        foreach (GameObject panel in panels)
        {
            panel.GetComponent<Button>().enabled = false;
            // 色の初期化
            panel.GetComponent<Image>().color = Color.white;
            panelsButton.Add(panel.GetComponent<Button>());
        }

        await Task.Delay(1);

        if (i <= 8)
        {
            panelsButton[i].enabled = true;
            panels[i].GetComponent<Image>().color = Color.yellow;
            panelsButton[i].onClick.SetListener(PanelTap);
        }
    }

    // 数字パネルのタップ
    void PanelTap()
    {
        if (layerCount == 0)
        {
            flag1 = true;
        }
        else if(layerCount == 1)
        {
            flag2 = true;
        }
        
    }

}
