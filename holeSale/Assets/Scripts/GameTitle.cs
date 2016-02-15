using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTitle : MonoBehaviour {
	public float speed = 10f;

	//private Vector3 movedir = new Vector3(0, -1, 0);
    public Text AmtInWallet;
    public Text TimePlayed;
    public string Name;
    public float Price;
    public float Discount;
    public float TimeNeeded;
    public bool Countdown = false;
    private GameObject PlayerBase;
    //private SpriteRenderer render;
    private TextMesh DiscountMesh;
    private float previoustime;
    void Awake()
    {
        DiscountMesh = GetComponentInChildren<TextMesh>();
        AmtInWallet = GameObject.FindGameObjectWithTag("Wallet").GetComponentInChildren<Text>();
        TimePlayed = GameObject.FindGameObjectWithTag("Finish").GetComponent<Text>();
        //render = GetComponent<SpriteRenderer>();
        //if (Name == "Fallout")
        //{
        //    render.sprite = Resources.Load<Sprite>("2D Assets/Titles 1_0");
        //}
        BoxCollider2D collision = gameObject.GetComponent<BoxCollider2D>();
        setDiscountTag();
        collision.size = new Vector2(5.3f, 1.59f);
    }
    //colliding gameObjects
    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("hit2");
        if (coll.gameObject.tag == "Player" && gameObject.tag == "Dropped")
        {
            //falling piece
            SetLast();
            PlayerBase.gameObject.tag = "Untagged";
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }


        //don't pick up  tiles if there are dropped pieces falling
        GameObject[] dropping = GameObject.FindGameObjectsWithTag("Dropped");
        if (dropping.Length == 0)
        {
            if (coll.gameObject.tag == "Player" && (coll.gameObject.transform.position.y + 15) < gameObject.transform.position.y)
            {
                //need to check x positin before combining
                if (coll.gameObject.transform.position.x + 40 > gameObject.transform.position.x && coll.gameObject.transform.position.x - 40 < gameObject.transform.position.x)
                {
                    gameObject.transform.parent = coll.gameObject.transform;
                    gameObject.tag = "Player";
                    coll.gameObject.tag = "Untagged";
                    Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
                    body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                    AmtInWallet.text = "$" + (float.Parse(AmtInWallet.text.Remove(0, 1)) - Price * (1 - Discount)).ToString("#.00");
                    TimePlayed.text = "" +( (float.Parse(TimePlayed.text)) + TimeNeeded);
                    previoustime = TimeNeeded;
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
                //Debug.Log("failed the y position");
                Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
            }
        }
        else
        {
            //Debug.Log("failed the y position");
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }

    }
	// Update is called once per frame
	void Update () {
        //transform.position += movedir * speed * Time.deltaTime;
        if (transform.position.y < -170)
        {
            Destroy(gameObject);
        }
        if (Countdown) {
            //check if 1 second has passed
           
            TimeNeeded -= Time.deltaTime;
            if (TimeNeeded < previoustime - 1)
            {
                //don't  go into negatives
                if (float.Parse(TimePlayed.text) > 0)
                {
                    TimePlayed.text = "" + ((float.Parse(TimePlayed.text)) - 1);
                }
                previoustime = TimeNeeded;
            }
            if (TimeNeeded <= 0)
            {
                PlayerBase.tag = "Player";
                PlayerBase.GetComponent<Player>().UnfreezeTitles();
                //take out child
                GameObject temp = gameObject.transform.Find("Title(Clone)").gameObject;
                temp.transform.parent = gameObject.transform.parent;
                Destroy(gameObject);
            }
        }

	}
    public void setDiscountTag()
    {
        //turn it into whole number for output
        float discounttemp = Discount * 100f;
        DiscountMesh.text = discounttemp.ToString() + "%"; 
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
        //gameObject.transform.parent = PlayerBase.transform;
    }
    void SetLast()
    {
        if(gameObject.transform.childCount == 1)
        {
            gameObject.tag = "Player";
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            return;
        }
        GameObject temp = gameObject.transform.Find("Title(Clone)").gameObject;
        while(temp.transform.childCount >1)
        {
            temp.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            temp.tag = "Untagged";
            temp = temp.transform.Find("Title(Clone)").gameObject;
        }
        temp.gameObject.tag = "Player";
        temp.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }
}
