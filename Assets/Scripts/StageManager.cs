using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GeneratePanel(int currentStage)
    {

        switch (currentStage)
        {
            case 0:
                Stage0();
                break;
            case 1:
                Stage1();
                break;
            case 2:
                Stage2();
                break;
            case 3:
                Stage3();
                break;
            case 4:
                Stage4();
                break;
            case 5:
                Stage5();
                break;
            case 6:
                Stage6();
                break;
            case 7:
                Stage7();
                break;
            case 8:
                Stage8();
                break;
            case 9:
                Stage9();
                break;
            case 10:
                Stage10();
                break;
            case 11:
                Stage11();
                break;
            case 12:
                Stage12();
                break;
        }
    }

    /*
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0}
    */

    void BlockInstance(int[][] blockImage )
    {
        for (int i = 0; i < blockImage.Length; i++)
        {
            for (int j = 0; j < blockImage[i].Length; j++)
            {

                if (blockImage[i][j] == 0)
                {
                    // 壁ブロックの生成

                }
                else if (blockImage[i][j] == 5)
                {
                    // 何もブロックを生成しない

                }
                else
                {
                    GameObject numObj = Instantiate(GameManager.instance.numPanelPrefab, new Vector3(((j + 1) * 160) - 10, ((-i - 3) * 160) + 2000, 0), Quaternion.identity) as GameObject;
                    numObj.GetComponent<NumberPanel>().Num = blockImage[i][j];
                    numObj.transform.parent = GameManager.instance.numPanel.transform;
                }

            }
        }
    }

    void Stage0()
    {

        // ブロックの配置
        int[][] blockImage =
        {
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 6, 6, 0, 0},
            new int [] { 0, 6, 6, 6, 6, 0},
            new int [] { 0, 0, 6, 6, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0}
        };

        BlockInstance(blockImage);
    }

    void Stage1() 
    {
        
        // ブロックの配置
        int[][] blockImage =
        {
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 6, 2, 0, 0},
            new int [] { 0, 0, 2, 8, 0, 0},
            new int [] { 0, 0, 8, 2, 0, 0},
            new int [] { 0, 0, 2, 6, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0}
        };

        BlockInstance(blockImage);
    }

    void Stage2()
    {
        // ブロックの配置
        int[][] blockImage =
        {
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 6, 0, 2, 0},
            new int [] { 0, 6, 6, 6, 8, 2},
            new int [] { 0, 0, 8, 0, 2, 0},
            new int [] { 0, 0, 2, 0, 8, 0},
            new int [] { 0, 2, 8, 6, 6, 6},
            new int [] { 0, 0, 2, 0, 6, 0},
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0}
        };

        BlockInstance(blockImage);
    }


    void Stage3()
    {
        // ブロックの配置
        int[][] blockImage =
        {
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 3, 0, 0, 0, 0, 0},
            new int [] { 2, 8, 2, 0, 0, 0},
            new int [] { 4, 0, 6, 1, 0, 0},
            new int [] { 2, 0, 0, 8, 1, 0},
            new int [] { 3, 0, 2, 4, 0, 0},
            new int [] { 2, 6, 8, 0, 0, 0},
            new int [] { 6, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0}
        };

        BlockInstance(blockImage);

    }

    void Stage4()
    {
        // ブロックの配置
        int[][] blockImage =
        {
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 0, 0, 0, 0, 0, 0},
            new int [] { 2, 8, 0, 0, 2, 6},
            new int [] { 4, 2, 0, 0, 6, 2},
            new int [] { 2, 4, 6, 8, 4, 6},
            new int [] { 8, 2, 4, 6, 2, 2},
            new int [] { 8, 6, 0, 0, 2, 8},
            new int [] { 2, 8, 0, 0, 8, 2},
            new int [] { 0, 0, 0, 0, 0, 0}
        };

        BlockInstance(blockImage);
    }

    void Stage5()
    {
        // ブロックの配置
        int[][] blockImage =
        {
            new int [] { 0, 0, 0, 0, 0, 0 },
            new int [] { 0, 6, 0, 2, 0, 0 },
            new int [] { 8, 8, 4, 2, 2, 0 },
            new int [] { 8, 2, 8, 8, 4, 0 },
            new int [] { 8, 8, 4, 8, 2, 0 },
            new int [] { 6, 0, 8, 0, 6, 0 },
            new int [] { 6, 8, 8, 8, 6, 0 },
            new int [] { 0, 0, 0, 0, 0, 0 },
            new int [] { 0, 0, 0, 0, 0, 0 }
        };

        BlockInstance(blockImage);
    }

    void Stage6()
    {
        // ブロックの配置
        int[][] blockImage =
        {
            new int [] { 0, 2, 6, 2, 3, 0 },
            new int [] { 0, 2, 8, 4, 2, 0 },
            new int [] { 0, 0, 8, 3, 0, 0 },
            new int [] { 0, 6, 4, 6, 2, 0 },
            new int [] { 2, 0, 8, 6, 0, 2 },
            new int [] { 0, 0, 8, 4, 0, 0 },
            new int [] { 0, 8, 4, 3, 8, 0 },
            new int [] { 0, 8, 0, 0, 2, 0 },
            new int [] { 0, 6, 0, 0, 2, 0 }
        };

        BlockInstance(blockImage);
    }

    void Stage7()
    {
        // ブロックの配置
        int[][] blockImage =
        {
            new int [] { 0, 6, 6, 8, 4, 0 },
            new int [] { 0, 2, 4, 4, 8, 0 },
            new int [] { 0, 8, 6, 8, 2, 0 },
            new int [] { 0, 6, 0, 0, 2, 0 },
            new int [] { 0, 8, 0, 0, 6, 0 },
            new int [] { 0, 2, 0, 0, 2, 0 },
            new int [] { 2, 2, 2, 6, 8, 2 },
            new int [] { 2, 2, 6, 8, 6, 8 },
            new int [] { 2, 2, 6, 4, 8, 8 }
        };

        BlockInstance(blockImage);
    }

    void Stage8()
    {
        // ブロックの配置
        int[][] blockImage =
        {
            new int [] { 0, 0, 2, 6, 0, 0 },
            new int [] { 0, 0, 4, 4, 0, 0 },
            new int [] { 8, 4, 4, 6, 6, 6 },
            new int [] { 0, 2, 4, 2, 4, 0 },
            new int [] { 0, 4, 4, 6, 8, 0 },
            new int [] { 6, 6, 6, 4, 2, 6 },
            new int [] { 0, 0, 2, 4, 0, 0 },
            new int [] { 0, 0, 8, 8, 0, 0 },
            new int [] { 0, 0, 0, 0, 0, 0 }
        };

        BlockInstance(blockImage);
    }

    void Stage9()
    {
        // ブロックの配置
        int[][] blockImage =
        {
            new int [] { 4, 2, 0, 0, 4, 8 },
            new int [] { 8, 6, 0, 0, 8, 2 },
            new int [] { 4, 8, 0, 0, 2, 6 },
            new int [] { 0, 2, 6, 6, 6, 0 },
            new int [] { 0, 6, 6, 6, 8, 0 },
            new int [] { 0, 6, 2, 2, 8, 0 },
            new int [] { 6, 6, 0, 0, 2, 2 },
            new int [] { 4, 6, 0, 0, 4, 4 },
            new int [] { 6, 8, 0, 0, 6, 6 }
        };

        BlockInstance(blockImage);
    }

    void Stage10()
    {
        // ブロックの配置
        int[][] blockImage =
        {
            new int [] { 6, 4, 6, 4, 8, 2 },
            new int [] { 0, 6, 2, 6, 8, 0 },
            new int [] { 0, 8, 2, 2, 6, 0 },
            new int [] { 4, 6, 6, 2, 2, 6 },
            new int [] { 6, 0, 2, 8, 0, 6 },
            new int [] { 0, 0, 6, 4, 0, 0 },
            new int [] { 0, 0, 4, 8, 0, 0 },
            new int [] { 0, 6, 2, 4, 8, 0 },
            new int [] { 6, 4, 6, 6, 4, 4 }
        };

        BlockInstance(blockImage);
    }

    void Stage11()
    {
        
    }

    void Stage12()
    {

    }

}
