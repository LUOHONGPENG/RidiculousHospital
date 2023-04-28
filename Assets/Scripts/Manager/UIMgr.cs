using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public GameUIMgr gameUIMgr;
    public EndPageUIMgr endUIMgr;
    public void Init()
    {
        gameUIMgr.Init();
        endUIMgr.Init();
    }
}
