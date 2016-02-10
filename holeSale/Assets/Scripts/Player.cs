using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player : MonoBehaviour {
	public float speed = 50;
    public List<GameObject> CurrentTitles = new List<GameObject>();
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update () {
		//keyboard  input to move left and eright
		Vector3 moveDir = Vector3.zero;
        // checks to make sure character doesn't go off screen
        if(transform.position.x <288 && transform.position.x > -289)
        {
            moveDir.x = Input.GetAxis("Horizontal");
            transform.position += moveDir * speed * Time.deltaTime;
        }
        else if(transform.position.x >= 288)
        {
            transform.position = new Vector3(287, transform.position.y, -5);
        }
		else
        {
            transform.position = new Vector3(-287, transform.position.y, -5);
        }
        //Vector3 testmove = moveDir * speed * Time.deltaTime; 
        //if (testmove.x < 228 || testmove.x > -288)
        //{
        //    transform.position += testmove;
        //}
    }
   public void UnfreezeTitles() {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform temp = transform.GetChild(i);
            if (temp.name == "Title(Clone)" && temp.transform.position.y > gameObject.transform.position.y){

                temp.GetComponent<GameTitle>().Countdown = false;
                temp.position = new Vector3(temp.position.x, temp.position.y + 15);
                temp.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
               temp.tag = "Dropped";

            }
        }
    }
}
