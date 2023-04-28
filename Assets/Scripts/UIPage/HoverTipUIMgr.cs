using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverTipUIMgr : MonoBehaviour
{
    public Transform tfHoverTip;
    public Text txName;
    public Text txDesc;

    public void Init(string txName,string txDesc,Vector2 pos)
    {
        tfHoverTip.gameObject.SetActive(true);
        this.txName.text = txName;
        this.txDesc.text = txDesc;
        tfHoverTip.position = pos;
    }

    public void Hide()
    {
        tfHoverTip.gameObject.SetActive(false);
    }
}
