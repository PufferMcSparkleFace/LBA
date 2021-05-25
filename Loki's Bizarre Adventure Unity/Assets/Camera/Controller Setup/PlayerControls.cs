// GENERATED AUTOMATICALLY FROM 'Assets/Camera/Controller Setup/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Loki "",
            ""id"": ""405023c1-55b8-40ac-bc02-88e5d32e948c"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""4a6e9b25-6588-4bda-8668-9485a2379047"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch Clone Left"",
                    ""type"": ""Button"",
                    ""id"": ""f80a023f-3bfa-4535-8c70-a865943db58b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch Clone Right"",
                    ""type"": ""Button"",
                    ""id"": ""d24bf461-5e38-4dff-a400-20a19efa294a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch Player Left"",
                    ""type"": ""Button"",
                    ""id"": ""5f8b763f-437d-414a-bf3b-903bf47a766b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch Player Right"",
                    ""type"": ""Button"",
                    ""id"": ""80784c1f-f566-4d9c-b473-9ea3c00303e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tether Baldr"",
                    ""type"": ""Button"",
                    ""id"": ""f1ee40aa-447f-45dd-9133-62b27cfce78a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""1103c942-e571-4fd4-bd18-abb930e44832"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""cf322a99-1c9c-4ea9-866a-021c0d91fbc6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""46eabc9a-1116-4b0b-b0cb-f861ff53256d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump 2"",
                    ""type"": ""Button"",
                    ""id"": ""5c087bdb-f8a7-402d-bd1c-0814ed95d112"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Summon Clone"",
                    ""type"": ""Button"",
                    ""id"": ""d6e54aaa-a919-4d1f-bb71-6205791a364d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""da250830-1d43-4121-a8e8-980b9d6ee73a"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f4b691e-42a1-490d-b31b-15993d2981b0"",
                    ""path"": ""<DualShockGamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Clone Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d418cb1-25f9-4125-8ee7-c6d69cbca34b"",
                    ""path"": ""<DualShockGamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Clone Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c47c6f6b-dd1c-4868-911b-dcbda2c190e8"",
                    ""path"": ""<DualShockGamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Player Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d89f3cd9-86b6-4582-9b12-58458e91c39d"",
                    ""path"": ""<DualShockGamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tether Baldr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb0580b7-e697-43c6-bd3c-a51015132b8a"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""efb87a11-70b0-4bd4-8cb2-b0cec8370d86"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4de435e7-8f3e-4f17-8ba3-cb26b44dc654"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40f86f1c-58e1-4951-923d-42ad24780a03"",
                    ""path"": ""<DualShockGamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Player Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3701bc6-4277-4b7f-ae4f-0f840bcaf1a4"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5b13234-284b-46b8-a8b5-ad60f1636e27"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Summon Clone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Baldr"",
            ""id"": ""6490668a-11c8-46d5-b9be-50a34b552973"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""753f0e6e-f746-465a-958c-2ed7bfb7fded"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""0238b9c5-bac1-4993-a727-000187ead3d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""79e8b184-8e7f-4a19-bd7d-ebee5bc658c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch Player Left"",
                    ""type"": ""Button"",
                    ""id"": ""dacdfea3-7603-41b7-837a-db62275d5efb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch Player Right"",
                    ""type"": ""Button"",
                    ""id"": ""88c6f1a8-2a00-44d8-af5e-acbd0c8ace7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""43293dcb-3984-4d85-b771-d063b5cd8787"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump 2"",
                    ""type"": ""Button"",
                    ""id"": ""eb83d848-713c-4347-9f6a-a4ba1e99c25d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Angle Shield"",
                    ""type"": ""Value"",
                    ""id"": ""66e16191-742d-4e30-8e62-6de5e7278998"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""800a75ff-c4d8-4803-a70b-92ef86b8fd92"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""630e0cfc-ae4b-408f-b248-2a5db84aae8a"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19b95447-cbd9-403f-b5a5-01f4b23f14f9"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b2048e2-55d4-44fd-bb41-437930035976"",
                    ""path"": ""<DualShockGamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Player Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2f361f1-9e2b-4eb1-a71b-2a3936e37e7e"",
                    ""path"": ""<DualShockGamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Player Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0da09fe8-e1d0-4fe4-8a6c-16067ae1b285"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbb9bcb6-75e2-4487-b223-7a3059cb1abf"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42e209e9-569d-483e-96e6-3fb37cfbe069"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Angle Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Loki 
        m_Loki = asset.FindActionMap("Loki ", throwIfNotFound: true);
        m_Loki_Interact = m_Loki.FindAction("Interact", throwIfNotFound: true);
        m_Loki_SwitchCloneLeft = m_Loki.FindAction("Switch Clone Left", throwIfNotFound: true);
        m_Loki_SwitchCloneRight = m_Loki.FindAction("Switch Clone Right", throwIfNotFound: true);
        m_Loki_SwitchPlayerLeft = m_Loki.FindAction("Switch Player Left", throwIfNotFound: true);
        m_Loki_SwitchPlayerRight = m_Loki.FindAction("Switch Player Right", throwIfNotFound: true);
        m_Loki_TetherBaldr = m_Loki.FindAction("Tether Baldr", throwIfNotFound: true);
        m_Loki_Pause = m_Loki.FindAction("Pause", throwIfNotFound: true);
        m_Loki_Jump = m_Loki.FindAction("Jump", throwIfNotFound: true);
        m_Loki_Move = m_Loki.FindAction("Move", throwIfNotFound: true);
        m_Loki_Jump2 = m_Loki.FindAction("Jump 2", throwIfNotFound: true);
        m_Loki_SummonClone = m_Loki.FindAction("Summon Clone", throwIfNotFound: true);
        // Baldr
        m_Baldr = asset.FindActionMap("Baldr", throwIfNotFound: true);
        m_Baldr_Move = m_Baldr.FindAction("Move", throwIfNotFound: true);
        m_Baldr_Jump = m_Baldr.FindAction("Jump", throwIfNotFound: true);
        m_Baldr_Interact = m_Baldr.FindAction("Interact", throwIfNotFound: true);
        m_Baldr_SwitchPlayerLeft = m_Baldr.FindAction("Switch Player Left", throwIfNotFound: true);
        m_Baldr_SwitchPlayerRight = m_Baldr.FindAction("Switch Player Right", throwIfNotFound: true);
        m_Baldr_Pause = m_Baldr.FindAction("Pause", throwIfNotFound: true);
        m_Baldr_Jump2 = m_Baldr.FindAction("Jump 2", throwIfNotFound: true);
        m_Baldr_AngleShield = m_Baldr.FindAction("Angle Shield", throwIfNotFound: true);
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

    // Loki 
    private readonly InputActionMap m_Loki;
    private ILokiActions m_LokiActionsCallbackInterface;
    private readonly InputAction m_Loki_Interact;
    private readonly InputAction m_Loki_SwitchCloneLeft;
    private readonly InputAction m_Loki_SwitchCloneRight;
    private readonly InputAction m_Loki_SwitchPlayerLeft;
    private readonly InputAction m_Loki_SwitchPlayerRight;
    private readonly InputAction m_Loki_TetherBaldr;
    private readonly InputAction m_Loki_Pause;
    private readonly InputAction m_Loki_Jump;
    private readonly InputAction m_Loki_Move;
    private readonly InputAction m_Loki_Jump2;
    private readonly InputAction m_Loki_SummonClone;
    public struct LokiActions
    {
        private @PlayerControls m_Wrapper;
        public LokiActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Loki_Interact;
        public InputAction @SwitchCloneLeft => m_Wrapper.m_Loki_SwitchCloneLeft;
        public InputAction @SwitchCloneRight => m_Wrapper.m_Loki_SwitchCloneRight;
        public InputAction @SwitchPlayerLeft => m_Wrapper.m_Loki_SwitchPlayerLeft;
        public InputAction @SwitchPlayerRight => m_Wrapper.m_Loki_SwitchPlayerRight;
        public InputAction @TetherBaldr => m_Wrapper.m_Loki_TetherBaldr;
        public InputAction @Pause => m_Wrapper.m_Loki_Pause;
        public InputAction @Jump => m_Wrapper.m_Loki_Jump;
        public InputAction @Move => m_Wrapper.m_Loki_Move;
        public InputAction @Jump2 => m_Wrapper.m_Loki_Jump2;
        public InputAction @SummonClone => m_Wrapper.m_Loki_SummonClone;
        public InputActionMap Get() { return m_Wrapper.m_Loki; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LokiActions set) { return set.Get(); }
        public void SetCallbacks(ILokiActions instance)
        {
            if (m_Wrapper.m_LokiActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_LokiActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_LokiActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_LokiActionsCallbackInterface.OnInteract;
                @SwitchCloneLeft.started -= m_Wrapper.m_LokiActionsCallbackInterface.OnSwitchCloneLeft;
                @SwitchCloneLeft.performed -= m_Wrapper.m_LokiActionsCallbackInterface.OnSwitchCloneLeft;
                @SwitchCloneLeft.canceled -= m_Wrapper.m_LokiActionsCallbackInterface.OnSwitchCloneLeft;
                @SwitchCloneRight.started -= m_Wrapper.m_LokiActionsCallbackInterface.OnSwitchCloneRight;
                @SwitchCloneRight.performed -= m_Wrapper.m_LokiActionsCallbackInterface.OnSwitchCloneRight;
                @SwitchCloneRight.canceled -= m_Wrapper.m_LokiActionsCallbackInterface.OnSwitchCloneRight;
                @SwitchPlayerLeft.started -= m_Wrapper.m_LokiActionsCallbackInterface.OnSwitchPlayerLeft;
                @SwitchPlayerLeft.performed -= m_Wrapper.m_LokiActionsCallbackInterface.OnSwitchPlayerLeft;
                @SwitchPlayerLeft.canceled -= m_Wrapper.m_LokiActionsCallbackInterface.OnSwitchPlayerLeft;
                @SwitchPlayerRight.started -= m_Wrapper.m_LokiActionsCallbackInterface.OnSwitchPlayerRight;
                @SwitchPlayerRight.performed -= m_Wrapper.m_LokiActionsCallbackInterface.OnSwitchPlayerRight;
                @SwitchPlayerRight.canceled -= m_Wrapper.m_LokiActionsCallbackInterface.OnSwitchPlayerRight;
                @TetherBaldr.started -= m_Wrapper.m_LokiActionsCallbackInterface.OnTetherBaldr;
                @TetherBaldr.performed -= m_Wrapper.m_LokiActionsCallbackInterface.OnTetherBaldr;
                @TetherBaldr.canceled -= m_Wrapper.m_LokiActionsCallbackInterface.OnTetherBaldr;
                @Pause.started -= m_Wrapper.m_LokiActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_LokiActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_LokiActionsCallbackInterface.OnPause;
                @Jump.started -= m_Wrapper.m_LokiActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_LokiActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_LokiActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_LokiActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_LokiActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_LokiActionsCallbackInterface.OnMove;
                @Jump2.started -= m_Wrapper.m_LokiActionsCallbackInterface.OnJump2;
                @Jump2.performed -= m_Wrapper.m_LokiActionsCallbackInterface.OnJump2;
                @Jump2.canceled -= m_Wrapper.m_LokiActionsCallbackInterface.OnJump2;
                @SummonClone.started -= m_Wrapper.m_LokiActionsCallbackInterface.OnSummonClone;
                @SummonClone.performed -= m_Wrapper.m_LokiActionsCallbackInterface.OnSummonClone;
                @SummonClone.canceled -= m_Wrapper.m_LokiActionsCallbackInterface.OnSummonClone;
            }
            m_Wrapper.m_LokiActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @SwitchCloneLeft.started += instance.OnSwitchCloneLeft;
                @SwitchCloneLeft.performed += instance.OnSwitchCloneLeft;
                @SwitchCloneLeft.canceled += instance.OnSwitchCloneLeft;
                @SwitchCloneRight.started += instance.OnSwitchCloneRight;
                @SwitchCloneRight.performed += instance.OnSwitchCloneRight;
                @SwitchCloneRight.canceled += instance.OnSwitchCloneRight;
                @SwitchPlayerLeft.started += instance.OnSwitchPlayerLeft;
                @SwitchPlayerLeft.performed += instance.OnSwitchPlayerLeft;
                @SwitchPlayerLeft.canceled += instance.OnSwitchPlayerLeft;
                @SwitchPlayerRight.started += instance.OnSwitchPlayerRight;
                @SwitchPlayerRight.performed += instance.OnSwitchPlayerRight;
                @SwitchPlayerRight.canceled += instance.OnSwitchPlayerRight;
                @TetherBaldr.started += instance.OnTetherBaldr;
                @TetherBaldr.performed += instance.OnTetherBaldr;
                @TetherBaldr.canceled += instance.OnTetherBaldr;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump2.started += instance.OnJump2;
                @Jump2.performed += instance.OnJump2;
                @Jump2.canceled += instance.OnJump2;
                @SummonClone.started += instance.OnSummonClone;
                @SummonClone.performed += instance.OnSummonClone;
                @SummonClone.canceled += instance.OnSummonClone;
            }
        }
    }
    public LokiActions @Loki => new LokiActions(this);

    // Baldr
    private readonly InputActionMap m_Baldr;
    private IBaldrActions m_BaldrActionsCallbackInterface;
    private readonly InputAction m_Baldr_Move;
    private readonly InputAction m_Baldr_Jump;
    private readonly InputAction m_Baldr_Interact;
    private readonly InputAction m_Baldr_SwitchPlayerLeft;
    private readonly InputAction m_Baldr_SwitchPlayerRight;
    private readonly InputAction m_Baldr_Pause;
    private readonly InputAction m_Baldr_Jump2;
    private readonly InputAction m_Baldr_AngleShield;
    public struct BaldrActions
    {
        private @PlayerControls m_Wrapper;
        public BaldrActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Baldr_Move;
        public InputAction @Jump => m_Wrapper.m_Baldr_Jump;
        public InputAction @Interact => m_Wrapper.m_Baldr_Interact;
        public InputAction @SwitchPlayerLeft => m_Wrapper.m_Baldr_SwitchPlayerLeft;
        public InputAction @SwitchPlayerRight => m_Wrapper.m_Baldr_SwitchPlayerRight;
        public InputAction @Pause => m_Wrapper.m_Baldr_Pause;
        public InputAction @Jump2 => m_Wrapper.m_Baldr_Jump2;
        public InputAction @AngleShield => m_Wrapper.m_Baldr_AngleShield;
        public InputActionMap Get() { return m_Wrapper.m_Baldr; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaldrActions set) { return set.Get(); }
        public void SetCallbacks(IBaldrActions instance)
        {
            if (m_Wrapper.m_BaldrActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_BaldrActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_BaldrActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_BaldrActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_BaldrActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BaldrActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BaldrActionsCallbackInterface.OnJump;
                @Interact.started -= m_Wrapper.m_BaldrActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_BaldrActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_BaldrActionsCallbackInterface.OnInteract;
                @SwitchPlayerLeft.started -= m_Wrapper.m_BaldrActionsCallbackInterface.OnSwitchPlayerLeft;
                @SwitchPlayerLeft.performed -= m_Wrapper.m_BaldrActionsCallbackInterface.OnSwitchPlayerLeft;
                @SwitchPlayerLeft.canceled -= m_Wrapper.m_BaldrActionsCallbackInterface.OnSwitchPlayerLeft;
                @SwitchPlayerRight.started -= m_Wrapper.m_BaldrActionsCallbackInterface.OnSwitchPlayerRight;
                @SwitchPlayerRight.performed -= m_Wrapper.m_BaldrActionsCallbackInterface.OnSwitchPlayerRight;
                @SwitchPlayerRight.canceled -= m_Wrapper.m_BaldrActionsCallbackInterface.OnSwitchPlayerRight;
                @Pause.started -= m_Wrapper.m_BaldrActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_BaldrActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_BaldrActionsCallbackInterface.OnPause;
                @Jump2.started -= m_Wrapper.m_BaldrActionsCallbackInterface.OnJump2;
                @Jump2.performed -= m_Wrapper.m_BaldrActionsCallbackInterface.OnJump2;
                @Jump2.canceled -= m_Wrapper.m_BaldrActionsCallbackInterface.OnJump2;
                @AngleShield.started -= m_Wrapper.m_BaldrActionsCallbackInterface.OnAngleShield;
                @AngleShield.performed -= m_Wrapper.m_BaldrActionsCallbackInterface.OnAngleShield;
                @AngleShield.canceled -= m_Wrapper.m_BaldrActionsCallbackInterface.OnAngleShield;
            }
            m_Wrapper.m_BaldrActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @SwitchPlayerLeft.started += instance.OnSwitchPlayerLeft;
                @SwitchPlayerLeft.performed += instance.OnSwitchPlayerLeft;
                @SwitchPlayerLeft.canceled += instance.OnSwitchPlayerLeft;
                @SwitchPlayerRight.started += instance.OnSwitchPlayerRight;
                @SwitchPlayerRight.performed += instance.OnSwitchPlayerRight;
                @SwitchPlayerRight.canceled += instance.OnSwitchPlayerRight;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Jump2.started += instance.OnJump2;
                @Jump2.performed += instance.OnJump2;
                @Jump2.canceled += instance.OnJump2;
                @AngleShield.started += instance.OnAngleShield;
                @AngleShield.performed += instance.OnAngleShield;
                @AngleShield.canceled += instance.OnAngleShield;
            }
        }
    }
    public BaldrActions @Baldr => new BaldrActions(this);
    public interface ILokiActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnSwitchCloneLeft(InputAction.CallbackContext context);
        void OnSwitchCloneRight(InputAction.CallbackContext context);
        void OnSwitchPlayerLeft(InputAction.CallbackContext context);
        void OnSwitchPlayerRight(InputAction.CallbackContext context);
        void OnTetherBaldr(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnJump2(InputAction.CallbackContext context);
        void OnSummonClone(InputAction.CallbackContext context);
    }
    public interface IBaldrActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSwitchPlayerLeft(InputAction.CallbackContext context);
        void OnSwitchPlayerRight(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnJump2(InputAction.CallbackContext context);
        void OnAngleShield(InputAction.CallbackContext context);
    }
}
