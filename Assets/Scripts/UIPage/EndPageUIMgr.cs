using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPageUIMgr : MonoBehaviour
{
    public GameObject objPopup;

    public Text txCured;
    public Text txDead;
    public Button btnRestart;

    public void Init()
    {
        btnRestart.onClick.RemoveAllListeners();
        btnRestart.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("Main");
        });

        EventCenter.Instance.AddEventListener("End", ShowPage);
    }

    public void OnDestroy()
    {
        EventCenter.Instance.RemoveEventListener("End", ShowPage);
    }

    public void ShowPage(object info)
    {
        txCured.text = GameMgr.Instance.levelMgr.NumCured.ToString();
        txDead.text = GameMgr.Instance.levelMgr.NumDead.ToString();
        objPopup.SetActive(true);
        Time.timeScale = 0;
    }
}
