using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotUIBasic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button btnSlot;
    public Image imgSlot;
    private ToolModel toolModel;
    public HoverTipUIMgr hover;

    public void Init(ToolModel toolModel)
    {
        this.toolModel = toolModel;

        imgSlot.sprite = Resources.Load<Sprite>("Tools/" + toolModel.toolUrl);

        btnSlot.onClick.RemoveAllListeners();
        btnSlot.onClick.AddListener(delegate ()
        {
            EventCenter.Instance.EventTrigger("ChangeTool", toolModel);
            //GameMgr.Instance.levelMgr.curTool = toolType;
            //GameMgr.Instance.uiMgr.gameUIMgr.mouseToolUIMgr
        });
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hover.Init(toolModel.name, toolModel.desc, this.transform.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hover.Hide();
    }
}
