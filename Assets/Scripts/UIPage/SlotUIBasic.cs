using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUIBasic : MonoBehaviour
{
    public Button btnSlot;
    public Image imgSlot;
    private ToolModel toolModel;

    public void Init(ToolModel toolModel)
    {
        this.toolModel = toolModel;

        imgSlot.sprite = Resources.Load<Sprite>("Tools/" + toolModel.toolUrl);



        EventCenter.Instance.AddEventListener("ChangeTool", ChangeToolType);

        btnSlot.onClick.RemoveAllListeners();
        btnSlot.onClick.AddListener(delegate ()
        {
            EventCenter.Instance.EventTrigger("ChangeTool", toolModel);
            //GameMgr.Instance.levelMgr.curTool = toolType;
            //GameMgr.Instance.uiMgr.gameUIMgr.mouseToolUIMgr
        });
        
    }
    
    public void OnDestroy()
    {
        EventCenter.Instance.RemoveEventListener("ChangeTool",ChangeToolType);
    }


    private void ChangeToolType(object info)
    {

    }

}
