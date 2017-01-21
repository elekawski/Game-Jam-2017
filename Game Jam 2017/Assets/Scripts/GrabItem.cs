using UnityEngine;
using System.Collections;

public class GrabItem : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "CharacterRobotBoy")
        {
            GetComponent<AudioSource>().Play();
            Destroy(GetComponent<BoxCollider2D>());
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, 0.47f);// Destroy the object -after- the sound played
        }
    }
}
