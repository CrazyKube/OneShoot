using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour {
    private static StartManager _instance;                           //开始菜单单例
    public static StartManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public GameObject loginPanel;                                   //登录面板
    public GameObject registerPanel;                                //注册面板
    public GameObject gameLobbyPanel;                               //游戏大厅面板
    public GameObject pvpPanel;                                     //pvp面板
    public GameObject secretPanel;                                  //秘籍面板
    public GameObject messagePanel;                                 //消息面板
    public Text messageText;                                        //消息文本

    private void Awake()
    {
        _instance = this;
    }
    public void ShowMessage(string message,float time)              //显示提示框
    {
        StartCoroutine(Show(message,time));
    }

    IEnumerator Show(string message, float time)
    {
        messagePanel.SetActive(true);
        messageText.text = message;
        yield return new WaitForSeconds(time);
        messagePanel.SetActive(false);
    }
}
