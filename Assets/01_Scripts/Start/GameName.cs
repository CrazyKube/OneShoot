using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameName : MonoBehaviour {
    public Image img;
	// Use this for initialization
	void Start () {
        img.DOFade(1, 2);
        Invoke("Close", 2.0f);
    }
	
	void Close()
    {
        img.DOFade(0, 2);
        Invoke("Load", 2.0f);
    }

    void Load()
    {
        //保存需要加载的目标场景
        Globe.nextSceneName = "StartScene";
        SceneManager.LoadScene("LoadingScene");
    }
}
