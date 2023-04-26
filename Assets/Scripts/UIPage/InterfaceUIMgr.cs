using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceUIMgr : MonoBehaviour
{
    public Transform tfSlotLeft;
    public Transform tfSlotRight;
    public GameObject pfSlot;

    public void Init()
    {
        InitSlot();
    }

    public void InitSlot()
    {
        PublicTool.ClearChildItem(tfSlotLeft);
        PublicTool.ClearChildItem(tfSlotRight);


        List<ToolModel> listTool = GameMgr.Instance.dataMgr.listToolModel;
        for(int i = 0;i < listTool.Count; i++)
        {
            GameObject objToolUI = GameObject.Instantiate(pfSlot, tfSlotLeft);
            SlotUIBasic itemToolUI = objToolUI.GetComponent<SlotUIBasic>();

            ToolModel toolModel = listTool[i];
            itemToolUI.Init(toolModel);
        }
    }
}
