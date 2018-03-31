using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoginScene : ManagerScene<LoginScene> {
    public Image loadbackground;
    Image imageLoad;
    float moveDistance;
	// Use this for initialization
	void Start () {
        loadbackground = GameObject.Find("Panel").GetComponent<Image>();
        loadbackground.sprite = Resources.Load<Sprite>("Sprites/LoginAtlas/" + SceneNumber.Instance.defualt);
        imageLoad = GameObject.FindWithTag("Loading").GetComponent<Image>();
        //切换场景
        LoadGame(SceneNumber.Instance.defualt);
	}
    private IEnumerator StartLoading(string sceneName)
    {
        int displayProgress = 0;
        int toProgress = 0;
        AsyncOperation op =SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            toProgress = (int)op.progress * 100;
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                //显示当前数值
                SetLoadingPercentage(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }
        toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            SetLoadingPercentage(displayProgress);
            yield return new WaitForEndOfFrame();
        }
        op.allowSceneActivation = true;
    }
    public void LoadGame(string sceneName)
    {
        StartCoroutine(StartLoading(sceneName));
    }
    //执行当前的数字
    public void SetLoadingPercentage(int num)
    {
        imageLoad.fillAmount = num / 100f;
    }
}
