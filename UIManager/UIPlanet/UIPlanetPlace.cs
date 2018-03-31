using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using DataManager;
using UnityEngine.UI;

namespace UI
{
    public class UIPlanetPlace : MonoSingTon<UIPlanetPlace>
    {
        //血量和蓝量
        public Image player_HP;
        public Image player_SP;
        public Image mHP;
        public Image mSP;
        //设置界面
        public Transform showSetting;
        public Slider sliderMusic;
        //物品格
        public Transform showBack;
        //按钮集合
        public Dictionary<string, Button> buttons = new Dictionary<string, Button>();
        //Slider声音
        // Use this for initialization
        void Start()
        {
            //找到相关组件或物体
            FindALLButton(transform);

            player_HP = TransformHelper.FindChild<Image>(transform, "Image_HP");
            player_SP = TransformHelper.FindChild<Image>(transform, "Image_SP");

            mHP = TransformHelper.FindChild<Image>(transform, "Image_MHP");
            mSP = TransformHelper.FindChild<Image>(transform, "Image_MSP");

            showSetting = TransformHelper.FindChild(transform, "Image_Setting");
            showBack = TransformHelper.FindChild(transform, "Image_Back");
            int n = ShipManager.Instance.backPack.Count;
            //为背包的物品添加监听事件
            for (int i = 0; i < n;i++)
            {
                int k=i;
                showBack.GetChild(k).GetComponent<Image>().sprite
                        = Resources.Load<Sprite>("Sprites/DepotShip/" + ShipManager.Instance.backPack[i].eqName);
                showBack.GetChild(k).GetComponent<Button>().onClick.AddListener(ButtonGoods);
            }

            //为按钮添加事件

            buttons["Setting"].onClick.AddListener(ButtonSetting);
            buttons["Button_BackShip"].onClick.AddListener(ButtonBackShip);
            buttons["Button_ExitGame"].onClick.AddListener(ButtonExit);
            buttons["Button_Cancle"].onClick.AddListener(ButtonCancle);


        }


        //递归查找子物体(Button)
        public void FindALLButton(Transform t)
        {
            Button temp = t.GetComponent<Button>();
            if (temp != null)
            {
                buttons.Add(temp.name, temp);
            }
            for (int i = 0; i < t.childCount; i++)
            {
                FindALLButton(t.GetChild(i));
            }
        }
        /////////////////////////////////////按钮事件
        //设置按钮
        public void ButtonSetting()
        {
            showSetting.gameObject.SetActive(true);
            SceneMusic.Instance.PlayAudio(SceneMusic.Instance.button,showSetting.position);
        }
        //返回飞船按钮
        public void ButtonBackShip()
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                PickProps temp = GameObject.FindWithTag("Player").GetComponent<PickProps>();
                int n = temp.propInt.Length;
                for (int i = 0; i < n;i++)
                {
                    PropImages.Instance.PasteProp(temp.propInt[i]);
                }
            }
            SceneMusic.Instance.PlayAudio(SceneMusic.Instance.button, showSetting.position);
            SceneNumber.Instance.ChangScene(SceneNumber.Instance.depotShip);
        }
        //退出游戏
        public void ButtonExit()
        {
            SceneMusic.Instance.PlayAudio(SceneMusic.Instance.button, showSetting.position);
            Application.Quit();
        }
        //取消设置
        public void ButtonCancle()
        {
            showSetting.gameObject.SetActive(false);
            SceneMusic.Instance.PlayAudio(SceneMusic.Instance.button, showSetting.position);
        }

        //使用物品按钮
        public void ButtonGoods()
        {
            
        }


    }
}
