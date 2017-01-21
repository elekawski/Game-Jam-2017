using UnityEngine;
using System.Collections;

public class generate : MonoBehaviour {

    public int[] sideWalkTile;
    public int[] sideWalkTileSprites;
    public GameObject[] sideWalkGO;
    int array;
    int curNum;

    public SpriteRenderer[] renderer;

    // Use this for initialization
    void Start () {

        //sideWalkTile = new int;
        array = 3;
        sideWalkTile = new int[array];
        sideWalkTileSprites = new int[array];
        renderer = new SpriteRenderer[3];

        curNum = 0;

        for(int i = 0; i < array; i++)
        {
            sideWalkTile[i] = curNum;
            sideWalkTileSprites[i] = Random.Range(0, 3);
            renderer[i] = sideWalkGO[i].AddComponent<SpriteRenderer>();
            curNum++;
            //renderer[i].sprite = Resources.Load<Sprite>("img/sidewalk1", typeof(Sprite)) as Sprite;
        }

    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
