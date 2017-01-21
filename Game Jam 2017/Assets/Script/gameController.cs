using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {

    Animation playAni;

    public float playerSpeed;
    private float moveDirectionX;
    private float moveDirectionY;
    private float moveDirectionYG;
    public float jumpSpeed;


    private float gravity = 8.9f;
    private float playerY;

    private bool groundBool;

    private GameObject levelH;

    private GameObject ground;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {

        groundBool = false;

        rb = GetComponent<Rigidbody2D>();
        playAni = GetComponent<Animation>();

        ground = GameObject.FindGameObjectWithTag("groundGO");
        levelH = GameObject.FindGameObjectWithTag("levelHandler");

        playAni.Play("idle");
    }
	
	// Update is called once per frame
	void Update () {

        moveDirectionX = Input.GetAxis("Horizontal");
        moveDirectionX *= playerSpeed;
        //moveDirectionY -= gravity * Time.deltaTime;

        if ((Input.GetButtonDown("Jump") && groundBool))
        {
            groundBool = false;
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }

        levelH.transform.Translate(Vector3.left * moveDirectionX * Time.deltaTime);
        

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "groundGO")
        {
            if(!groundBool)
            {
                groundBool = true;
            }
            
        }
    }
}
