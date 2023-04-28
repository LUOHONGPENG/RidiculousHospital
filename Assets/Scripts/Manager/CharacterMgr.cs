using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMgr : MonoBehaviour
{
    public SpriteRenderer srHead;
    public SpriteRenderer srBody;
    public SpriteRenderer srSyphilis;
    public Text txBubble;

    public bool isCure = false;

    private PatientModel patientModel;
    private PolygonCollider2D colHead;
    private PolygonCollider2D colBody;


    public void Init(PatientModel patientModel)
    {
        this.patientModel = patientModel;

        isCure = false;

        srHead.sprite = Resources.Load<Sprite>("Patients/" + patientModel.headUrl);
        srBody.sprite = Resources.Load<Sprite>("Patients/" + patientModel.bodyUrl);
        srBody.transform.localPosition = patientModel.posBody;
        if(patientModel.patientType == PatientType.Syphilis)
        {
            srSyphilis.gameObject.SetActive(true);
        }
        else
        {
            srSyphilis.gameObject.SetActive(false);
        }
        colHead = srHead.gameObject.AddComponent<PolygonCollider2D>();
        colBody = srBody.gameObject.AddComponent<PolygonCollider2D>();

        InitDesc();
    }

    public void InitDesc()
    {
        string strDec = "";
        switch (patientModel.patientType)
        {
            case PatientType.MentalDisorder:
                strDec = "The earth is a cube.";
                break;
            case PatientType.Whitening:
                strDec = "I want to whiten my face!";
                break;
            case PatientType.Syphilis:
                strDec = "I want to cure my syphilis.";
                break;
            case PatientType.Crying:
                strDec = "* Crying *";
                break;
            case PatientType.Skincare:
                strDec = "Skincare, Please.";
                break;
            case PatientType.Hemostasis:
                strDec = "Help me stop the bleeding!";
                break;
            case PatientType.Devil:
                strDec = "I will destory the world.";
                break;
        }
        txBubble.text = strDec;
    }


    public void Cure()
    {
        if (!isCure)
        {
            Debug.Log("Cure");

            srHead.sprite = Resources.Load<Sprite>("Patients/" + patientModel.headUrlAfter);
            srBody.sprite = Resources.Load<Sprite>("Patients/" + patientModel.bodyUrlAfter);
            srBody.transform.localPosition = patientModel.posBodyAfter;

            Destroy(colBody);
            Destroy(colHead);
            srHead.gameObject.AddComponent<PolygonCollider2D>();
            srBody.gameObject.AddComponent<PolygonCollider2D>();
            srSyphilis.gameObject.SetActive(false);

            CureDesc();
            isCure = true;
        }
    }

    public void CureDesc()
    {
        string strDec = "";
        switch (patientModel.patientType)
        {
            case PatientType.MentalDisorder:
                strDec = "...";
                break;
            case PatientType.Whitening:
                strDec = "Thank you";
                break;
            case PatientType.Syphilis:
                strDec = "Thank you";
                break;
            case PatientType.Crying:
                strDec = "Zzzzzz";
                break;
            case PatientType.Skincare:
                strDec = "Thank you";
                break;
            case PatientType.Hemostasis:
                strDec = "Thank you";
                break;
            case PatientType.Devil:
                strDec = "What happen?.";
                break;
        }
        txBubble.text = strDec;
    }
}
