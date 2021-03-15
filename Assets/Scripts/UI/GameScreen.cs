using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    [SerializeField]
    private Text player_1_points;

    [SerializeField]
    private Text player_2_points;
    [SerializeField]
    private Text winner_text;
    [SerializeField]
    private GameObject show_winner;

    public void UpdatePoints(int player_1, int player_2)
    {
        player_1_points.text = player_1.ToString();
        player_2_points.text = player_2.ToString();
    }

    public void ShowWinner(int winner)
    {
        show_winner.SetActive(true);
        winner_text.text = "Congratulations player " + winner;
    }

    public void ResetGame()
    {
        show_winner.SetActive(false);
        UpdatePoints(0, 0);
        GameManager.Instance.StartGame();
    }

    public void ExitGame()
    {
        GameManager.Instance.ChangeScene(1);
    }
}