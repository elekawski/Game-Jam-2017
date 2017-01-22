using UnityEngine;
using System.Collections;

public class generate : MonoBehaviour
{

    public GameObject[] sideWalkGO;
    private SpriteRenderer[] spriteRenderer;
    int skylineArray;
    private int midTile;
    private int leftTile;
    private int rightTile;

    public Sprite city1;
    public Sprite city2;
    public Sprite city3;

    public float[] GOPos;

    public GameObject[] buildingList;
    private SpriteRenderer[] buildingRenderer;
    int buildingArray;
    public Sprite building1;
    public Sprite building2;
    public Sprite building3;
    public Sprite building4;
    public Sprite building5;
    public Sprite building6;

    public float[] buildingPos;

    public Sprite coffeeShop;

    //public SpriteRenderer[] renderer;

    // Use this for initialization
    void Start()
    {

        //sideWalkTile = new int;
        skylineArray = 3;
        spriteRenderer = new SpriteRenderer[skylineArray];
        GOPos = new float[skylineArray];

        midTile = 1;
        leftTile = midTile - 1;
        rightTile = midTile + 1;

        for (int i = 0; i < skylineArray; i++)
        {
            int sideWalkTileSprites = Random.Range(0, 3);

            spriteRenderer[i] = sideWalkGO[i].GetComponent<SpriteRenderer>();

            if (sideWalkTileSprites == 0)
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

        buildingArray = 6;
        buildingRenderer = new SpriteRenderer[buildingArray];
        buildingPos = new float[buildingArray];

        for (int i = 0; i < buildingArray; i++)
        {
            int buildingSprites = Random.Range(0, 6);

            buildingRenderer[i] = buildingList[i].GetComponent<SpriteRenderer>();

            if (buildingSprites == 0)
            {
                spriteRenderer[i].sprite = building1;
            }
            else if (buildingSprites == 1)
            {
                spriteRenderer[i].sprite = building2;
            }
            else if (buildingSprites == 2)
            {
                spriteRenderer[i].sprite = building3;
            }
            else if (buildingSprites == 3)
            {
                spriteRenderer[i].sprite = building4;
            }
            else if (buildingSprites == 4)
            {
                spriteRenderer[i].sprite = building5;
            }
            else
            {
                spriteRenderer[i].sprite = building6;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < skylineArray; i++)
        {
            GOPos[i] = sideWalkGO[i].transform.position.x;

        }

        if (sideWalkGO[leftTile].transform.position.x < -36)
        {
            sideWalkGO[leftTile].transform.position += new Vector3(54.0f, 0.0f, 0.0f);

            midTile++;

            if (midTile > 2)
                midTile = 0;
            else if (midTile < 0)
                midTile = 2;

            leftTile = midTile - 1;
            if (leftTile < 0)
                leftTile = 2;
            else if (leftTile > 2)
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

        for (int i = 0; i < buildingArray; i++)
        {
            buildingPos[i] = buildingList[i].transform.position.x;
        }

        if (buildingList[0].transform.position.x < -36)
        {
            buildingList[0].transform.position += new Vector3(25.0f, 0.0f, 0.0f);

            int nextBuilding = Random.Range(0, 3);

            if (nextBuilding == 0)
            {
                spriteRenderer[0].sprite = building1;
            }
            else if (nextBuilding == 1)
            {
                spriteRenderer[0].sprite = building2;
            }
            else if (nextBuilding == 2)
            {
                spriteRenderer[0].sprite = building3;
            }
            else if (nextBuilding == 3)
            {
                spriteRenderer[0].sprite = building4;
            }
            else if (nextBuilding == 4)
            {
                spriteRenderer[0].sprite = building5;
            }
            else
            {
                spriteRenderer[0].sprite = building6;
            }
        }
    }
}
