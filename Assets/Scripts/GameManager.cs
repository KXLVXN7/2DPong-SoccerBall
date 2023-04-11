using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject P1Wins;
    [SerializeField] private GameObject P2Wins;
    public int PlayerScoreL = 0;
    public int PlayerScoreR = 0;



    //Buat UI Text
    public TMP_Text txtPlayerScoreL;
    public TMP_Text txtPlayerScoreR;

    public static GameManager instance;
    public SceneManager finish;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //Mengisikan nilai integer PlayerScore ke UI
        txtPlayerScoreL.text = PlayerScoreL.ToString();
        txtPlayerScoreR.text = PlayerScoreR.ToString();
    }
    public void Finish()
    {
        Debug.Log("FINISH GAME!!!");
        SceneManager.LoadScene("Menu");
    }

    //Method penyeleksi untuk menambah score
    public void Score(string wallName)
    {
        if (wallName == "Gawang_L")
        {
            PlayerScoreR = PlayerScoreR + 1; //Menambah score
            txtPlayerScoreR.text = PlayerScoreR.ToString(); //Mengisikan nilai integer PlayerScore ke UI
            ScoreCheck();
        }
        else
        {
            PlayerScoreL = PlayerScoreL + 1;
            txtPlayerScoreL.text = PlayerScoreL.ToString();
             ScoreCheck();

        }
    }
    public void ScoreCheck()
    {
        if (PlayerScoreL == 10)
        {
            /*panelWin.SetActive(true);*/
            /*playerWin.text = "Player L Win !!!";*/
            Debug.Log("Player 1 FINISH GAME!!!");
            P1Wins.SetActive(true);
            Invoke("Finish", 6f);
            
            //Debug.Log("playerL win");
            //this.gameObject.SendMessage("ChangeScene","MainMenu");
        }
        else if (PlayerScoreR == 10)
        {
            Debug.Log("Player 2 FINISH GAME!!!");
            P2Wins.SetActive(true);
            Invoke("Finish", 6f);

        }
    }

}