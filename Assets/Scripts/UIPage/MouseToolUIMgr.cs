using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseToolUIMgr : MonoBehaviour
{
    public Image imgMouse;

    public List<Sprite> listSpMouse = new List<Sprite>();

    public void Init()
    {
        EventCenter.Instance.AddEventListener("ChangeTool", SetToolSprite);
    }

    public void Update()
    {
        imgMouse.transform.position = PublicTool.GetMousePosition2D();
    }


    public void OnDestroy()
    {
        EventCenter.Instance.RemoveEventListener("ChangeTool", SetToolSprite);
    }

    public void SetToolSprite(object info)
    {
        ToolModel toolModel = (ToolModel)info;
        switch (toolModel.toolType)
        {
            case ToolType.None:
                imgMouse.gameObject.SetActive(false);
                break;
            default:
                imgMouse.gameObject.SetActive(true);
                imgMouse.sprite = Resources.Load<Sprite>("Tools/" + toolModel.toolUrl);
                break;
        }
    }
}
