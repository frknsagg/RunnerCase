using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

using Button = UnityEngine.UI.Button;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject wall;
    
    [SerializeField] public TextMeshProUGUI  playerRanking;
    [SerializeField] public Transform  Boy;
    public bool isGameStart = false;
    public bool isPlayerFinishedGame = false;
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void GameStartButton()
    {
        animator.SetBool("isGameStart",true);
        playButton.gameObject.SetActive(false);
        isGameStart = true;
        var a = GameObject.FindGameObjectsWithTag("Opponent");
        for (int i = 0; i < a.Length; i++)
        {
            
            a[i].GetComponent<OpponentMovement>().OpponentGameStart();
        }

    }

    private void LateUpdate()
    {
        int rank = Enumerable.Reverse(GameManager.instance.players).ToList().IndexOf(Boy.transform) + 1;
        playerRanking.text = isGameStart
            ? "Your Rank is " + rank +
              RankingType(rank)
            : "Game did not start";

    }

    public void RestartButton()
    {
        restartButton.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void FinishedGame()
    {
        restartButton.SetActive(true);
    }

    private string RankingType(int rank)
    {
        switch (rank)
        {
            case 1:
                return "st";
            case 2:
                return "nd";
            case 3:
                return "rd";
            default:
                return "th";
        }
    }

    public void GameFinished()
    {
        wall.SetActive(false);
    }

    public void ActiveRestartButton()
    {
        restartButton.SetActive(true);
    }


}
