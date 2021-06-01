using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tiles;

    public GameObject currentTile;

    Stack<GameObject> forwardTilePool = new Stack<GameObject>();//created stack
    Stack<GameObject> leftTilePool = new Stack<GameObject>();

    private static TileManager instance;

    public static TileManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileManager>();
            }
            return instance;
        }

    }

    // Start is called before the first frame update
    void Start()
    {

        // CreateTiles(5);


    }

    // Update is called once per frame
    void Update()
    {

    }
    void CreateTiles(int value)//to create the pool of tiles
    {
        for (int i = 0; i < value; i++)
        {
            forwardTilePool.Push(Instantiate(tiles[0]));
            leftTilePool.Push(Instantiate(tiles[1]));
            forwardTilePool.Peek().SetActive(false);
            leftTilePool.Peek().SetActive(false);
            forwardTilePool.Peek().name = "ForwardTile";
            leftTilePool.Peek().name = "LeftTile";
        }

    }
    public void AddForwardTilePool(GameObject tempObj)
    {
        forwardTilePool.Push(tempObj);
        forwardTilePool.Peek().SetActive(false);
    }
    public void AddLeftTilePool(GameObject tempObj)
    {
        leftTilePool.Push(tempObj);
        leftTilePool.Peek().SetActive(false);
    }


    public void SpawnTile()
    {
        if (forwardTilePool.Count == 0 || leftTilePool.Count == 0)
        {
            CreateTiles(10);
        }
        int index = Random.Range(0, 2);
        if (index == 0)
        {
            GameObject tempTile = forwardTilePool.Pop();
            tempTile.SetActive(true);
            tempTile.transform.position = currentTile.transform.GetChild(0).position;
            currentTile = tempTile;
        }
        else if (index == 1)
        {
            GameObject temp = leftTilePool.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(1).position;
            currentTile = temp;
        }

        int pickupCoin = Random.Range(0, 10);
        if(pickupCoin==Random.Range(0,10))
        {
            currentTile.transform.GetChild(3).gameObject.SetActive(true);
        }

    }
}