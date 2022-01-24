using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO.Ports;

public class PlayerControler : MonoBehaviour
{
    //deklaracje danych wykorzystywanych w skrypcie
    private float speed = 5.0f; 
    private float turnSpeed = 15.0f;
    private float horizontalInput;
    private float forwardInput;
    public GameObject player;
    public int score;
    public int life;
    SerialPort arduino;
    string RectextL;
    string RectextR;
    int startstrR;
    int startstrL;
    int endstrR;
    int endstrL;
   [SerializeField] float curlenghtR;
   [SerializeField] float curlenghtL;
    int substrstartR;
    int substrlenghtR;
    int substrstartL;
    int substrlenghtL;
  
    void Start()
    {
        score = 0;
        life = 3;
     //   if (isArduino)
     //   {
            arduino = new SerialPort("COM3", 9600);//pobranie danych z arduino
            arduino.Open();
     //   }
        
    }

    
    void Update() 
    {
        horizontalInput = Input.GetAxis("Horizontal"); 
        forwardInput = Input.GetAxis("Vertical");
        

        if (transform.position.x > 10 ) //granice obszaru poruszania siê
        {
            transform.position = new Vector3(10, 0, -2);
        }
        else if(transform.position.x < -10)
        {
            transform.position = new Vector3(-10, 0, -2);
        }
        //else if (!isArduino) //funkcja mo¿liwa do w³¹czenia aby przestawiæ na sterowanie klawiatur¹
        //{
        //                                                                              
        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
           
        //}
        else //poruszanie siê postaci prawo/lewo
        {
            
            if (DataFromArduinoL() < 50)
            {                                                                            
                transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * -1f);
            }
           if (DataFromArduinoR() < 50)
            {
                transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * 1f);
            }// y axis
        }
      
    }
    void OnCollisionEnter(Collision col) //zdarzenie podczas kolizji
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
    float DataFromArduinoR() //zebranie danych z prawego czujnika
    {
        RectextR = RectextR + arduino.ReadLine();
        startstrR = RectextR.LastIndexOf("R");
        endstrR = RectextR.LastIndexOf("b");
        if (startstrR > 0 && endstrR > 0 && endstrR > startstrR)
        {
            substrstartR = startstrR + 1;
            substrlenghtR = endstrR - (startstrR + 1);
            curlenghtR = int.Parse(RectextR.Substring(substrstartR, substrlenghtR));
            RectextR = "";

        }

        return curlenghtR;
    }
    float DataFromArduinoL() //zebranie danych z lewego czujnika
    {
        RectextL = RectextL + arduino.ReadLine();
        startstrL = RectextL.LastIndexOf("L");
        endstrL = RectextL.LastIndexOf("a");

        if (startstrL > 0 && endstrL > 0 && endstrL > startstrL)
        {
            substrstartL = startstrL + 1;
            substrlenghtL = endstrL - (startstrL + 1);
            curlenghtL = int.Parse(RectextL.Substring(substrstartL, substrlenghtL));
            RectextL = "";
        }
        return curlenghtL;
    }
   
}


