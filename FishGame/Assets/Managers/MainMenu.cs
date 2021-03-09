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
using UnityEngine.UI;

/// <summary>
/// Controls the behaviour of the main menu.
/// </summary>
public class MainMenu : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject MatchmakingPanel;
    public GameObject CreditsPanel;
    public Button CreditsButton;
    public Button BackButton;
    public Button FindMatchButton;
    public Button CancelMatchmakingButton;
    public InputField NameField;
    public Dropdown PlayersDropdown;
    
    private GameManager gameManager;

    /// <summary>
    /// Called by Unity when this GameObject starts.
    /// </summary>
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        if (PlayerPrefs.HasKey("Name"))
        {
            NameField.text = PlayerPrefs.GetString("Name");
        }

        // Add event listeners for the menu buttons.
        CreditsButton.onClick.AddListener(GoToCredits);
        BackButton.onClick.AddListener(BackFromCredits);
        FindMatchButton.onClick.AddListener(FindMatch);
        CancelMatchmakingButton.onClick.AddListener(CancelMatchmaking);
    }

    /// <summary>
    /// Called by Unity when this GameObject is being destroyed.
    /// </summary>
    private void OnDestroy()
    {
        // Remove event listeners for the menu buttons.
        CreditsButton.onClick.RemoveListener(GoToCredits);
        BackButton.onClick.RemoveListener(BackFromCredits);
        FindMatchButton.onClick.RemoveListener(FindMatch);
        CancelMatchmakingButton.onClick.RemoveListener(CancelMatchmaking);
    }
    
    /// <summary>
    /// Enables the Find Match button.
    /// </summary>
    public void EnableFindMatchButton()
    {
        FindMatchButton.interactable = true;
    }

    /// <summary>
    /// Disables the Find Match button.
    /// </summary>
    public void DisableFindMatchButton()
    {
        FindMatchButton.interactable = false;
    }

    /// <summary>
    /// Hides the main menu.
    /// </summary>
    public void DeactivateMenu()
    {
        MenuPanel.SetActive(true);
        MatchmakingPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Begins the matchmaking process.
    /// </summary>
    public async void FindMatch()
    {
        MenuPanel.SetActive(false);
        MatchmakingPanel.SetActive(true);
        CreditsPanel.SetActive(false);
        
        PlayerPrefs.SetString("Name", NameField.text);
        gameManager.SetDisplayName(NameField.text);
        await gameManager.NakamaConnection.FindMatch(int.Parse(PlayersDropdown.options[PlayersDropdown.value].text));
    }

    /// <summary>
    /// Cancels the matchmaking process.
    /// </summary>
    public async void CancelMatchmaking()
    {
        MenuPanel.SetActive(true);
        MatchmakingPanel.SetActive(false);
        CreditsPanel.SetActive(false);

        await gameManager.NakamaConnection.CancelMatchmaking();
    }

    /// <summary>
    /// Opens the credits screen.
    /// </summary>
    public void GoToCredits()
    {
        MenuPanel.SetActive(false);
        MatchmakingPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    /// <summary>
    /// Goes back to the main menu.
    /// </summary>
    public void BackFromCredits()
    {
        MenuPanel.SetActive(true);
        MatchmakingPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }
}
