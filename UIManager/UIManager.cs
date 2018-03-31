using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    //Scene名称
    public class SceneName{
        public static string PanelPlanet = "PanelPlanet";
        public static string PanelMap = "PanelMap";
    }

    public class UIManager : MonoSingTon<UIManager>
    {

        //private List<UIScene> UIScenes = new List<UIScene>();
        private Dictionary<string, UIScene> UIScenes = new Dictionary<string, UIScene>();

        //当前显示的UIScene
        public UIScene CurrentUIScene;

        //初始化
        public void Init(Transform tran)
        {
            FindScene(tran);
        }

        //递归查找所有的UIScene
        public void FindScene(Transform t)
        {
            UIScene scene = t.GetComponent<UIScene>();
            if(scene!=null)
            {
                UIScenes.Add(scene.name,scene);
                scene.gameObject.SetActive(false);
            }
            for (int i = 0; i < t.childCount; i++)
            {
                FindScene(t.GetChild(i));
            }
        }
        //提供获取UIScene的接口
        public UIScene GetUIScene(string name)
        {
            if(UIScenes.ContainsKey(name))
            {
                return UIScenes[name];
            }
            return null;
        }
        //提供设置显示某个UIScene的接口
        public void UIsceneSetActive(string name)
        {
            if(UIScenes.ContainsKey(name))
            {
                CurrentUIScene.gameObject.SetActive(false);
                UIScenes[name].gameObject.SetActive(true);
                CurrentUIScene = UIScenes[name];
            }
        }
        //显示某个界面
        public void UISceneOpen(string firstPanel)
        {
            CurrentUIScene = UIScenes[firstPanel];
            CurrentUIScene.gameObject.SetActive(true);
        }
        /// <summary>
        /// 关闭某个界面
        /// </summary>
        /// <param name="Panel_Name">Panel name.</param>
        public void UISceneClose(string Panel_Name)
        {
            UIScenes[Panel_Name].gameObject.SetActive(false);
        }

    }
}
