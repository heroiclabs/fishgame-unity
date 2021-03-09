/*
Copyright 2021 Heroic Labs

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [HideInInspector] public float HorizontalInput;
    [HideInInspector] public bool Jump;
    [HideInInspector] public bool JumpHeld;
    [HideInInspector] public bool Attack;
    [HideInInspector] public bool InputChanged;
    
    private PlayerMovementController playerMovementController;
    private PlayerWeaponController playerWeaponController;

    /// <summary>
    /// Called by Unity when this GameObject starts.
    /// </summary>
    private void Start()
    {
        playerMovementController = GetComponentInChildren<PlayerMovementController>();
        playerWeaponController = GetComponentInChildren<PlayerWeaponController>();
    }

    /// <summary>
    /// Called by Unity every frame.
    /// </summary>
    private void Update()
    {
        // Get the current input states.
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var jump = Input.GetButtonDown("Jump");
        var jumpHeld = Input.GetButton("Jump");
        var attack = Input.GetButtonDown("Fire1");

        // Set a boolean (true/false) value to indicate if any input state has changed since the last frame.
        InputChanged = (horizontalInput != HorizontalInput || jump != Jump || jumpHeld != JumpHeld || attack != Attack);

        // Cache the new input states in public variables that can be read elsewhere.
        HorizontalInput = horizontalInput;
        Jump = jump;
        JumpHeld = jumpHeld;
        Attack = attack;

        // Set inputs on Player Controllers.
        playerMovementController.SetHorizontalMovement(HorizontalInput);
        playerMovementController.SetJump(Jump);
        playerMovementController.SetJumpHeld(JumpHeld);

        // If the attack input is true, call the PlayerWeaponController Attack method.
        if (attack)
        {
            playerWeaponController.Attack();
        }
    }
}
