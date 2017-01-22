using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {

    Animator playAni;

    //animation states - the values in the animator conditions
    const int STATE_IDLE = 0;
    const int STATE_WALK = 1;
    const int STATE_JUMP = 2;
    const int STATE_FALL = 3;

    string _currentDirection = "right";
    int _currentAnimationState = STATE_IDLE;

    public float playerSpeed;
    public float moveDirectionX;
    private float moveDirectionY;
    private float moveDirectionYG;
    public float jumpSpeed;


    private float gravity = 8.9f;
    private float playerY;

    private bool groundBool;

    private bool canMove;

    private GameObject levelH;

    private GameObject coffeeGO;

    private GameObject ground;
    private GameObject leftCollider;
    private Rigidbody2D rb;

    private GameObject sfHandler;
    private float speedMod;

    private GameObject icepatch;
    private GameObject snowPile;


    private bool playerSlipping;

    // Use this for initialization
    void Start () {

        groundBool = false;

        canMove = false;

        rb = GetComponent<Rigidbody2D>();
        playAni = GetComponent<Animator>();

        ground = GameObject.FindGameObjectWithTag("groundGO");
        leftCollider = GameObject.FindGameObjectWithTag("leftCollider");
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

        if (moveDirectionX < 0.0f || playerSlipping)
        {
            moveDirectionX = 0.0f;
        }

        if (playerSlipping)
        {
            changeState(STATE_FALL);
        }
        else if (Input.GetKey("right"))
        {
            changeDirection("right");
            if (GetComponent<Transform>().position.x <= 0)
                transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);

            if (groundBool)
                changeState(STATE_WALK);

        }
        else if (Input.GetKey("left"))
        {
            changeDirection("left");
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);

            if (groundBool)
                changeState(STATE_WALK);
        }
        else
        {
            if (groundBool)
                changeState(STATE_IDLE);
        }

        if ((Input.GetButtonDown("Jump") && groundBool && !playerSlipping))
        {
            groundBool = false;
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            changeState(STATE_JUMP);
        }

        moveDirectionX = Input.GetAxis("Horizontal");

        moveDirectionX *= playerSpeed;
        //moveDirectionY -= gravity * Time.deltaTime;

        if (_currentDirection == "right" && GetComponent<Transform>().position.x >= 0 && !playerSlipping)
        {
            levelH.transform.Translate(Vector3.left * moveDirectionX * Time.deltaTime);
            coffeeGO.transform.Translate(Vector3.left * moveDirectionX * Time.deltaTime);
            icepatch.transform.Translate(Vector3.left * moveDirectionX * Time.deltaTime);
            snowPile.transform.Translate(Vector3.left * moveDirectionX * Time.deltaTime);
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "groundGO")
        {
            if(!groundBool)
            {
                groundBool = true;
            }

            changeState(STATE_IDLE);
        }
    }

    //--------------------------------------
    // Change the players animation state
    //--------------------------------------
    void changeState(int state)
    {

        if (_currentAnimationState == state)
            return;

        switch (state)
        {

            case STATE_WALK:
                playAni.SetInteger("state", STATE_WALK);
                break;

            case STATE_JUMP:
                playAni.SetInteger("state", STATE_JUMP);
                break;

            case STATE_FALL:
                playAni.SetInteger("state", STATE_FALL);
                break;

            case STATE_IDLE:
                playAni.SetInteger("state", STATE_IDLE);
                break;

        }

        _currentAnimationState = state;
    }

    //--------------------------------------
    // Flip player sprite for left/right walking
    //--------------------------------------
    void changeDirection(string direction)
    {

        if (_currentDirection != direction)
        {
            if (direction == "right")
            {
                transform.Rotate(0, 180, 0);
                transform.Translate(-1f, 0, 0);
                _currentDirection = "right";
            }
            else if (direction == "left")
            {
                transform.Rotate(0, -180, 0);
                transform.Translate(-1f, 0, 0);
                _currentDirection = "left";
            }
        }

    }

}
