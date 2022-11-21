using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LeaderBoardBehav : MonoBehaviour
{
    [SerializeField] List<CuyBehav> players;
    [SerializeField] List<GameObject> textPos = new List<GameObject>();
    [SerializeField] GameObject leaderUpdater, leaderBoard, positionPrefab;

    public int currentTrack;

    private void Awake()
    {
        StartCoroutine(SetPositionText());
    }
    private void Update()
    {
        UpdateLeaderBoard();
    }

    public void UpdateLeaderBoard()
    {
        if (currentTrack == 0)
        {
            CuyBehav tempPlayer;
            for (int i = 0; i < players.Count; i++)
            {
                for (int j = 0; j < players.Count - 1; j++)
                {
                    if (players[j].magnitude < players[j + 1].magnitude)
                    {
                        tempPlayer = players[j + 1];
                        players[j + 1] = players[j];
                        players[j] = tempPlayer;
                    }
                }
                textPos[i].GetComponent<TMP_Text>().text = ((i + 1) + ": " + players[i].name);
            }
        }
        else if (currentTrack == 1)
        {
            CuyBehav tempPlayer;
            for (int i = 0; i < players.Count; i++)
            {
                for (int j = 0; j < players.Count - 1; j++)
                {
                    if (players[j].magnitude > players[j + 1].magnitude)
                    {
                        tempPlayer = players[j + 1];
                        players[j + 1] = players[j];
                        players[j] = tempPlayer;
                    }
                }
                textPos[i].GetComponent<TMP_Text>().text = ((i + 1) + ": " + players[i].name);
            }
        }
        else if (currentTrack == 2)
        {
            CuyBehav tempPlayer;
            for (int i = 0; i < players.Count; i++)
            {
                for (int j = 0; j < players.Count - 1; j++)
                {
                    if (players[j].magnitude < players[j + 1].magnitude)
                    {
                        tempPlayer = players[j + 1];
                        players[j + 1] = players[j];
                        players[j] = tempPlayer;
                    }
                }
                textPos[i].GetComponent<TMP_Text>().text = ((i + 1) + ": " + players[i].name);
            }
        }
    }

    IEnumerator SetPositionText()
    {
        for (int i = 0; i < players.Count; i++)
        {
            GameObject indexPos = Instantiate(positionPrefab, leaderBoard.transform);
            indexPos.GetComponent<TMP_Text>().text = ((i + 1) + ": " + players[i].name);
            textPos.Add(indexPos);

            print("c");
        }
        yield return new WaitForSeconds(2f);
    }

    public void AddTrack()
    {
        currentTrack++;
    }
}
