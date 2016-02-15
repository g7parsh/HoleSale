using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player : MonoBehaviour {
	public float speed = 50;
    public List<GameObject> CurrentTitles = new List<GameObject>();
    public Animator Anim;
    Transform PlayerSideRig;
    
	// Use this for initialization
	void Start () {
        Anim = GetComponentInChildren<Animator>();
        PlayerSideRig = GameObject.Find("MascotRig_Side").transform;
	}

    // Update is called once per frame
    void Update () {

        if (CurrentTitles.Count > 0)
        {
            Anim.SetBool("hasTitles", true);
        }
        else
        {
            Anim.SetBool("hasTitles", false);
        }
       
        //keyboard  input to move left and eright
        Vector3 moveDir = Vector3.zero;
        Anim.SetBool("walking", false);
        
        if (Input.GetKey(KeyCode.LeftArrow)) {
            Anim.SetBool("walking", true);

            PlayerSideRig.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Anim.SetBool("walking", true);

            PlayerSideRig.localScale = new Vector3(1, 1, 1);
        }
        // checks to make sure character doesn't go off screen
        if (transform.position.x <288 && transform.position.x > -289)
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
        //remove the top title cause its gone
        CurrentTitles.RemoveAt(0);
        foreach(GameObject g in CurrentTitles)
        {
            g.tag = "Dropped";
            g.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    Transform temp = transform.GetChild(i);
        //    if (temp.name == "Title(Clone)" && temp.transform.position.y > gameObject.transform.position.y){

        //        temp.GetComponent<GameTitle>().Countdown = false;
        //        //not work because all of them are are being shifted
        //        temp.position = new Vector3(temp.position.x, temp.position.y + 20);
        //        temp.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        //        temp.tag = "Dropped";

        //    }
        //}
    }
}
