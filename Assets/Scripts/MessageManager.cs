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

        await navigator.Message(new string[] { "���̓x�́A�v���C���Ă����������肪�Ƃ��������܂��B"
                                             , "���̃Q�[���̐��������܂��B" });

        await navigator.MessageObject(new string[] { "�܂��͂��߂ɁA������́A���j���[�{�^���ɂȂ�܂��B"
                                                   , "���j���[�ł́A���g���C�A���ʒ����A�^�C�g���ɖ߂邱�Ƃ��ł��܂��B"}, arrowObj.menuArrow);

        await navigator.Message(new string[] { "���ɁA���[���̐����ł��B"
                                             , "���̃Q�[���́A�S�Ẵp�l���̐������u2�v�ɂ��邱�Ƃ��ړI�̃Q�[���ł��B" });

        await PanelTapDown(4);

        await navigator.Message(new string[] { "���̃p�l�����^�b�v���Ă݂Ă��������I" });

        while (true)
        {
            await Task.Delay(1);

            if (flag1)
            {
                flag1 = false;
                layerCount = 1;
                // �p�l���̏�����
                await PanelTapDown(9);
                await navigator.Message(new string[] { "�p�l�����N���b�N����ƁA�㉺�A���E�̃p�l���̐�����2�{�ɂȂ�܂����A"
                                                     , "�p�l���̐����́A��1���̂ݕ\������܂��B"
                                                     , "����́A6�~2��12�ƂȂ�܂����A�p�l���ɂ�2�����\������܂��B"
                                                     , "�������A�N���b�N�����p�l���̐����͕ύX����܂���B" });

                await PanelTapDown(3);

                await navigator.Message(new string[] { "���ɁA���̃p�l�����^�b�v���Ă��������I" });

            }

            if (flag2)
            {
                layerCount = 2;

                // �p�l���̏�����
                await PanelTapDown(9);

                await navigator.Message(new string[] { "���߂łƂ��������܂��I�I" 
                                                     , "�S��2�ɂȂ����̂ŃN���A�ł��B"
                �@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ , "����ŁA�Q�[���̐����͏I���ł��B"
                                                     , "���������A�Q�[�������y���݂��������I"
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

        await navigator.Message(new string[] { "�����܂Ńv���C���Ă��������܂��āA���肪�Ƃ��������܂����I"
                                             , "���݂́A���̃X�e�[�W���ŏI�ƂȂ�܂��B"
                                             , "�A�b�v�f�[�g�܂ł��҂����������B"
                                             , "���肪�Ƃ��������܂����B"
                                             , ""});

        tutorialManager.textPanel.SetActive(false);
    }

    // �p�l���^�b�v�̑���
    async Task PanelTapDown(int i)
    {
        // �S�p�l�����擾
        GameObject[] panels = GameObject.FindGameObjectsWithTag("Panel");
        List<Button> panelsButton = new List<Button>();

        // �{�^�����\���ɂ���
        foreach (GameObject panel in panels)
        {
            panel.GetComponent<Button>().enabled = false;
            // �F�̏�����
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

    // �����p�l���̃^�b�v
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
