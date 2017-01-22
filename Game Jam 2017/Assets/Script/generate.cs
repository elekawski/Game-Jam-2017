using UnityEngine;
using System.Collections;

public class generate : MonoBehaviour {
    
    public GameObject[] sideWalkGO;
    private SpriteRenderer[] spriteRenderer;
    int array;
    private int midTile;
    private int leftTile;
    private int rightTile;

    public Sprite city1;
    public Sprite city2;
    public Sprite city3;

    public float[] GOPos;

    //public SpriteRenderer[] renderer;

    // Use this for initialization
    void Start () {

        //sideWalkTile = new int;
        array = 3;
        spriteRenderer = new SpriteRenderer[array];
        GOPos = new float[array];

        midTile = 1;
        leftTile = midTile - 1;
        rightTile = midTile + 1;


        

        for (int i = 0; i < array; i++)
        {
            int sideWalkTileSprites = Random.Range(0, 3);

            spriteRenderer[i] = sideWalkGO[i].GetComponent<SpriteRenderer>();

            if(sideWalkTileSprites == 0)
            {
                spriteRenderer[i].sprite = city1;
            }
            else if (sideWalkTileSprites == 1)
            {
                spriteRenderer[i].sprite = city2;
            }
            else
            {
                spriteRenderer[i].sprite = city3;
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < array; i++)
        {
            GOPos[i] = sideWalkGO[i].transform.position.x;

        }

        if(sideWalkGO[leftTile].transform.position.x < -36)
        {
            sideWalkGO[leftTile].transform.position += new Vector3(54.0f,0.0f,0.0f);
            
            midTile++;

            if (midTile > 2)
                midTile = 0;
            else if (midTile < 0)
                midTile = 2;

            leftTile = midTile - 1;
            if (leftTile < 0)
                leftTile = 2;
            else if(leftTile > 2)
                leftTile = 0;


            rightTile = midTile + 1;
            if (rightTile > 2)
                rightTile = 0;
            else if (rightTile < 0)
                rightTile = 2;



            int sideWalkTileSprites = Random.Range(0, 3);

            

            if (sideWalkTileSprites == 0)
            {
                spriteRenderer[rightTile].sprite = city1;
            }
            else if (sideWalkTileSprites == 1)
            {
                spriteRenderer[rightTile].sprite = city2;
            }
            else
            {
                spriteRenderer[rightTile].sprite = city3;
            }

        }
             
    }
}
