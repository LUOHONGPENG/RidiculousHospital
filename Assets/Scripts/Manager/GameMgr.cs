using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoSingleton<GameMgr>
{
    [HideInInspector]
    public DataMgr dataMgr;
    public LevelMgr levelMgr;
    public UIMgr uiMgr;
    public SoundMgr soundMgr;

    public override void Init()
    {
        base.Init();

        StartCoroutine(IE_Init());
    }

    public IEnumerator IE_Init()
    {
        dataMgr = DataMgr.Instance;
        dataMgr.Init();
        yield return new WaitForSeconds(0.1f);
        levelMgr.Init();
        yield return new WaitForSeconds(0.1f);
        uiMgr.Init();
        soundMgr.Init();
    }

}
