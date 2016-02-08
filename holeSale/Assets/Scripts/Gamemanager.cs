using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private float starttime;
    public GameObject[] Titles;
    public GameObject test;
	
	
	// Use this for initialization
	void Start () {
		starttime =Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - starttime > 3)
		{
			//generate the game title prefab
            GameObject temp = Instantiate(test);
            temp.GetComponent<GameTitle>().Name = "Fallout";

            SetSprite("Fallout", temp);
//			temp.transform.parent = screencanvas.transform;

			//starting postiont

			float startposx = Random.Range(-280f,280f);
			Vector3 startpos = new Vector3 (startposx, 160f, -5);
			temp.transform.position = startpos;
			starttime = Time.time;
		}
	}

    void SetSprite(string name, GameObject go)
    {
        SpriteRenderer render;
        render = go.GetComponent<SpriteRenderer>();
        if (name == "Fallout")
        {
            Sprite[] icons = Resources.LoadAll<Sprite>("2D Assets/Titles 1");
            render.sprite = icons[0];
        }

    }
}
