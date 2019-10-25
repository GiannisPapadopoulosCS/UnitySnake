using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead_Script : MonoBehaviour
{
    [SerializeField]
    private GameObject gridManager;

    private GameObject snakeTail;
    private GameObject nextSnakePart;

    Vector2 currentDirection;
    private float movementCooldown = 0.5f;

    GridManager_Script gridManagerScript;

    void Start()
    {
        currentDirection = Vector2.up;
        gridManagerScript = gridManager.GetComponent<GridManager_Script>();
    }

    void Update()
    {
        //TODO instead of checking if the direction is opposite I should be checking if the tile behind me has snake in it OR make it so I cannot change direction twice in a single cooldown
        if (currentDirection != Vector2.down && Input.GetButtonDown("Up"))
        {
            changeDirection(Vector2.up);
        }
        else if (currentDirection != Vector2.right && Input.GetButtonDown("Left"))
        {
            changeDirection(Vector2.left);

        }
        else if (currentDirection != Vector2.up && Input.GetButtonDown("Down"))
        {
            changeDirection(Vector2.down);

        }
        else if (currentDirection != Vector2.left && Input.GetButtonDown("Right"))
        {
            changeDirection(Vector2.right);
        }

        if (movementCooldown <= 0)
        {
            move();
            movementCooldown = 0.5f;
        }
        movementCooldown -= Time.deltaTime;
    }

    public void move()
    {
        transform.Translate(currentDirection);
        gridManagerScript.checkForApple((int)transform.position.x,(int)transform.position.y);
    }

    void changeDirection(Vector2 direction)
    {
        currentDirection = direction;
    }
}
