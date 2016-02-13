using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MoneyGainLoss : MonoBehaviour
{
    public Text AmtInWallet;
    public float Cost;
    // Use this for initialization
    void Awake()
    {
        AmtInWallet = GameObject.FindGameObjectWithTag("Wallet").GetComponentInChildren<Text>();
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("hit2");
        //don't pick up  tiles if there are dropped pieces falling
        GameObject[] dropping = GameObject.FindGameObjectsWithTag("Dropped");
        if (dropping.Length == 0)
        {
            if (coll.gameObject.tag == "Player" && (coll.gameObject.transform.position.y + 15) < gameObject.transform.position.y)
            {
                //need to check x positin before combining
                if (coll.gameObject.transform.position.x + 40 > gameObject.transform.position.x && coll.gameObject.transform.position.x - 40 < gameObject.transform.position.x)
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
    void Update()
    {

    }
}


