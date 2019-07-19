using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameLobbyPanel : MonoBehaviour {
    public Button pvpBtn;                                       //pvp按钮
    public Button chanllengeBtn;                                //挑战按钮
    public Button trainingBtn;                                  //训练按钮
    public Button achievementBtn;                               //成就按钮
    public Button secretBtn;                                    //秘籍按钮
    public Button roleBtn;                                      //角色按钮

    private void Awake()
    {
        addEvent();
    }

    private void addEvent()                                     //添加事件
    {
        pvpBtn.onClick.AddListener(onPVP);
        chanllengeBtn.onClick.AddListener(onChanllenge);
        trainingBtn.onClick.AddListener(onTraining);
        achievementBtn.onClick.AddListener(onAchievement);
        secretBtn.onClick.AddListener(onSecret);
        roleBtn.onClick.AddListener(onRole);
    }

    private void onPVP()                                        //点击PVP
    {
        StartManager.Instance.pvpPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    private void onChanllenge()                                 //点击挑战
    {

    }

    private void onTraining()                                   //点击训练
    {

    }

    private void onAchievement()                                //点击成就
    {

    }

    private void onSecret()                                     //点击秘籍
    {
        StartManager.Instance.secretPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    private void onRole()                                       //点击角色
    {

    }
}
