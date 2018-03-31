using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow01 : MonoBehaviour {

    public Transform player;
    private Vector3 targetPosition;
    public int backDistance;
    public int backHigh;
    public float smoothMove;
	// Use this for initialization
	void Start () {
        //player = GameObject.FindWithTag("CameraPoint").transform;
        Time.timeScale = 1;
	}

    private void LateUpdate()
    {
       
        targetPosition = player.position + player.up * backHigh + -player.forward * backDistance;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothMove);
        transform.LookAt(player.position);

    }
}
