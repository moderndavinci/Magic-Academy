using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickProps : MonoBehaviour {
    private List<Image> propImages = new List<Image>();
    private List<Sprite> propSprite = new List<Sprite>();
    private Transform image_Back;
    private CreateProps propPrefab;
    private Transform tempTransform;
    private int tempIndex=-1,num01,num02,tempIndex01=0;
    public int[] propInt;
	// Use this for initialization
	void Start () {
        //获取到碎片Image组件
        image_Back = GameObject.FindWithTag("Shards").transform;
        propPrefab = GameObject.FindWithTag("Enemys").GetComponent<CreateProps>();
        num01 = propPrefab.propTransform.Count;
        print(num01);
        num02= image_Back.childCount;
        propInt = new int[num02];
        for (int i = 0; i < num02;i++)
        {
            propImages.Add(image_Back.GetChild(i).GetChild(0).GetComponent<Image>());
        }
        //获取到碎片图片包
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/PropsImage");
        for (int i = 0; i < sprites.Length;i++)
        {
            propSprite.Add(sprites[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(propPrefab.propTransform[0].name);
        //tempTransform= propPrefab.propTransform.Find(p=>Vector3.Distance(p.position,transform.position)<2.0f);
        for (int i = 0; i < num01;i++)
        {
            Debug.Log(propPrefab.propTransform[i].name);
            if(Vector3.Distance(propPrefab.propTransform[i].position, transform.position) < 3.0f)
            {
                tempIndex = i;
            }
        }
        if(tempIndex!=-1)
        {
            if (tempIndex01<num02)
            {
                ShowShard(tempIndex01);
                propInt[tempIndex01] = tempIndex;
                tempIndex01++;
                tempIndex = -1;
            }
            else
            {
                ShowShard(num02-1);
                propInt[num02 - 1] = tempIndex;
            }
        }
	}
    public void ShowShard(int _Index)
    {
        propImages[_Index].sprite = propSprite[tempIndex];
        propImages[_Index].gameObject.SetActive(true);
        propPrefab.propTransform[tempIndex].gameObject.SetActive(false);
        //propPrefab.propTransform.Remove(propPrefab.propTransform[tempIndex]);
        propPrefab.propTransform[tempIndex].position =
                      new Vector3(propPrefab.propTransform[tempIndex].position.x, -20, propPrefab.propTransform[tempIndex].position.z);
    }
}
