using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateProps : MonoBehaviour {
    public List<Transform> propTransform=new List<Transform>();
    private GameObject[] propPrefab;
	// Use this for initialization
	void Awake () {
        propPrefab = Resources.LoadAll<GameObject>("PropsPrefabs");
        int n = propPrefab.Length;
        for (int i = 0; i < n;i++)
        {
            //创建游戏道具/设置它的父物体/存到List列表里
            GameObject propPrefabClone=Instantiate(propPrefab[i],transform.GetChild(i).position,Quaternion.identity);
            propTransform.Add(propPrefabClone.transform);
            propPrefabClone.transform.SetParent(transform.GetChild(i));
        }
	}
}
