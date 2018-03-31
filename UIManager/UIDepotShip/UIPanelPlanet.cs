using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tools;

namespace UI
{
    public class UIPanelPlanet : UIScene
    {

        //private OnTriggerEvent planet_1;
        //private OnTriggerEvent planet_2;
        //private OnTriggerEvent planet_3;
        //private OnTriggerEvent planet_4;
        private Button planet_1;
        private Button planet_2;
        private Button planet_3;
        private Button planet_4;

        private OnTriggerEvent image_Left;
        private OnTriggerEvent image_Right;
        //滑动窗口
        [SerializeField]
        private PageView pageView;
        private int current = 0;
        // Use this for initialization
        void Start()
        {
            base.Start();

            //分配职责
            //场景图片
            //planet_1 = GetUIEventTrigger("Planet_1");
            //planet_2 = GetUIEventTrigger("Planet_2");
            //planet_3 = GetUIEventTrigger("Planet_3");
            //planet_4 = GetUIEventTrigger("Planet_4");
            planet_1 = TransformHelper.FindChild(transform, "Planet_1").GetComponent<Button>();
            planet_2 = TransformHelper.FindChild(transform, "Planet_2").GetComponent<Button>();
            planet_3 = TransformHelper.FindChild(transform, "Planet_3").GetComponent<Button>();
            planet_4 = TransformHelper.FindChild(transform, "Planet_4").GetComponent<Button>();
            //左右滑动
            image_Left = GetUIEventTrigger("Image_Left");
            image_Right = GetUIEventTrigger("Image_Right");

            //绑定事件
            //planet_1.onPointerClick += EnterPlanet01;
            //planet_2.onPointerClick += EnterPlanet02;
            //planet_3.onPointerClick += EnterPlanet03;
            //planet_4.onPointerClick += EnterPlanet04;

            planet_1.onClick.AddListener(EnterPlanet01);
            planet_2.onClick.AddListener(EnterPlanet02);
            planet_3.onClick.AddListener(EnterPlanet03);
            planet_4.onClick.AddListener(EnterPlanet04);

            image_Left.onPointerClick += MoveLeft;
            image_Right.onPointerClick += MoveRight;
        }

        public void EnterPlanet01()
        {
            SceneNumber.Instance.ChangScene(SceneNumber.Instance.planet_1);
            SceneMusic.Instance.PlayAudio(SceneMusic.Instance.button,transform.position);
        }
        public void EnterPlanet02()
        {
            SceneNumber.Instance.ChangScene(SceneNumber.Instance.planet_2);
            SceneMusic.Instance.PlayAudio(SceneMusic.Instance.button, transform.position);
        }
        public void EnterPlanet03()
        {
            SceneNumber.Instance.ChangScene(SceneNumber.Instance.planet_3);
            SceneMusic.Instance.PlayAudio(SceneMusic.Instance.button, transform.position);
        }
        public void EnterPlanet04()
        {
            SceneNumber.Instance.ChangScene(SceneNumber.Instance.planet_4);
            SceneMusic.Instance.PlayAudio(SceneMusic.Instance.button, transform.position);
        }
        public void MoveLeft()
        {
            SceneMusic.Instance.PlayAudio(SceneMusic.Instance.button, transform.position);
            if (current - 1 >= 0)
            {
                current--;
                pageView.pageTo(current);
            }
        }
        public void MoveRight()
        {
            SceneMusic.Instance.PlayAudio(SceneMusic.Instance.button, transform.position);
            if (current + 1 < 4)
            {
                current++;
                pageView.pageTo(current);
            }
        }

    }
}
