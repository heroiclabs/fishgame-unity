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
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Controls the behaviour of the in-game menu.
/// </summary>
public class InGameMenu : MonoBehaviour
{
    public UnityEvent OnRequestQuitMatch;

    public Button ResumeButton;
    public Button ExitButton;

    private bool isOpen;

    /// <summary>
    /// Called by Unity when this GameObject starts.
    /// </summary>
    private void Start()
    {
        // Initialise the OnRequestQuitMatch event if required.
        if (OnRequestQuitMatch == null)
        {
            OnRequestQuitMatch = new UnityEvent();
        }

        // Add button event listeners.
        ResumeButton.onClick.AddListener(Close);
        ExitButton.onClick.AddListener(QuitMatch);
    }

    /// <summary>
    /// Called by Unity every frame.
    /// </summary>
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isOpen)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    /// <summary>
    /// Called by Unity when this GameObject is being destroyed.
    /// </summary>
    private void OnDestroy()
    {
        // Remove button event listeners.
        ResumeButton.onClick.RemoveListener(Close);
        ExitButton.onClick.RemoveListener(QuitMatch);
    }

    /// <summary>
    /// Opens the in-game menu.
    /// </summary>
    public void Open()
    {
        gameObject.GetComponent<Canvas>().enabled = true;
        GameObject.FindGameObjectWithTag("LocalPlayer").GetComponent<PlayerInputController>().enabled = false;
        isOpen = true;
    }

    /// <summary>
    /// Closes the in-game menu.
    /// </summary>
    public void Close()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("LocalPlayer").GetComponent<PlayerInputController>().enabled = true;
        isOpen = false;
    }

    /// <summary>
    /// Quits the current match and closes the in-game menu.
    /// </summary>
    /// <returns></returns>
    public void QuitMatch()
    {
        OnRequestQuitMatch.Invoke();
        Close();
    }
}
