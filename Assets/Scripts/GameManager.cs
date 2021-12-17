using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
    
{
    [SerializeField] private bool m_GameOver = false;
    [SerializeField] private bool m_WinGame = false;
    [SerializeField] public bool isGameActive = true;
    public Text Score;
    public Text Life;
    public GameObject GameOverText;
    public GameObject GameWinText;
    public GameObject player;
    PlayerControler playerControler;
    [SerializeField] private int m_Points;
    [SerializeField] private int l_Points;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Mikolaj");
        playerControler = player.GetComponent<PlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        AddPoint(playerControler.score);
        LifePoint(playerControler.life);
        if (m_Points == 10)
        {
            GameWin();
        }
        else if(l_Points == 0)
        {
            GameOver();
        }

    }
    public void GameOver()
    {
        isGameActive = false;
        m_GameOver = true;
        GameOverText.SetActive(true);
        
    }
    public void GameWin()
    {
        isGameActive = false;
        m_WinGame = true;
        GameWinText.SetActive(true);
    }
    void AddPoint(int point)
    {
       m_Points = point;
       Score.text = $"Score : {m_Points}";
    }
    void LifePoint(int life)
    {
        l_Points = life;
        Life.text = $"Life : {l_Points}";
    }
}
