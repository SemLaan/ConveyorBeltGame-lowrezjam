using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuControls : MonoBehaviour
{

    private Controls controls;
    [SerializeField] private MenuButton[] buttons = null;
    private SpriteRenderer[] spriteRenderers;
    private int currentButtonIndex = 0;
    private bool downPressedLastFrame = false, upPressedLastFrame = false;



    private void Awake()
    {

        controls = new Controls();
        controls.Enable();

        spriteRenderers = new SpriteRenderer[buttons.Length];

        for (int i = 0; i < buttons.Length; i++)
        {

            spriteRenderers[i] = buttons[i].GetComponent<SpriteRenderer>();
        }

        HighlightButton();
    }



    private void Update()
    {

        if (controls.Gameplay.ConveyorControl.ReadValue<float>() == 1)
            buttons[currentButtonIndex].ButtonAction();

        if (!upPressedLastFrame && controls.Gameplay.Up.ReadValue<float>() == 1)
        {

            currentButtonIndex--;
            if (currentButtonIndex < 0)
                currentButtonIndex = 0;

            HighlightButton();
        }

        if (!downPressedLastFrame && controls.Gameplay.Down.ReadValue<float>() == 1)
        {

            currentButtonIndex++;
            if (currentButtonIndex == buttons.Length)
                currentButtonIndex = buttons.Length - 1;

            HighlightButton();
        }


        upPressedLastFrame = controls.Gameplay.Up.ReadValue<float>() == 1;
        downPressedLastFrame = controls.Gameplay.Down.ReadValue<float>() == 1;
    }


    private void HighlightButton()
    {

        foreach (SpriteRenderer button in spriteRenderers)
        {

            button.color = Color.HSVToRGB(0, 0, 0.8f);
        }

        spriteRenderers[currentButtonIndex].color = Color.HSVToRGB(0, 0, 1);
    }
}
