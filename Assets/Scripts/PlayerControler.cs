using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{
    private float speed = 5.0f; // we can see this variable (because it is public) in unity
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;
    public GameObject player;
    public int score;
    public int life;
    //static var score : int = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        life = 3;
    }

    // Update is called once per frame
    void Update() // update is called 50-60 times in a second, so it will move 60m per second
    {
        horizontalInput = Input.GetAxis("Horizontal"); // nazwa jej jest w edit->ProjectSettings->InputManager
        forwardInput = Input.GetAxis("Vertical");

        if (transform.position.x > 10 )
        {
            transform.position = new Vector3(10, 0, -2);
        }
        else if(transform.position.x < -10)
        {
            transform.position = new Vector3(-10, 0, -2);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput); // now were moving 20m per s
                                                                                          // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput); zamieniam na:
            transform.Translate(Vector3.right* Time.deltaTime * turnSpeed * horizontalInput);  // y axis
        }
        //constantly checking per frame
        //we'll move vehicle forward
        // transform.Translate(0, 0, 1); // transform to sekcja w Inspectorze Unity
        // oznacza to samo, co:
        //transform.Translate(Vector3.forward * Time.deltaTime); // now were moving 1m per s
       // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput); // now were moving 20m per s
        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput); zamieniam na:
       // transform.Translate(Vector3.right* Time.deltaTime * turnSpeed * horizontalInput);  // y axis
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("prezent"))
        {
            Destroy(col.gameObject);
            score++;
        }
        else if (col.gameObject.CompareTag("enemy"))
        {
            Destroy(col.gameObject);
            life--;
        }
    }
}


