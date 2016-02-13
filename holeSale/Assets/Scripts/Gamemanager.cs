using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private float starttime;
    private float MoneyStartTime;
    private float BillStartTime;
    //public GameObject[] Titles;
    public GameObject test;
    public string[] Titles;
	float[] discounts = {.25f,.50f,.75f,.90f};
	
	// Use this for initialization
	void Start () {
		starttime =Time.time;
        MoneyStartTime = Time.time;
        BillStartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - starttime > 3f)
		{
			//generate the game title prefab
            GameObject temp = Instantiate(test);
            GameTitle tempObj = temp.GetComponent<GameTitle>();
            SetSprite(Titles[Random.Range(0,Titles.Length)], temp);
            tempObj.Discount = discounts[Random.Range(0, discounts.Length)];
            tempObj.setDiscountTag();
//			temp.transform.parent = screencanvas.transform;

			//starting postiont
			float startposx = Random.Range(-280f,280f);
			Vector3 startpos = new Vector3 (startposx, 160f, -3);
			temp.transform.position = startpos;
			starttime = Time.time;
		}
        //different starting time for the Money drops
        if (Time.time - MoneyStartTime > 20f)
        {
            GameObject temp = (GameObject)Instantiate(Resources.Load("Prefabs/Money"));
            //starting postiont
            float startposx = Random.Range(-280f, 280f);
            Vector3 startpos = new Vector3(startposx, 160f, -3);
            temp.transform.position = startpos;
            
            MoneyStartTime = Time.time;
        }
        if (Time.time - BillStartTime > 10f)
        {
            GameObject temp = (GameObject)Instantiate(Resources.Load("Prefabs/Bill"));
            //starting postiont
            float startposx = Random.Range(-280f, 280f);
            Vector3 startpos = new Vector3(startposx, 160f, -3);
            temp.transform.position = startpos;

            BillStartTime = Time.time;
        }
    }

    void SetSprite(string name, GameObject go)
    {
        SpriteRenderer render;
        Sprite[] icons = Resources.LoadAll<Sprite>("2D Assets/Titles 1");

        render = go.GetComponent<SpriteRenderer>();
        if (name.ToLower() == "fallout")
        {
            render.sprite = icons[0];
        }
        if (name.ToLower() == "farcry")
        {
            render.sprite = icons[1];
        }
        if (name.ToLower() == "octodad")
        {
            render.sprite = icons[2];
        }
    }
}
