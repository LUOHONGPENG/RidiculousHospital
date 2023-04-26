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
        dicPatientModel.Add(1001, new PatientModel(1001, "", ""));
        dicPatientModel.Add(1002, new PatientModel(1002, "", ""));
        dicPatientModel.Add(1003, new PatientModel(1003, "", ""));
        dicPatientModel.Add(1004, new PatientModel(1004, "", ""));
        dicPatientModel.Add(1005, new PatientModel(1005, "", ""));
        dicPatientModel.Add(1006, new PatientModel(1006, "", ""));

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

    public PatientModel(int ID,string headUrl,string bodyUrl)
    {
        this.ID = ID;
        this.headUrl = headUrl;
        this.bodyUrl = bodyUrl;
    }
}

public class ToolModel
{
    public int ID;
    public string name;
    public string desc;
    public string toolUrl;

    public ToolModel(int ID, string toolUrl, string name,string desc)
    {
        this.ID = ID;
        this.toolUrl = toolUrl;
        this.name = name;
        this.desc = desc;
    }
}
