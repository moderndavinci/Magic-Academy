using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour {

    Vector3 distance;
    Vector3 mousePosition;
    Vector3 mousePositionOrgin;
    float x,y;
    Transform UIRoot;
	// Use this for initialization
	void Start () {
        UIRoot = GameObject.FindWithTag("UIRoot").transform;
        distance = transform.position - UIRoot.position;

	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            mousePositionOrgin = Input.mousePosition;
            x = transform.rotation.x;
            y = transform.rotation.y;
        }
        //相机的旋转
        if(Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;
            float tempX = (mousePosition.x - mousePositionOrgin.x)/10;
            //相机的旋转
            transform.RotateAround(UIRoot.position, UIRoot.up, tempX);
            mousePositionOrgin = mousePosition;
        }
		
	}
}
