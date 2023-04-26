using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMgr : MonoBehaviour
{
    [HideInInspector]
    public ToolType curTool;

    public void Init()
    {
        EventCenter.Instance.AddEventListener("ChangeTool", ChangeTool);
    }

    public void OnDestroy()
    {
        EventCenter.Instance.RemoveEventListener("ChangeTool", ChangeTool);
    }

    public void ChangeTool(object info)
    {
        curTool = ((ToolModel)info).toolType;
    }
}
