using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelMgr : MonoBehaviour
{

    public Transform tfCharacter;
    public GameObject pfCharacter;

    private List<int> listCharacterID = new List<int>() {1001,1002,1004,1005,1006,1007,1003};
    private int curID = 0;
    private ToolType curTool;
    private PatientType curPatientType;
    private CharacterMgr curPatientMgr;
    private float timerCharacter;
    private bool isCreatingCharacter;
    private bool isInit = false;


    private Dictionary<int, PatientModel> dicPatient;
    private Dictionary<PatientType, ToolType> dicTreat;

    #region Basic
    public void Init()
    {
        EventCenter.Instance.AddEventListener("ChangeTool", ChangeTool);
        dicPatient = GameMgr.Instance.dataMgr.dicPatientModel;
        dicTreat = GameMgr.Instance.dataMgr.dicTreat;

        curID = 0;
        isCreatingCharacter = false;

        timerCharacter = 0f;
        isInit = true;
    }

    public void OnDestroy()
    {
        EventCenter.Instance.RemoveEventListener("ChangeTool", ChangeTool);
    }

    public void Update()
    {
        if (isInit)
        {
            CheckMouseClick();
            CheckTime();
        }
    }
    #endregion

    #region Tool Event
    public void ChangeTool(object info)
    {
        curTool = ((ToolModel)info).toolType;
    }

    public void CheckMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //CheckWhetherSlot
            Vector3 screenPos = PublicTool.GetMousePosition2D();
            RaycastHit2D[] hits = Physics2D.RaycastAll(screenPos, Vector2.zero);

            foreach (var hit in hits)
            {
                if (hit.collider != null)
                {
                    switch (hit.collider.tag)
                    {
                        case "HeadCol":
                            if(curTool == ToolType.Mercury || curTool == ToolType.Leeches || curTool == ToolType.Poppy || curTool == ToolType.ElectricShock || curTool == ToolType.Crosses)
                            {
                                Treat(curTool, curPatientType);
                            }
                            break;
                        case "BodyCol":
                            if (curTool == ToolType.Mercury || curTool == ToolType.Leeches || curTool == ToolType.ElectricShock || curTool == ToolType.Crosses)
                            {
                                Treat(curTool, curPatientType);
                            }
                            break;
                        case "LobCol":
                            if(curTool == ToolType.IcePick)
                            {
                                Treat(curTool, curPatientType);
                            }
                            break;
                    }
                }
            }
        }
    }
    
    public void Treat(ToolType toolType,PatientType patientType)
    {
        if (dicTreat.ContainsKey(patientType))
        {
            if(dicTreat[patientType] == toolType)
            {
                Debug.Log("GoodTreat");
            }
            else
            {
                Debug.Log("WrongTreat");
            }
        }
    }


    #endregion

    #region CharacterBorn

    public void CheckTime()
    {
        timerCharacter -= Time.deltaTime;

        if (timerCharacter < 0 && !isCreatingCharacter) 
        {
            isCreatingCharacter = true;
            if (curPatientMgr != null)
            {
                StartCoroutine(IE_DestoryCharacter());
            }
            CreateCharacter();
            timerCharacter = 5f;
            isCreatingCharacter = false;
        }
    }

    public IEnumerator IE_DestoryCharacter()
    {
        CharacterMgr tempCharacter = curPatientMgr;
        tempCharacter.transform.DOMoveX(-15f, 1f);
        yield return new WaitForSeconds(1f);
        Destroy(tempCharacter.gameObject);
    }

    public void CreateCharacter()
    {
        if (curID < listCharacterID.Count)
        {
            PatientModel curPatient = dicPatient[listCharacterID[curID]];
            curPatientType = curPatient.patientType;

            GameObject objCharacter = GameObject.Instantiate(pfCharacter, new Vector2(12, 0), Quaternion.Euler(Vector2.zero), tfCharacter);
            curPatientMgr = objCharacter.GetComponent<CharacterMgr>();
            curPatientMgr.Init(curPatient);

            curPatientMgr.transform.DOMoveX(0, 1f);

            curID++;
        }
        else
        {
            //End
        }
    }
    #endregion
}
