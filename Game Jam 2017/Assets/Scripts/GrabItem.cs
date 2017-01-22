using UnityEngine;
using System.Collections;

public class GrabItem : MonoBehaviour {

    public GameObject coldMeter;
    private GameObject playerCont;
    private float directionX;

    void Start()
    {
        //playerCont = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        //playerCont = sfHandler.GetComponent<snowFallGenerate>().speedMotifier;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            coldMeter = GameObject.FindWithTag("Meter");
            coldMeter.GetComponent<BarScript>().WarmUp(0.1f);
            GetComponent<AudioSource>().Play();
            Destroy(GetComponent<BoxCollider2D>());
            GetComponent<Renderer>().enabled = false;
            //Destroy(gameObject, 0.47f);// Destroy the object -after- the sound played
        }
    }
}
