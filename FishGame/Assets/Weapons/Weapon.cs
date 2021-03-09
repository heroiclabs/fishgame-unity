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
/// Base class for weapons.
/// </summary>
public abstract class Weapon : MonoBehaviour
{
    public float AttackInterval = 0.25f;

    private float attackTimer;

    /// <summary>
    /// Called by Unity every frame.
    /// </summary>
    private void Update()
    {
        attackTimer -= Time.deltaTime;
    }

    /// <summary>
    /// Attack with this weapon.
    /// </summary>
    public void Attack()
    {
        // If the attack interval has elapsed then attack and reset the attack timer.
        if (attackTimer <= 0)
        {
            HandleAttack();
            attackTimer = AttackInterval;
        }
    }

    /// <summary>
    /// Override in child class to handle attack logic.
    /// </summary>
    protected abstract void HandleAttack();
}
