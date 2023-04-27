using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr : MonoSingleton<DataMgr>
{
    public Dictionary<int, PatientModel> dicPatientModel = new Dictionary<int, PatientModel>();
    public List<ToolModel> listToolModel = new List<ToolModel>();
    public Dictionary<int, ToolModel> dicToolModel = new Dictionary<int, ToolModel>();

    public override void Init()
    {
        base.Init();

        dicPatientModel.Clear();
        dicPatientModel.Add(1001, new PatientModel(1001, "imgLobeHead", "imgLobeBody", "imgLobeHead", "imgLobeBody"));
        dicPatientModel.Add(1002, new PatientModel(1002, "imgWhiteHead", "imgWhiteBody", "imgWhiteHeadAfter", "imgWhiteBody"));
        dicPatientModel.Add(1003, new PatientModel(1003, "imgSyphilisHead", "imgSyphilisBody", "imgSyphilisHead", "imgSyphilisBody"));
        dicPatientModel.Add(1004, new PatientModel(1004, "imgSleepHead", "imgSleepBody", "imgSleepHeadAfter", "imgSleepBodyAfter"));
        dicPatientModel.Add(1005, new PatientModel(1005, "imgSkincareHead", "imgSkincareBody", "imgSkincareHeadAfter", "imgSkincareBody"));
        dicPatientModel.Add(1006, new PatientModel(1006, "imgBloodHead", "imgBloodBody", "imgBloodHeadAfter", "imgBloodBodyAfter"));
        dicPatientModel.Add(1007, new PatientModel(1007, "imgDevilHead", "imgDevilBody", "imgDevilHeadAfter", "imgDevilBodyAfter"));

        listToolModel.Clear();
        listToolModel.Add(new ToolModel(1001, "imgToolIcePick", "Ice Pick", "A method to cure mental illness."));
        listToolModel.Add(new ToolModel(1002, "imgToolMercury", "Mercury", ""));
        listToolModel.Add(new ToolModel(1003, "imgToolPoppy", "Poppy", ""));
        listToolModel.Add(new ToolModel(1004, "imgToolElectric", "Electric Shock", ""));
        listToolModel.Add(new ToolModel(1005, "imgToolLeeches", "Leeches", ""));
        listToolModel.Add(new ToolModel(1006, "imgToolCrosses", "Crosses", ""));

        dicToolModel.Clear();
        for(int i = 0; i < listToolModel.Count; i++)
        {
            dicToolModel.Add(listToolModel[i].ID, listToolModel[i]);
        }
    }
}

public class PatientModel
{
    public int ID;
    public string headUrl;
    public string bodyUrl;
    public string headUrlAfter;
    public string bodyUrlAfter;
    public PatientType patientType;

    public PatientModel(int ID,string headUrl,string bodyUrl, string headUrlAfter, string bodyUrlAfter)
    {
        this.ID = ID;
        this.headUrl = headUrl;
        this.bodyUrl = bodyUrl;
        this.headUrlAfter = headUrl;
        this.bodyUrlAfter = bodyUrl;

        switch (ID)
        {
            case 1001:
                patientType = PatientType.MentalDisorder;
                break;
            case 1002:
                patientType = PatientType.Whitening;
                break;
            case 1003:
                patientType = PatientType.Syphilis;
                break;
            case 1004:
                patientType = PatientType.Crying;
                break;
            case 1005:
                patientType = PatientType.Skincare;
                break;
            case 1006:
                patientType = PatientType.Hemostasis;
                break;
            case 1007:
                patientType = PatientType.Devil;
                break;
        }
    }
}

public class ToolModel
{
    public int ID;
    public string name;
    public string desc;
    public string toolUrl;
    public ToolType toolType;

    public ToolModel(int ID, string toolUrl, string name,string desc)
    {
        this.ID = ID;
        this.toolUrl = toolUrl;
        this.name = name;
        this.desc = desc;

        switch (ID)
        {
            case 1001:
                toolType = ToolType.IcePick;
                break;
            case 1002:
                toolType = ToolType.Mercury;
                break;
            case 1003:
                toolType = ToolType.Poppy;
                break;
            case 1004:
                toolType = ToolType.ElectricShock;
                break;
            case 1005:
                toolType = ToolType.Leeches;
                break;
            case 1006:
                toolType = ToolType.Crosses;
                break;
        }
    }

}
