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
/// Controls the behaviour of the cannonball projectile.
/// </summary>
public class Cannonball : MonoBehaviour
{
    public Vector2 InitialVelocity;

    [HideInInspector]
    public GameObject Owner;

    private Animator animator;

    private int direction;

    private Rigidbody2D r;

    /// <summary>
    /// Called by Unity when this GameObject starts.
    /// </summary>
    private void Start()
    {
        r = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        // If there is an InitialVelocity value set in the inspector then use that as the RigidBody2D velocity.
        if (InitialVelocity != Vector2.zero)
        {
            r.velocity = InitialVelocity;
        }
    }

    /// <summary>
    /// Called by Unity every frame.
    /// </summary>
    private void Update()
    {
        // Set a local direction variable if it is not already set and this projectile has velocity.
        if (r.velocity != Vector2.zero && direction == 0)
        {
            direction = r.velocity.x < 0 ? -1 : 1;
        }
    }

    /// <summary>
    /// Called by Unity whenever this projectile collides.
    /// </summary>
    /// <param name="collision">The object the projectile collided with.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When colliding with anything, stop moving and trigger the explode animation.
        animator.SetTrigger("Explode");
        GetComponent<Rigidbody2D>().velocity = new Vector2();
    }

    /// <summary>
    /// This is called by an action trigger in the Explode animation.
    /// </summary>
    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Gets the current direction this projectile is travelling.
    /// </summary>
    /// <returns>The direction where -1 is left and 1 is right.</returns>
    public int GetDirection()
    {
        return direction;
    }
}
