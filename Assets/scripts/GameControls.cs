using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameControls : MonoBehaviour
{
    [SerializeField]
    public PlayerControls controls;
    //static control varrrrssss (why didnt i think of this before...)
    //controls normal
    public static bool inJump;
    public static bool inSprint;

    public static bool inPrimary;
    public static bool inSecondary;
    public static Vector2 walkAxis;
    //cam
    public static Vector2 cameraAxis;
    //mouse
    
    void Awake()
    {
        controls = new PlayerControls();
    }
    void Start()
    {
        controls.Disable();
        controls.Enable();
    }
    void Update()
    {
        walkAxis = controls.Gameplay.Move.ReadValue<Vector2>();
        cameraAxis = controls.Gameplay.Look.ReadValue<Vector2>() * 0.05f;
        inSecondary = controls.Gameplay.Secondary.IsPressed();
       inPrimary = controls.Gameplay.Primary.IsPressed();

        inJump = controls.Gameplay.Jump.IsPressed();
    
        inSprint = controls.Gameplay.Sprint.IsPressed();
    }
}