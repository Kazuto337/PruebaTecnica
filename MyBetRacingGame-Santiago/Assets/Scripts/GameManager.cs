using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject finishLine , sceneController , popUp;
    [SerializeField] TMP_Text winnerText;
    [SerializeField] List<CuyBehav> players;
    [SerializeField] LeaderBoardBehav leaderBoardBehav;

    static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            return _instance;
        }        
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else _instance = this;
    }

    public void StartGame()
    {
        foreach (CuyBehav item in players)
        {
            item.canMove = true;
        }
    }

    public void RestartGame()
    {
        sceneController.GetComponent<SceneController>().ChangeScene(1);
    }

    public void ActivateFinishLine()
    {
        finishLine.SetActive(true);
    }

    public void FinishRace(string winner)
    {
        foreach (CuyBehav item in players)
        {
            item.canMove = false;
        }
        winnerText.text = winner;
        popUp.SetActive(true);
    }
    public void AddTrack()
    {
        leaderBoardBehav.currentTrack++;
    }

}
