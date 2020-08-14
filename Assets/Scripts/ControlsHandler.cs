using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsHandler : MonoBehaviour
{
    private Controls controls;
    private TileGrid tileGrid;

    private void Awake()
    {
        controls = new Controls();
        controls.Enable();
        tileGrid = FindObjectOfType<TileGrid>();
    }

    private void FixedUpdate()
    {
        
        bool conveyorPaused = controls.Gameplay.ConveyorControl.ReadValue<float>() == 1;
        tileGrid.pauseConveyorbelt = conveyorPaused;
    }
}
