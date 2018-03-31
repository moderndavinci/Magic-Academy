using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowImage : MonoBehaviour {
    //private List<Image> props = new List<Image>();
    private List<Transform> props = new List<Transform>();
	// Use this for initialization
	void Start () {
        for (int i = 0; i < transform.childCount;i++)
        {
            props.Add(transform.GetChild(i));
        }
        for (int i = 0; i < PropImages.Instance.props.Count;i++)
        {
            props[PropImages.Instance.props[i]].gameObject.SetActive(false);
        }

	}
}
