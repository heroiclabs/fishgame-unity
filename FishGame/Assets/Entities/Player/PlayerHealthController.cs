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

/// <summary>
/// Controls the health and death state of the player it is attached to.
/// </summary>
public class PlayerHealthController : MonoBehaviour
{
    public PlayerDiedEvent PlayerDied;
    public int MaxHealth = 1;
    
    private int health = 1;
    private PlayerMovementController playerMovementController;
    private PlayerInputController playerInputController;

    /// <summary>
    /// Called by Unity when this GameObject starts.
    /// </summary>
    private void Start()
    {
        // Initialise the PlayerDied event if it has not already been.
        if (PlayerDied == null)
        {
            PlayerDied = new PlayerDiedEvent();
        }

        // Set the players health to full health.
        health = MaxHealth;

        // Cache references to required components.
        playerMovementController = GetComponentInChildren<PlayerMovementController>(); 
        playerInputController = GetComponent<PlayerInputController>();

        // Begin listening for the CollidedWithProjectile event on the PlayerMovementController.
        playerMovementController.CollidedWithProjectile.AddListener(OnCollidedWithProjectile);
    }

    /// <summary>
    /// Reduces the players health by damage, triggers the PlayerDied event if health is 0 or below.
    /// </summary>
    /// <param name="damage">The amount of damage the player should receive.</param>
    public void TakeDamage(int damage = 1)
    {
        // Reduce the players health by damage.
        health -= damage;

        // If health falls to 0 or below, disable player input controls, play the death animation and fire the PlayerDied event.
        if (health <= 0)
        {
            playerInputController.enabled = false;
            playerMovementController.SetHorizontalMovement(0);
            playerMovementController.SetJump(false);
            playerMovementController.SetJumpHeld(false);
            playerMovementController.PlayDeathAnimation();
            PlayerDied.Invoke(gameObject);
        }
    }
    
    /// <summary>
    /// Called when the CollidedWithProjectile event fires.
    /// </summary>
    private void OnCollidedWithProjectile()
    {
        TakeDamage();
    }
}
