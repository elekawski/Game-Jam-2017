using UnityEngine;
using System.Collections;

public class carMovement : MonoBehaviour {

    public Sprite car1Sprite;
    public Sprite car2Sprite;
    public Sprite car3Sprite;

    private Vector3 originalPosition;

    private bool car1B;

    private float carSpeed;

    private GameObject sfHandler;
    private float speedMod;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {

        originalPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();

        int ranNum = Random.Range(0, 3);

        if (ranNum == 0)
        {
            spriteRenderer.sprite = car1Sprite;
        }
        else if (ranNum == 1)
        {
            spriteRenderer.sprite = car2Sprite;
        }
        else
        {
            spriteRenderer.sprite = car3Sprite;
        }

        if (originalPosition[0] > 0.0f)
        {
            car1B = true;
        }
        else if (originalPosition[0] < 0.0f)
        {
            car1B = false;
        }

        carSpeed = Random.Range(5.0f, 10.0f);

        sfHandler = GameObject.FindGameObjectWithTag("snowFallHandler");
    }
	
	// Update is called once per frame
	void Update () {
        speedMod = sfHandler.GetComponent<snowFallGenerate>().speedMotifier;


        if (car1B)
        {
            transform.Translate(Vector3.left * carSpeed * speedMod * Time.deltaTime);

            

            if (transform.position.x < -12)
            {
                transform.position = originalPosition;
                carSpeed = Random.Range(5.0f, 10.0f);

                int ranNum = Random.Range(0, 3);

                if (ranNum == 0)
                {
                    spriteRenderer.sprite = car1Sprite;
                }
                else if (ranNum == 1)
                {
                    spriteRenderer.sprite = car2Sprite;
                }
                else
                {
                    spriteRenderer.sprite = car3Sprite;
                }
            }
        }
        else if (!car1B)
        {
            transform.Translate(Vector3.left * -carSpeed * speedMod * Time.deltaTime);

            if (transform.position.x > 12)
            {
                transform.position = originalPosition;
                carSpeed = Random.Range(5.0f, 10.0f);

                int ranNum = Random.Range(0, 3);

                if (ranNum == 0)
                {
                    spriteRenderer.sprite = car1Sprite;
                }
                else if (ranNum == 1)
                {
                    spriteRenderer.sprite = car2Sprite;
                }
                else
                {
                    spriteRenderer.sprite = car3Sprite;
                }
            }
        }
    }
}
