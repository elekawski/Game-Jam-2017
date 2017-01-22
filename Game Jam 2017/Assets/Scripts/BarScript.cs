using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class BarScript : MonoBehaviour {

    private float fillAmount;

    [SerializeField]
    private Image content;

    private bool drainMeter = true;

    public float drainAmount = 0.0000001f;

    public GameObject player;

    private GameObject GOScreen;

    private GameObject sfHandler;
    private float speedMod;

    // Use this for initialization
    void Start ()
    {
        GOScreen = GameObject.FindGameObjectWithTag("gameOver");
        sfHandler = GameObject.FindGameObjectWithTag("snowFallHandler");
        GOScreen.transform.position = new Vector3(0.25f, 1000, -5);

    }
	
	// Update is called once per frame
	void Update ()
    {
        speedMod = sfHandler.GetComponent<snowFallGenerate>().speedMotifier;

        if (drainMeter)
        {
            Deplete();
        }

        if(content.fillAmount <= 0)
        {
            player = GameObject.FindWithTag("Player");
            Destroy(player.GetComponent<BoxCollider2D>());
            player.GetComponent<Renderer>().enabled = false;
            Destroy(player);
            GOScreen.transform.position = new Vector3(0.25f, -0.5f, -5);

        }
    }

    private void HandleBar()
    {
        content.fillAmount = fillAmount;
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    private void Deplete()
    {
        content.fillAmount -= (drainAmount * speedMod);
    }

    IEnumerator Increase(float increaseAmount)
    {
        drainMeter = false;

        content.fillAmount += increaseAmount;

        yield return new WaitForSeconds(2);

        drainMeter = true;
    }

    public void WarmUp(float increaseAmount)
    {
        StartCoroutine(Increase(increaseAmount));
    }
    public void CoolDown(float decreaseAmount)
    {
        content.fillAmount -= decreaseAmount;

    }
}
