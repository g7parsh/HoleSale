using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//keyboard  input to move left and eright
		Vector3 moveDir = Vector3.zero;
		moveDir.x = Input.GetAxis("Horizontal");
		transform.position += moveDir * speed * Time.deltaTime;
	}
}
