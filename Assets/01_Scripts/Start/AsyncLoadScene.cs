using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Globe
{
    public static string nextSceneName;
}

public class AsyncLoadScene : MonoBehaviour
{
    public Slider loadingSlider;

    public Text loadingText;

    private float loadingSpeed = 1;

    private float targetValue;

    private AsyncOperation operation;

    // Use this for initialization
    void Start()
    {
        loadingSlider.value = 0.0f;

        if (SceneManager.GetActiveScene().name == "LoadingScene")
        {
            //启动协程
            StartCoroutine(AsyncLoading());
        }
    }

    IEnumerator AsyncLoading()
    {
        operation = SceneManager.LoadSceneAsync(Globe.nextSceneName);
        //阻止当加载完成自动切换
        operation.allowSceneActivation = false;

        yield return operation;
    }
    

    void Update()
    {
        targetValue = operation.progress;

        if (operation.progress >= 0.9f)
        {
            //operation.progress的值最大为0.9
            targetValue = 1.0f;
        }

        if (targetValue != loadingSlider.value)
        {
            //插值运算
            loadingSlider.value = Mathf.Lerp(loadingSlider.value, targetValue, Time.deltaTime * loadingSpeed);
            if (Mathf.Abs(loadingSlider.value - targetValue) < 0.01f)
            {
                loadingSlider.value = targetValue;
            }
        }

        loadingText.text = ((int)(loadingSlider.value * 100)).ToString() + "%";

        //当达到100%
        if ((int)(loadingSlider.value * 100) == 100)
        {
            loadingText.text = "加载完成，正在连接服务器......";
            OnConnectedToServer();
        }
    }


    //连接服务器
    private void OnConnectedToServer()
    {
        //todo


        //允许异步加载完毕后自动切换场景
        //.allowSceneActivation = true;
    }
}
