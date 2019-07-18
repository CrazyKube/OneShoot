using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RegisterPanel : MonoBehaviour
{

    //帐号输入框
    public InputField input_Username;
    //密码输入框
    public InputField input_Password;
    //注册按钮
    public Button registerBtn;
    //转换到的登录界面的按钮
    public Button toLoginBtn;

    private void Awake()
    {
        registerBtn.onClick.AddListener(onRegisterClick);
        toLoginBtn.onClick.AddListener(onToLoginClick);
    }


    //点击注册
    private void onRegisterClick()
    {
        if (input_Username.text == "")
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

    //点击转换到登录界面
    private void onToLoginClick()
    {
        StartManager.Instance.loginPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
