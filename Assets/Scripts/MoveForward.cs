using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    //deklaracje danych wykorzystywanych w skrypcie
    public float speed;
    public GameObject gameManager;
    GameManager gamemanager;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager"); //pobranie obiektu gameManagera z sktyprami
        gamemanager = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() //poruszanie siê obiektów do przodu
    {
        if (gamemanager.isGameActive == true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }
}
