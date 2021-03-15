using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
	private GameScreen gameScreen;
    private AudioManager audioManager;

    private int player_1_points = 0;
    private int player_2_points = 0;
    private bool sounds = true;
    public bool Play_Sounds 
    {
        set
        {
            sounds = value;
        } 
    }


    public event EventHandler Victory;
    public event EventHandler ResetGame;

    public static GameManager Instance
	{
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public void ChangeScene(int scene_build_index)
    {
        SceneManager.LoadScene(scene_build_index);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        gameScreen = FindObjectOfType<GameScreen>();
        audioManager = FindObjectOfType<AudioManager>();
        player_1_points = 0;
        player_2_points = 0;
        ResetGame?.Invoke(this, EventArgs.Empty);
    }

    public void GivePoint(bool is_player_1_point)
    {
        if(is_player_1_point)
        {
            player_1_points++;
        }
        else
        {
            player_2_points++;
        }

        gameScreen.UpdatePoints(player_1_points, player_2_points);
        VerifyVictory();
    }

    public void PlaySound()
    {
        if(sounds)
            audioManager.Play("Pong");  
    }

    public void VerifyVictory()
    {
        if(player_1_points >= 5)
        {
            gameScreen.ShowWinner(1);
            Victory?.Invoke(this, EventArgs.Empty);
        }
        else if(player_2_points >= 5)
        {
            gameScreen.ShowWinner(2);
            Victory?.Invoke(this, EventArgs.Empty);
        }
    }
}
