using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {

    Animator playAni;

    public float playerSpeed;
    public float moveDirectionX;
    private float moveDirectionY;
    private float moveDirectionYG;
    public float jumpSpeed;


    private float gravity = 8.9f;
    private float playerY;

    private bool groundBool;

    private GameObject levelH;

    private GameObject coffeeGO;

    private GameObject ground;
    private Rigidbody2D rb;

    private GameObject sfHandler;
    private float speedMod;

    private GameObject icepatch;
    private GameObject snowPile;


    private bool playerSlipping;

    // Use this for initialization
    void Start () {

        groundBool = false;

        rb = GetComponent<Rigidbody2D>();
        playAni = GetComponent<Animator>();

        ground = GameObject.FindGameObjectWithTag("groundGO");
        levelH = GameObject.FindGameObjectWithTag("levelHandler");
        sfHandler = GameObject.FindGameObjectWithTag("snowFallHandler");

        icepatch = GameObject.FindGameObjectWithTag("icePatch");

        coffeeGO = GameObject.FindGameObjectWithTag("Item");
        snowPile = GameObject.FindGameObjectWithTag("snowPile");
    }
	
	// Update is called once per frame
	void Update () {

        playerSlipping = icepatch.GetComponent<IcePatch>().disableMove;

        speedMod = sfHandler.GetComponent<snowFallGenerate>().speedMotifier;

        playAni.speed = speedMod;

        moveDirectionX = Input.GetAxis("Horizontal");

        if (moveDirectionX < 0.0f || playerSlipping)
        {
            moveDirectionX = 0.0f;
        }

        moveDirectionX *= playerSpeed;
        //moveDirectionY -= gravity * Time.deltaTime;
        
        

        if ((Input.GetButtonDown("Jump") && groundBool && !playerSlipping))
        {
            groundBool = false;
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }

        levelH.transform.Translate(Vector3.left * moveDirectionX * Time.deltaTime);
        coffeeGO.transform.Translate(Vector3.left * moveDirectionX * Time.deltaTime);
        icepatch.transform.Translate(Vector3.left * moveDirectionX * Time.deltaTime);
        snowPile.transform.Translate(Vector3.left * moveDirectionX * Time.deltaTime);

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
