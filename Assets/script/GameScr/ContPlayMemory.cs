using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ContPlayMemory : MonoBehaviour
{
    [SerializeField] GameObject ContTimeObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveToMemory(int i)
    {
        if (ContTimeObj.GetComponent<ContPlayTimeTurn>().gt == 9) 
        { 
        BoardOnJsonRecord temp;
        temp = GameObject.Find("LongGameContObj").GetComponent<LongGameCont>().recordplaying; 
        GameObject ContPlayCanvasObj = GameObject.Find("ContCanvasObj");
        ContPlayCanvasObj.GetComponent<ContPlayCanvas>().saveModalClicked();
        string jsonstr = LitJson.JsonMapper.ToJson(temp);
        StreamWriter writer = new StreamWriter(Application.dataPath + "/jsonfiles/record" + i.ToString() + ".json", false);
        writer.WriteLine(jsonstr);
        writer.Flush(); writer.Close();
        }
        else if (ContTimeObj.GetComponent<ContPlayTimeTurn>().gt == 6)
        {
            BoardOnJsonRecord temp;
            temp = GameObject.Find("ShortGameContObj").GetComponent<ShortGameCont>().recordplaying;
            GameObject ContPlayCanvasObj = GameObject.Find("ContCanvasObj");
            ContPlayCanvasObj.GetComponent<ContPlayCanvas>().saveModalClicked();
            string jsonstr = LitJson.JsonMapper.ToJson(temp);
            StreamWriter writer = new StreamWriter(Application.dataPath + "/jsonfiles/record" + i.ToString() + ".json", false);
            writer.WriteLine(jsonstr);
            writer.Flush(); writer.Close();
        }
    }

}
