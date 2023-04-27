using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMgr : MonoBehaviour
{
    [HideInInspector]
    public ToolType curTool;
    public CharacterMgr characterMgr;
    public Dictionary<int, PatientModel> dicPatient;

    public void Init()
    {
        EventCenter.Instance.AddEventListener("ChangeTool", ChangeTool);

        dicPatient = GameMgr.Instance.dataMgr.dicPatientModel;

        characterMgr.Init(dicPatient[1001]);
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
