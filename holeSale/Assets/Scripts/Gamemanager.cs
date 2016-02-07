using UnityEngine;
using System.Collections;

public class Gamemanager : MonoBehaviour {
	private float starttime;
	private float titlewidth = 10f;
	public Canvas screencanvas;
	// Use this for initialization
	void Start () {
		starttime =Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - starttime > 3)
		{
			//generate the game title prefab
			GameObject temp = (GameObject)GameObject.Instantiate(Resources.Load("Prefab/gametitles"));
			temp.transform.parent = screencanvas.transform;

			//starting postiont

			float startposx = Random.Range(titlewidth, Screen.width - titlewidth);
			Vector3 startpos = new Vector3 (startposx, Screen.height, 0);
			temp.transform.position = startpos;
			starttime = Time.time;
		}
	}
}
