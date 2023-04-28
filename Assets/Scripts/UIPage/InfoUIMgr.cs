using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoUIMgr : MonoBehaviour
{
    public Text txTimer;
    public Image imgHPFill;
    public Image imgHPMark;

    private LevelMgr levelMgr;

    private bool isInit;


    public void Init()
    {
        EventCenter.Instance.AddEventListener("HealthBar", RefreshHPBar);
        levelMgr = GameMgr.Instance.levelMgr;
        RefreshHPBar(100f);
        isInit = true;
    }

    public void Update()
    {
        if (isInit)
        {
            RefreshTimer();
        }   
    }

    public void OnDestroy()
    {
        EventCenter.Instance.RemoveEventListener("HealthBar", RefreshHPBar);
    }


    public void RefreshTimer()
    {
        txTimer.text = Mathf.FloorToInt(levelMgr.timerCharacter).ToString();
    }

    public void RefreshHPBar(object info)
    {
        imgHPFill.fillAmount = levelMgr.dataCharacterHP / 100f;
        if (levelMgr.dataCharacterHP < 0)
        {
            imgHPFill.fillAmount = 0;
        }
    }
}
