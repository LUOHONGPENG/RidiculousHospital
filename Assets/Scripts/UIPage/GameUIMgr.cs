using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIMgr : MonoBehaviour
{
    public MouseToolUIMgr mouseToolUIMgr;
    public InterfaceUIMgr interfaceUIMgr;
    public InfoUIMgr infoUIMgr;
    public void Init()
    {
        interfaceUIMgr.Init();
        mouseToolUIMgr.Init();
        infoUIMgr.Init();
    }

}
