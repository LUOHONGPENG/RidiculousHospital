using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoSingleton<GameMgr>
{
    public LevelMgr levelMgr;
    public UIMgr uiMgr;

    public override void Init()
    {
        levelMgr.Init();
        uiMgr.Init();
    }


}
