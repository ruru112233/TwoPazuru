using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class Navigator : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message_str">表示するメッセージテキスト</param>
    /// <returns></returns>
    public async Task Message(string[] messages_str)
    {
        // テキストCompnentを取得する
        Text messageText = GameObject.FindWithTag("MessageText").GetComponent<Text>();
        foreach (string message_str in messages_str)
        {
            // メッセージテキストをセット
            messageText.text = message_str;

            // 画面がタップされるのを待つ
            // 1ms毎にチェックする
            while (true)
            {
                await Task.Delay(1);
                if (Application.isEditor)
                {
                    if (Input.GetMouseButtonUp(0)) break;
                }
                else
                {
                    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) break;
                }

            }
        }
    }

    // メッセージとスプライトオブジェクトが同時に表示する場合
    public async Task MessageObject(string[] messages_str, GameObject obj)
    {
        // テキストCompnentを取得する
        Text messageText = GameObject.FindWithTag("MessageText").GetComponent<Text>();

        obj.SetActive(true);

        foreach (string message_str in messages_str)
        {
            // メッセージテキストをセット
            messageText.text = message_str;

            // 画面がタップされるのを待つ
            // 1ms毎にチェックする
            while (true)
            {
                await Task.Delay(1);
                if (Application.isEditor)
                {
                    if (Input.GetMouseButtonUp(0)) break;
                }
                else
                {
                    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) break;
                }

            }
        }

        obj.SetActive(false);
    }

}
