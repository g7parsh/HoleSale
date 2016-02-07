using UnityEngine;
using System.Collections;

public class GameTitle : MonoBehaviour {
	public float speed = 10f;
	private Vector3 movedir = new Vector3(0, -1, 0);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += movedir * speed * Time.deltaTime;
		if(transform.position.y < -5)
		{
			Destroy(gameObject);
		}
	}
}
