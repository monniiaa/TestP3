//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Inputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Inputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""ScreenShot"",
            ""id"": ""6d7b27d5-ba2c-4826-92e5-4ff61a4b4b12"",
            ""actions"": [
                {
                    ""name"": ""TakeScreenShoot"",
                    ""type"": ""Button"",
                    ""id"": ""f3e54c04-662b-467d-b7fb-d05f572fb971"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""782ef113-b0c4-431d-a59d-011f77796404"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TakeScreenShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ScreenShot
        m_ScreenShot = asset.FindActionMap("ScreenShot", throwIfNotFound: true);
        m_ScreenShot_TakeScreenShoot = m_ScreenShot.FindAction("TakeScreenShoot", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // ScreenShot
    private readonly InputActionMap m_ScreenShot;
    private IScreenShotActions m_ScreenShotActionsCallbackInterface;
    private readonly InputAction m_ScreenShot_TakeScreenShoot;
    public struct ScreenShotActions
    {
        private @Inputs m_Wrapper;
        public ScreenShotActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @TakeScreenShoot => m_Wrapper.m_ScreenShot_TakeScreenShoot;
        public InputActionMap Get() { return m_Wrapper.m_ScreenShot; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ScreenShotActions set) { return set.Get(); }
        public void SetCallbacks(IScreenShotActions instance)
        {
            if (m_Wrapper.m_ScreenShotActionsCallbackInterface != null)
            {
                @TakeScreenShoot.started -= m_Wrapper.m_ScreenShotActionsCallbackInterface.OnTakeScreenShoot;
                @TakeScreenShoot.performed -= m_Wrapper.m_ScreenShotActionsCallbackInterface.OnTakeScreenShoot;
                @TakeScreenShoot.canceled -= m_Wrapper.m_ScreenShotActionsCallbackInterface.OnTakeScreenShoot;
            }
            m_Wrapper.m_ScreenShotActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TakeScreenShoot.started += instance.OnTakeScreenShoot;
                @TakeScreenShoot.performed += instance.OnTakeScreenShoot;
                @TakeScreenShoot.canceled += instance.OnTakeScreenShoot;
            }
        }
    }
    public ScreenShotActions @ScreenShot => new ScreenShotActions(this);
    public interface IScreenShotActions
    {
        void OnTakeScreenShoot(InputAction.CallbackContext context);
    }
}
