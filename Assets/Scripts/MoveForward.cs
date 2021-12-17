using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    public GameObject gameManager;
    GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gamemanager = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gamemanager.isGameActive == true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }
}
