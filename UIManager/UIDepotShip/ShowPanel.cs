using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShowPanel : MonoBehaviour
    {
        private Button PanelPlanet;
        private Button PanelMap;

        int a = 0, b = 0;
        private void Start()
        {
            PanelPlanet = GameObject.FindWithTag("PanelPlanet").GetComponent<Button>();
            PanelMap=GameObject.FindWithTag("PanelMap").GetComponent<Button>();

            PanelPlanet.onClick.AddListener(ShowPanelPlanet);
            PanelMap.onClick.AddListener(ShowPanelMap);
        }

        public void ShowPanelPlanet()
        {
            b = 0;
            OpenPanelPlanet();
            a++;
            if (a == 2)
            {
                UIManager.Instance.UISceneClose(SceneName.PanelPlanet);
                a = 0;
            }
        }
        public void ShowPanelMap()
        {
            a = 0;
            OpenPanelMap();
            b++;
            if (b == 2)
            {
                UIManager.Instance.UISceneClose(SceneName.PanelMap);
                b = 0;
            }
        }
        public void OpenPanelPlanet()
        {
            UIManager.Instance.UIsceneSetActive(SceneName.PanelPlanet);
            SceneMusic.Instance.PlayAudio(SceneMusic.Instance.button, transform.position);
        }
        public void OpenPanelMap()
        {
            UIManager.Instance.UIsceneSetActive(SceneName.PanelMap);
            SceneMusic.Instance.PlayAudio(SceneMusic.Instance.button, transform.position);
        }
    }
}
