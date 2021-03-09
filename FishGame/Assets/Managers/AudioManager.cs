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

public class AudioManager : MonoBehaviour
{
    [Header("Audio")]
    public float MaxVolume = 0.2f;
    public AudioClip MenuTheme;
    public AudioClip MatchTheme;

    [Header("UI")]
    public Button ToggleAudioButton;
    public Sprite MuteImage;
    public Sprite UnmuteImage;

    private AudioSource audioSource;
    
    /// <summary>
    /// Called by Unity when this GameObject starts.
    /// </summary>
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ToggleAudioButton.onClick.AddListener(ToggleMute);
    }

    /// <summary>
    /// Called by Unity when this GameObject is being destroyed.
    /// </summary>
    private void OnDestroy()
    {
        ToggleAudioButton.onClick.RemoveListener(ToggleMute);
    }

    /// <summary>
    /// Plays the main menu theme song.
    /// </summary>
    public void PlayMenuTheme()
    {
        audioSource.Stop();
        audioSource.clip = MenuTheme;
        audioSource.Play();
    }

    /// <summary>
    /// Plays the match theme song.
    /// </summary>
    public void PlayMatchTheme()
    {
        audioSource.Stop();
        audioSource.clip = MatchTheme;
        audioSource.Play();
    }

    /// <summary>
    /// Toggles whether the audio is muted.
    /// </summary>
    public void ToggleMute()
    {
        var isMaxVolume = audioSource.volume == MaxVolume;
        audioSource.volume = isMaxVolume ? 0 : MaxVolume;
        ToggleAudioButton.GetComponent<Image>().sprite = !isMaxVolume ? UnmuteImage : MuteImage;
    }
}
