using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject tutorialPlayPanel;

    public GameObject tutorialPanel, textPanel;

    [SerializeField] Text tutorialText;

    [SerializeField] GameObject panelArrow, resetArrow, titleArrow, troubleArrow;


    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.currentStage == 0)
        {
            //tutorialPlayPanel.SetActive(true);
            tutorialPanel.SetActive(true);
            TutorialStart();
        }
        else
        {
            tutorialPlayPanel.SetActive(false);
            tutorialPanel.SetActive(false);

            textPanel.SetActive(false);

        }

        panelArrow.SetActive(false);
        resetArrow.SetActive(false);
        titleArrow.SetActive(false);
        troubleArrow.SetActive(false);


    }

    public void TutorialStart()
    {
        //tutorialPlayPanel.SetActive(false);

        //AudioManager.instance.PlaySE(1);

        StartCoroutine(Tutorial());
    }

    public void TutorialNotButton()
    {
        tutorialPanel.SetActive(false);
        AudioManager.instance.PlaySE(1);
    }

    IEnumerator Tutorial()
    {
        textPanel.SetActive(true);

        tutorialText.text = "ゲームをプレイしていただき、ありがとうございます。";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);

        tutorialText.text = "このゲームは、全てのパネルの数字を「2」にすることが目的のゲームです。";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);

        panelArrow.SetActive(true);

        tutorialText.text = "これがパネルです。\r\n\r\nパネルをクリックすると、上下、左右のパネルの数字が2倍になります。\r\nただし、クリックしたパネルの数字は変更されません。";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);

        tutorialText.text = "また、数字が2桁になった場合は、下1桁だけ表示されます。\r\n" +
            "例えば、パネルの数字が6の場合、2倍にすると12となりますが、表示は「2」になります。\r\n" +
                    "クリア条件は、パネルの数字が「2」であることなので、この場合でもクリアとなります。";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);
        panelArrow.SetActive(false);
        troubleArrow.SetActive(true);

        tutorialText.text = "パネルをクリックすると、こちらに手数がカウントされます。\r\n手数の最短チャレンジも楽しいかもｗ";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);
        troubleArrow.SetActive(false);
        resetArrow.SetActive(true);

        tutorialText.text = "次に、こちらはリセットボタンになります。";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);

        tutorialText.text = "やり直したい場合は、こちらのボタンを押してください。";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);
        resetArrow.SetActive(false);
        titleArrow.SetActive(true);

        tutorialText.text = "こちらのボタンは、タイトルへ戻るボタンになります。";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);

        tutorialText.text = "別のステージ（クリア済）をプレイしたくなった場合等、タイトル画面に戻りたい場合は、押してください。";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);
        titleArrow.SetActive(false);


        tutorialText.text = "それでは、ゲームをお楽しみください！";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);

        tutorialPanel.SetActive(false);


    }

}
