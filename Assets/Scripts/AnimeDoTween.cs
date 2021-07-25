using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AnimeDoTween : MonoBehaviour
{
    // チュートリアルをクリアした場合
    [SerializeField] RectTransform mt2, mu, mt3, mo, mr2, mi, ma3, ml2, mc2, ml3, me3, ma4, mr3;
    // ステージ1以上クリアした場合
    [SerializeField] RectTransform ms, mt, ma, mg, me, m1, mc, ml, me2, ma2, mr;

    [SerializeField] List<Sprite> splite = new List<Sprite>();

    float waitTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // 移動
        //ms.DOMove(Vector3.one, 1.0f);

        // スケール
        //ms.DOScale(Vector3.one, 1.0f);

        // ジャンプ
        //ms.DOLocalJump(trance, 60, 1, 1.5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RectAnime()
    {
        
        if (GameManager.currentStage == 0)
        {
            StartCoroutine(tutorialCount1());
        }
        else
        {
            m1.GetComponent<Image>().sprite = splite[GameManager.currentStage - 1];
            StartCoroutine(StageCount());
        }
    }

    // チュートリアルをクリアした場合
    IEnumerator tutorialCount1()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.2f);

            DoAnime(mt2, -390, 450);

            yield return new WaitForSeconds(waitTime);

            DoAnime(mu, -240, 450);

            yield return new WaitForSeconds(waitTime);

            DoAnime(mt3, -100, 450);

            yield return new WaitForSeconds(waitTime);

            DoAnime(mo, 30, 450);

            yield return new WaitForSeconds(waitTime);

            DoAnime(mr2, 150, 450);

            yield return new WaitForSeconds(waitTime);

            DoAnime(mi, 260, 450);

            yield return new WaitForSeconds(waitTime);

            DoAnime(ma3, 370, 450);

            yield return new WaitForSeconds(waitTime);

            DoAnime(ml2, 480, 450);

            yield return new WaitForSeconds(waitTime);

            DoAnime(mc2, -230, 160);

            yield return new WaitForSeconds(waitTime);

            DoAnime(ml3, -80, 160);

            yield return new WaitForSeconds(waitTime);

            DoAnime(me3, 60, 160);
            
            yield return new WaitForSeconds(waitTime);

            DoAnime(ma4, 210, 160);

            yield return new WaitForSeconds(waitTime);

            DoAnime(mr3, 360, 160);

        }
    }

    // ステージ1以上クリアした場合
    IEnumerator StageCount()
    {
        while (true)
        {

            yield return new WaitForSeconds(1.2f);

            DoAnime(ms, -330, 463);

            yield return new WaitForSeconds(waitTime);

            DoAnime(mt, -180, 463);

            yield return new WaitForSeconds(waitTime);

            DoAnime(ma, -30, 463);

            yield return new WaitForSeconds(waitTime);

            DoAnime(mg, 120, 463);

            yield return new WaitForSeconds(waitTime);

            DoAnime(me, 270, 463);

            yield return new WaitForSeconds(waitTime);

            DoAnime(m1, 450, 463);

            yield return new WaitForSeconds(waitTime);

            DoAnime(mc, -260, 187);

            yield return new WaitForSeconds(waitTime);

            DoAnime(ml, -110, 187);

            yield return new WaitForSeconds(waitTime);

            DoAnime(me2, 40, 187);

            yield return new WaitForSeconds(waitTime);

            DoAnime(ma2, 190, 187);

            yield return new WaitForSeconds(waitTime);

            DoAnime(mr, 340, 187);

        }
    }

    void DoAnime(RectTransform rect, float x, float y)
    {
        Vector3 trance = new Vector3(x - 50, y + 50, 0);
        rect.DOLocalJump(trance, 60, 1, 1.5f);
    }
}
