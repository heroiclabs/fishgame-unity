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
/// A simple follow camera.
/// </summary>
public class PlayerCameraController : MonoBehaviour
{
    private Transform playerTransform;

    /// <summary>
    /// Called by Unity when this GameObject starts.
    /// </summary>
    private void Start()
    {
        var player = GetComponentInChildren<PlayerMovementController>();
        playerTransform = player.GetComponent<Transform>();
    }

    /// <summary>
    /// Called by Unity every frame after all Update calls have been made.
    /// </summary>
    private void LateUpdate()
    {
        Camera.main.transform.position = playerTransform.position;
    }
}
