using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIInit : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            UIManager.Instance.Init(transform);
            UIManager.Instance.CurrentUIScene = UIManager.Instance.GetUIScene(SceneName.PanelPlanet);
            UIManager.Instance.UIsceneSetActive(SceneName.PanelPlanet);
        }
    }
}
