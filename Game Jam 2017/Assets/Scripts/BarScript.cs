using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

    private float fillAmount;

    [SerializeField]
    private Image content;

    private bool drainMeter = true;

    public float drainAmount = 0.0001f;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (drainMeter)
        {
            Deplete();
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
        content.fillAmount -= drainAmount;
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
}
