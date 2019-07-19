using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PVPPanel : MonoBehaviour {
    public Button oneVSoneBtn;                                  //1v1按钮
    public Button fiveVSfiveBtn;                                //5v5按钮

    private void Awake()
    {
        addEvent();
    }

    private void addEvent()                                     //添加事件
    {
        oneVSoneBtn.onClick.AddListener(onOneVSOne);
        fiveVSfiveBtn.onClick.AddListener(onFiveVSFive);
    }

    private void onOneVSOne()                                   //点击1v1
    {
        
    }

    private void onFiveVSFive()                                 //点击5v5
    {
        
    }
}
