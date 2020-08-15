using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Controls controls;
    private Player player;
    public bool pauseGame;

    private void Awake()
    {
        controls = new Controls();
        player = FindObjectOfType<Player>();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    public void Update()
    {
        if(controls.Gameplay.StartLevel.ReadValue<float>() == 1)
        {
            player.gameStart = true;
        }
        if(controls.Gameplay.PauseLevel.ReadValue<float>() == 1)
        {
            if (pauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        print("bitch");
        pauseGame = false;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        print("het werkt");
        pauseGame = true;
    }
}
