using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseToolUIMgr : MonoBehaviour
{
    public Image imgMouse;

    public List<Sprite> listSpMouse = new List<Sprite>();

    public void Update()
    {
        imgMouse.transform.position = PublicTool.GetMousePosition2D();
    }

    public void SetSprite()
    {

    }
}
