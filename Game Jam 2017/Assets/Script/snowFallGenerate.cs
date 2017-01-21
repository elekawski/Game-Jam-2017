﻿using UnityEngine;
using System.Collections;

public class snowFallGenerate : MonoBehaviour {

    public GameObject snowPrefab;
    //2.8
    //5.5
    //-6.5

    public float timer;
    private float timerCur;

    public int startingNum;

    // Use this for initialization
    void Start () {

        timerCur = timer;

        for (int i = 0; i < startingNum; i++)
        {
            float ranX = Random.Range(-5.5f, 5.5f);
            float ranY = Random.Range(-5.5f, 2.8f);

            Instantiate(snowPrefab, new Vector3(ranX, ranY, 0.0f), Quaternion.identity);
        }
        
        


    }
	
	// Update is called once per frame
	void Update () {

        timerCur -= Time.deltaTime;

        if(timerCur < 0.0f)
        {
            float ranX = Random.Range(-5.5f, 5.5f);

            Instantiate(snowPrefab, new Vector3(ranX, 2.8f, 0.0f), Quaternion.identity);

            timerCur = timer;
        }



    }
}