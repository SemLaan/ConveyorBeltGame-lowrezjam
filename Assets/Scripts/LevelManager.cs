using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Controls controls;
    private Player player;

    private void Awake()
    {
        controls = new Controls();
        player = new Player();
        controls.Enable();
    }

    private void FixedUpdate()
    {
        bool startGame = controls.Gameplay.ConveyorControl.ReadValue<float>() == 1;
        player.gameStart = startGame;
    }
}
