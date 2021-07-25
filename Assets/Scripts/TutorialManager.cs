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

        tutorialText.text = "�Q�[�����v���C���Ă��������A���肪�Ƃ��������܂��B";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);

        tutorialText.text = "���̃Q�[���́A�S�Ẵp�l���̐������u2�v�ɂ��邱�Ƃ��ړI�̃Q�[���ł��B";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);

        panelArrow.SetActive(true);

        tutorialText.text = "���ꂪ�p�l���ł��B\r\n\r\n�p�l�����N���b�N����ƁA�㉺�A���E�̃p�l���̐�����2�{�ɂȂ�܂��B\r\n�������A�N���b�N�����p�l���̐����͕ύX����܂���B";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);

        tutorialText.text = "�܂��A������2���ɂȂ����ꍇ�́A��1�������\������܂��B\r\n" +
            "�Ⴆ�΁A�p�l���̐�����6�̏ꍇ�A2�{�ɂ����12�ƂȂ�܂����A�\���́u2�v�ɂȂ�܂��B\r\n" +
                    "�N���A�����́A�p�l���̐������u2�v�ł��邱�ƂȂ̂ŁA���̏ꍇ�ł��N���A�ƂȂ�܂��B";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);
        panelArrow.SetActive(false);
        troubleArrow.SetActive(true);

        tutorialText.text = "�p�l�����N���b�N����ƁA������Ɏ萔���J�E���g����܂��B\r\n�萔�̍ŒZ�`�������W���y����������";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);
        troubleArrow.SetActive(false);
        resetArrow.SetActive(true);

        tutorialText.text = "���ɁA������̓��Z�b�g�{�^���ɂȂ�܂��B";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);

        tutorialText.text = "��蒼�������ꍇ�́A������̃{�^���������Ă��������B";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);
        resetArrow.SetActive(false);
        titleArrow.SetActive(true);

        tutorialText.text = "������̃{�^���́A�^�C�g���֖߂�{�^���ɂȂ�܂��B";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);

        tutorialText.text = "�ʂ̃X�e�[�W�i�N���A�ρj���v���C�������Ȃ����ꍇ���A�^�C�g����ʂɖ߂肽���ꍇ�́A�����Ă��������B";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);
        titleArrow.SetActive(false);


        tutorialText.text = "����ł́A�Q�[�������y���݂��������I";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));

        AudioManager.instance.PlaySE(2);

        yield return new WaitForSeconds(0.1f);

        tutorialPanel.SetActive(false);


    }

}
