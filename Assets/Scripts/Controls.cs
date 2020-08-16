// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""b1d7e8a2-e77c-49be-a4fc-f806431e89ca"",
            ""actions"": [
                {
                    ""name"": ""ConveyorControl"",
                    ""type"": ""Value"",
                    ""id"": ""4204cb42-2800-4a11-adc9-e08434940e4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartLevel"",
                    ""type"": ""Value"",
                    ""id"": ""3d412216-5135-4af7-a809-d2a5317627f4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""a5fd8611-87fc-43b9-a829-946ac63418d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseLevel"",
                    ""type"": ""Button"",
                    ""id"": ""52b85fc4-26ab-4e2e-ada6-afead634d100"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""76f719c9-0790-452c-aa9b-6fcf2eaf648b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""73216653-c4c8-4012-abeb-574bbd026925"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConveyorControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""986ba97d-6cf0-4604-ac91-df8f8426f772"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""002f8b4c-a507-48b7-9931-a69acf689931"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad324ce9-6068-4694-9559-cd44690ec213"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1bdacef-cbf6-41ba-bbfb-9eaf675df3ea"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_ConveyorControl = m_Gameplay.FindAction("ConveyorControl", throwIfNotFound: true);
        m_Gameplay_StartLevel = m_Gameplay.FindAction("StartLevel", throwIfNotFound: true);
        m_Gameplay_Up = m_Gameplay.FindAction("Up", throwIfNotFound: true);
        m_Gameplay_PauseLevel = m_Gameplay.FindAction("PauseLevel", throwIfNotFound: true);
        m_Gameplay_Down = m_Gameplay.FindAction("Down", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_ConveyorControl;
    private readonly InputAction m_Gameplay_StartLevel;
    private readonly InputAction m_Gameplay_Up;
    private readonly InputAction m_Gameplay_PauseLevel;
    private readonly InputAction m_Gameplay_Down;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ConveyorControl => m_Wrapper.m_Gameplay_ConveyorControl;
        public InputAction @StartLevel => m_Wrapper.m_Gameplay_StartLevel;
        public InputAction @Up => m_Wrapper.m_Gameplay_Up;
        public InputAction @PauseLevel => m_Wrapper.m_Gameplay_PauseLevel;
        public InputAction @Down => m_Wrapper.m_Gameplay_Down;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @ConveyorControl.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnConveyorControl;
                @ConveyorControl.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnConveyorControl;
                @ConveyorControl.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnConveyorControl;
                @StartLevel.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStartLevel;
                @StartLevel.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStartLevel;
                @StartLevel.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStartLevel;
                @Up.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @PauseLevel.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPauseLevel;
                @PauseLevel.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPauseLevel;
                @PauseLevel.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPauseLevel;
                @Down.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ConveyorControl.started += instance.OnConveyorControl;
                @ConveyorControl.performed += instance.OnConveyorControl;
                @ConveyorControl.canceled += instance.OnConveyorControl;
                @StartLevel.started += instance.OnStartLevel;
                @StartLevel.performed += instance.OnStartLevel;
                @StartLevel.canceled += instance.OnStartLevel;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @PauseLevel.started += instance.OnPauseLevel;
                @PauseLevel.performed += instance.OnPauseLevel;
                @PauseLevel.canceled += instance.OnPauseLevel;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnConveyorControl(InputAction.CallbackContext context);
        void OnStartLevel(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnPauseLevel(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
}
