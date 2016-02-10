using UnityEngine;
using System.Collections;

public class GameTitle : MonoBehaviour {
	public float speed = 10f;
	//private Vector3 movedir = new Vector3(0, -1, 0);
    public string Name;
    public float Price;
    public float Discount;
    public float TimeNeeded;
    public bool Countdown = false;
    private GameObject PlayerBase;
    private SpriteRenderer render;
    void Awake()
    {
        //render = GetComponent<SpriteRenderer>();
        //if (Name == "Fallout")
        //{
        //    render.sprite = Resources.Load<Sprite>("2D Assets/Titles 1_0");
        //}
        BoxCollider2D collision = gameObject.GetComponent<BoxCollider2D>();
        collision.size = new Vector2(5.3f, 1.59f);
    }
    //colliding gameObjects
    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("hit2");
        if ((coll.gameObject.tag == "Player" || coll.gameObject.tag == "Dropped") && (coll.gameObject.transform.position.y + 15) < gameObject.transform.position.y)
        {
            //need to check x positin before combining
            if (coll.gameObject.transform.position.x + 40 > gameObject.transform.position.x && coll.gameObject.transform.position.x - 40 < gameObject.transform.position.x)
            {
                gameObject.transform.parent = coll.gameObject.transform;
                gameObject.tag = "Player";
                coll.gameObject.tag = "Untagged";
                Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
                body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                GetToPlayer();
            }
            else
            {
                Debug.Log("Failed the x pos check");
                Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
            }
        }
        else
        {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
        
    }
	// Update is called once per frame
	void Update () {
		//transform.position += movedir * speed * Time.deltaTime;
		if(transform.position.y < -170)
		{
			Destroy(gameObject);
		}
        if (Countdown) {
            TimeNeeded -= Time.deltaTime;
            if (TimeNeeded <= 0)
            {
                PlayerBase.tag = "Player";
                PlayerBase.GetComponent<Player>().UnfreezeTitles();
                Destroy(gameObject);
            }
        }

	}
    void GetToPlayer()
    {
        Countdown = true;
        Transform temp = gameObject.transform;
        while (temp.transform.parent != null)
        {
            temp = temp.transform.parent;
        }
        temp.GetComponent<Player>().CurrentTitles.Add(gameObject);
        PlayerBase = temp.gameObject;
        gameObject.transform.parent = PlayerBase.transform;
    }
}
