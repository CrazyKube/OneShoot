using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;

public class SecretPanel : MonoBehaviour {
    public GameObject btnPanel;                                     //按钮面板
    public GameObject secretInfoPanel;                              //秘籍页面板
    public Button warriorBtn;                                       //战士按钮
    public Button archerBtn;                                        //射手按钮
    public Button magicianBtn;                                      //法师按钮
    private string currType;
    private void Awake()
    {
        addEvent();
    }

    private void addEvent()                                         //添加事件
    {
        warriorBtn.onClick.AddListener(onWarrior);
        archerBtn.onClick.AddListener(onArcher);
        magicianBtn.onClick.AddListener(onMagician);
    }

    private void onWarrior()                                        //点击战士
    {
        currType = "warrior";
        change();
    }

    private void onArcher()                                         //点击射手
    {
        currType = "archer";
        change();
    }

    private void onMagician()                                       //点击法师
    {
        currType = "magician";
        change();
    }

    private void change()                                           //切换状态
    {
        GetJsonInfo();
        btnPanel.SetActive(false);
        secretInfoPanel.SetActive(true);
    }

    public void GetJsonInfo()                                      //读取json信息
    {
        //读取数据，转换成数据流
        StreamReader streamreader = new StreamReader(Application.dataPath + "/01_Scripts/Jsons/Secret.json");
        //再转换成json数据
        JsonReader js = new JsonReader(streamreader);
        //读取
        Root r = JsonMapper.ToObject<Root>(js);

        //遍历获取数据
        for (int i = 0; i < r.secretData.Count; i++)
        {
            if (r.secretData[i].type==currType)
            {
                //var obj = r.secretData[i].skill;
                Debug.Log(r.secretData[i].skill[0].name);
            }
        }
    }
}
