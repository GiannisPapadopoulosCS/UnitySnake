using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager_Script : MonoBehaviour
{
    [SerializeField]
    private GameObject tile;
    [SerializeField]
    private GameObject apple;

    private GameObject appleReference;

    //[SerializeField]
    private static int rows = 5;
    //[SerializeField]
    private static int columns = 5;

    GameObject[,] grid = new GameObject[rows, columns];

    // Start is called before the first frame update
    void Start()
    {
        InitialiseGrid();
    }

    void InitialiseGrid()
    {
        for (int row = 0; row<rows; row++)
            {for (int column = 0; column < columns; column++)
            {
                grid[row,column] = Instantiate(tile, new Vector3(row,column,1), Quaternion.identity, transform);
            }
        }
        spawnApple();
    }

    void spawnApple()
    {
        int x, y = 0;

        x = Random.Range(0, columns - 1);
        y = Random.Range(0, rows - 1);

        appleReference = Instantiate(apple, new Vector3(x, y, 1), Quaternion.identity, transform);
        grid[x, y].GetComponent<GridTile_Script>().haveApple = true;
        //TODO check if there is snake on the tile I am trying to spawn the apple
    }

    public void checkForApple(int x, int y)
    {
        if (grid[x,y].GetComponent<GridTile_Script>().haveApple == true)
        {
            Destroy(appleReference);
            grid[x, y].GetComponent<GridTile_Script>().haveApple = false;
            spawnApple();
        }
    }
}
