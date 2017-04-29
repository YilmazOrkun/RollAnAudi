using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;


	// Use this for initialization
	void Start () 
    {
        offset = transform.position - player.transform.position; //difference between the mainCamera and the players position
	}
	
	// run after all items have been processed in update
	void LateUpdate ()
    {
        transform.position = player.transform.position + offset; //camera is moved into a new position aligned with the player object
	}
}
