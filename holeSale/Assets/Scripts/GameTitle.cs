using UnityEngine;
using System.Collections;

public class GameTitle : MonoBehaviour {
	public float speed = 10f;
	private Vector3 movedir = new Vector3(0, -1, 0);
    public string Name;
    public float Price;
    public float Discount;
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
    // Use this for initialization
    void Start () {

 
	}
    void OnCollision2D(Collider2D coll)
    {
        Debug.Log("hit");
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("hit2");
        gameObject.transform.parent = coll.gameObject.transform;
    }
	// Update is called once per frame
	void Update () {
		transform.position += movedir * speed * Time.deltaTime;
		if(transform.position.y < -170)
		{
			Destroy(gameObject);
		}
	}
}
