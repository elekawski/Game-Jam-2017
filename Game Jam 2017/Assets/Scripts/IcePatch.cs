using UnityEngine;
using System.Collections;

public class IcePatch : MonoBehaviour {

    private GameObject coldMeter;
    private GameObject player;

    private bool complete;
    private bool playerEntered;
    private int timesPressed;
    public bool disableMove;

    // Use this for initialization
    void Start ()
    {
        complete = false;
        playerEntered = false;
        disableMove = false;
    }

    // Update is called once per frame
    void Update ()
    {
	    if(!complete && playerEntered)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                timesPressed += 1;
            }

            if (timesPressed >= 3)
            {
                StopCoroutine(CatchBalance());

                complete = true;

                print("Safe!");

                disableMove = false;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!complete && !playerEntered)
        {
            if (other.gameObject.tag == "Player")
            {
                print("Starting to fall...");

                coldMeter = GameObject.FindWithTag("Meter");

                player = GameObject.FindWithTag("Player");
                
                playerEntered = true;

                StartCoroutine(CatchBalance());

                disableMove = true;

            }
        }
    }

    private IEnumerator CatchBalance()
    {
        yield return new WaitForSeconds(3);

        if (!complete)
        {
            print("Slipped!");

            coldMeter.GetComponent<BarScript>().CoolDown(0.1f);

            complete = true;

            disableMove = false;
        }
    }
}
