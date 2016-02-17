using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MoneyGainLoss : MonoBehaviour
{
    public Text AmtInWallet;
    public float Cost;
    private int attempts = 0;
    public GameObject manager;
    // Use this for initialization
    void Awake()
    {
        AmtInWallet = GameObject.FindGameObjectWithTag("Wallet").GetComponentInChildren<Text>();
        manager = GameObject.FindGameObjectWithTag("GameManager");
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("hit2");
        //don't pick up  tiles if there are dropped pieces falling
        GameObject[] dropping = GameObject.FindGameObjectsWithTag("Dropped");
        if (dropping.Length == 0)
        {
            if (coll.gameObject.tag == "Player")
            {
                //collided
                if (gameObject.name == "Money(Clone)")
                {
                    AmtInWallet.text = "$" + (float.Parse(AmtInWallet.text.Remove(0, 1)) + Cost);
                }
                else
                {
                    AmtInWallet.text = "$" + (float.Parse(AmtInWallet.text.Remove(0, 1)) - Cost);
                }
                //gameObject.transform.parent = coll.gameObject.transform;
                //gameObject.tag = "Player";
                //coll.gameObject.tag = "Untagged";
                //Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
                //body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                Destroy(gameObject);
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
    void Update()
    {
        if (transform.position.y < -170)
        {
            if (gameObject.name == "Bill(Clone)")
            {
                attempts++;
                manager.GetComponent<Gamemanager>().attempts++;
            }
            
            Destroy(gameObject);
        }
    }
}


