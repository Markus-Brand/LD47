// GENERATED AUTOMATICALLY FROM 'Assets/GameInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputs"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""02bd1582-28b5-493c-9be0-be795fac2225"",
            ""actions"": [
                {
                    ""name"": ""Rewind"",
                    ""type"": ""Button"",
                    ""id"": ""bf6a70a6-2d60-4d95-9e75-0f5cfeb87389"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""North"",
                    ""type"": ""Button"",
                    ""id"": ""c5f6b579-f26a-4b89-bb0b-8a1970606ded"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""East"",
                    ""type"": ""Button"",
                    ""id"": ""b62c7edc-ef5e-44db-9976-a236d47330b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""South"",
                    ""type"": ""Button"",
                    ""id"": ""be64db2f-ac7e-4706-a8b0-2b6e24e07868"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""West"",
                    ""type"": ""Button"",
                    ""id"": ""4ddc772d-cebf-4cb1-953a-42ec8b875c5a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""8f4b5050-7a36-4acd-a773-e11a1423d0fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e89da407-177f-4608-91cc-1ce158832a8e"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rewind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aff0dc6e-d3f3-4068-b3d0-02a3c90d38bc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""North"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da15d750-e835-46b3-aed0-d836d6b8f4a9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""North"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fc03b94-e143-47a6-afa3-1dc583d145a5"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""East"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e80903b1-f43c-4b41-941b-11b4c82cb47d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""East"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42b1f6d0-63e4-49fb-8995-c9058f7eff85"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""South"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8a44e93-bdbd-4719-8cb4-5580032f402a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""South"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f3469cc-0b0f-4b9d-81dc-b34e14d12886"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""West"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56978b11-ea67-4a73-bc59-0255ac0fe55c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""West"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47c05a49-d649-4299-93ee-4b0251640cef"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
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
        m_Gameplay_Rewind = m_Gameplay.FindAction("Rewind", throwIfNotFound: true);
        m_Gameplay_North = m_Gameplay.FindAction("North", throwIfNotFound: true);
        m_Gameplay_East = m_Gameplay.FindAction("East", throwIfNotFound: true);
        m_Gameplay_South = m_Gameplay.FindAction("South", throwIfNotFound: true);
        m_Gameplay_West = m_Gameplay.FindAction("West", throwIfNotFound: true);
        m_Gameplay_Escape = m_Gameplay.FindAction("Escape", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Rewind;
    private readonly InputAction m_Gameplay_North;
    private readonly InputAction m_Gameplay_East;
    private readonly InputAction m_Gameplay_South;
    private readonly InputAction m_Gameplay_West;
    private readonly InputAction m_Gameplay_Escape;
    public struct GameplayActions
    {
        private @GameInputs m_Wrapper;
        public GameplayActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rewind => m_Wrapper.m_Gameplay_Rewind;
        public InputAction @North => m_Wrapper.m_Gameplay_North;
        public InputAction @East => m_Wrapper.m_Gameplay_East;
        public InputAction @South => m_Wrapper.m_Gameplay_South;
        public InputAction @West => m_Wrapper.m_Gameplay_West;
        public InputAction @Escape => m_Wrapper.m_Gameplay_Escape;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Rewind.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRewind;
                @Rewind.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRewind;
                @Rewind.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRewind;
                @North.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNorth;
                @North.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNorth;
                @North.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNorth;
                @East.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEast;
                @East.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEast;
                @East.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEast;
                @South.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSouth;
                @South.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSouth;
                @South.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSouth;
                @West.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWest;
                @West.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWest;
                @West.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWest;
                @Escape.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEscape;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rewind.started += instance.OnRewind;
                @Rewind.performed += instance.OnRewind;
                @Rewind.canceled += instance.OnRewind;
                @North.started += instance.OnNorth;
                @North.performed += instance.OnNorth;
                @North.canceled += instance.OnNorth;
                @East.started += instance.OnEast;
                @East.performed += instance.OnEast;
                @East.canceled += instance.OnEast;
                @South.started += instance.OnSouth;
                @South.performed += instance.OnSouth;
                @South.canceled += instance.OnSouth;
                @West.started += instance.OnWest;
                @West.performed += instance.OnWest;
                @West.canceled += instance.OnWest;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnRewind(InputAction.CallbackContext context);
        void OnNorth(InputAction.CallbackContext context);
        void OnEast(InputAction.CallbackContext context);
        void OnSouth(InputAction.CallbackContext context);
        void OnWest(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
    }
}
