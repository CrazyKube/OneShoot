using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoginPanel : MonoBehaviour {
    public InputField input_Username;                           //帐号输入框 
    public InputField input_Password;                           //密码输入框
    public Button loginBtn;                                     //登录按钮   
    public Button toRegisterBtn;                                //转换到注册界面的按钮

    private void Awake()
    {
        loginBtn.onClick.AddListener(onLoginClick);
        toRegisterBtn.onClick.AddListener(onToRegisterClick);
    }
    
    private void onLoginClick()                                 //点击登录
    {
        if (input_Username.text=="")
        {
            StartManager.Instance.ShowMessage("帐号不能为空！", 2.0f);
            return;
        }
        if (input_Password.text == "")
        {
            StartManager.Instance.ShowMessage("密码不能为空！", 2.0f);
            return;
        }
    }
    
    private void onToRegisterClick()                            //点击转换到注册界面
    {
        StartManager.Instance.registerPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    
}
