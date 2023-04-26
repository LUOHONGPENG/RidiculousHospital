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
    }
}
