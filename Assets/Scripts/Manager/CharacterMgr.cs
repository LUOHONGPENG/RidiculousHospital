using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMgr : MonoBehaviour
{
    public SpriteRenderer srHead;
    public SpriteRenderer srBody;

    private PatientModel patientModel;

    public void Init(PatientModel patientModel)
    {
        this.patientModel = patientModel;

        srHead.sprite = Resources.Load<Sprite>("Patients/" + patientModel.headUrl);
        srBody.sprite = Resources.Load<Sprite>("Patients/" + patientModel.bodyUrl);
        srBody.transform.localPosition = patientModel.posBody;
        srHead.gameObject.AddComponent<PolygonCollider2D>();
        srBody.gameObject.AddComponent<PolygonCollider2D>();

    }
}
