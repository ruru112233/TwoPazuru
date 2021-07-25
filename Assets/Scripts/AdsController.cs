using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsController : MonoBehaviour
{
    string adGameId = "4131015";
    string adGameIdIos = "4131014";
    bool testMode = false;

    // 広告機能のオン/オフ
    public bool adOn = false;

    int adStage = 0;

    bool adFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            // android用広告
            Advertisement.Initialize(adGameId, testMode);
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            // ios用広告
            Advertisement.Initialize(adGameIdIos, testMode);
        }
        else
        {
            // android用広告
            Advertisement.Initialize(adGameId, testMode);
        }

        adFlag = true;

        adStage = GameManager.currentStage;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Advertisement.isInitialized && 
            adFlag && adOn && adStage != 0)
        {

            if (Advertisement.IsReady())
            {
                Advertisement.Show();
                adFlag = false;
            }
        }
    }

    public void ShowAd()
    {
        
    }
}
