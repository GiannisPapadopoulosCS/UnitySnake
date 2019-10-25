using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Script : MonoBehaviour
{

    [SerializeField]
    private GameObject snakeHead;
    [SerializeField]
    private GameObject gridManager;

    private int score = 0;
    private SnakeHead_Script snakeHeadScript;
    
    // Start is called before the first frame update
    void Start()
    {
        snakeHeadScript = snakeHead.GetComponent<SnakeHead_Script>();
        //StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //IEnumerator Timer()
    //{
    //    yield return new WaitForSecondsRealtime(2);
    //}
}
