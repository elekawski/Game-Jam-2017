using UnityEngine;
using System.Collections;

public class snowFall : MonoBehaviour {

    private GameObject outsideGO;

    public float omegaX;
    public float ampX;
    private float index;

    private float scaleFactor;
    private float omegaXFactor;
    private float ampXFactor;
    private float gravityFactor;

    private GameObject sfHandler;
    private float speedMod;

    // Use this for initialization
    void Start () {
        scaleFactor = Random.Range(0.5f, 1.0f);
        omegaXFactor = Random.Range(0.1f, 1.0f);
        ampXFactor = Random.Range(0.1f, 1.0f);
        gravityFactor = Random.Range(0.1f, 2.0f);

        transform.localScale = new Vector3(transform.localScale.x * scaleFactor, transform.localScale.y * scaleFactor, transform.localScale.z);
        ampX *= ampXFactor;
        omegaX *= omegaXFactor;

        sfHandler = GameObject.FindGameObjectWithTag("snowFallHandler");
    }
	
	// Update is called once per frame
	void Update () {
        index += Time.deltaTime;

        speedMod = sfHandler.GetComponent<snowFallGenerate>().speedMotifier;

        float x = ampX * Mathf.Cos(omegaX * index);
        //transform.position.x = new Vector3(x, 0, 0);
        transform.Translate(Vector3.up * -0.089f * gravityFactor * speedMod * Time.deltaTime);
        transform.Translate(Vector3.right * x);

        if(transform.position.y < -5.5f)
        {
            float ranX = Random.Range(-5.5f, 5.5f);

            transform.position = new Vector3 (ranX, 2.8f,0.0f);

            transform.localScale = new Vector3(transform.localScale.x * scaleFactor, transform.localScale.y * scaleFactor, transform.localScale.z);
            ampX *= ampXFactor;
            omegaX *= omegaXFactor;
        }
    }
}
