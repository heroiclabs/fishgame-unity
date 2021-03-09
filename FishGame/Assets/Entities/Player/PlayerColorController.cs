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

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum PlayerColor
{
    Orange,
    Blue,
    Green
}

/// <summary>
/// Controls the color of the player it is attached to.
/// </summary>
public class PlayerColorController : MonoBehaviour
{


    public PlayerColor Color = PlayerColor.Orange;
    public SpriteRenderer bodySpriteRenderer;
    public SpriteRenderer finSpriteRenderer;

    private Dictionary<string, Sprite> spriteSheetSprites = new Dictionary<string, Sprite>();
    private PlayerColor currentColor;

    /// <summary>
    /// Called by Unity whenever this GameObject starts.
    /// </summary>
    private void Start()
    {
        LoadSpritesheet();
    }

    /// <summary>
    /// Called by Unity every frame after all Update calls have been made.
    /// </summary>
    private void LateUpdate()
    {
        if (Color != currentColor)
        {
            LoadSpritesheet();
        }

        bodySpriteRenderer.sprite = spriteSheetSprites[bodySpriteRenderer.sprite.name];
        finSpriteRenderer.sprite = spriteSheetSprites[finSpriteRenderer.sprite.name];
    }

    /// <summary>
    /// Sets the color of the player.
    /// </summary>
    /// <param name="color"></param>
    public void SetColor(PlayerColor color)
    {
        Color = color;
    }

    /// <summary>
    /// Sets the color of the player.
    /// </summary>
    /// <param name="colorIndex">The index of the color as defined in the PlayerColor enum.</param>
    public void SetColor(int colorIndex)
    {
        var colorType = typeof(PlayerColor);
        var colors = colorType.GetEnumValues();
        var playerColor = (PlayerColor) colors.GetValue(colorIndex % colors.Length);
        SetColor(playerColor);
    }

    /// <summary>
    /// Loads the current color spritesheet into the dictionary of sprites.
    /// </summary>
    private void LoadSpritesheet()
    {
        var spritesheetName = string.Format("Fish{0}", Color.ToString());
        var sprites = Resources.LoadAll<Sprite>(spritesheetName);
        spriteSheetSprites = sprites.ToDictionary(x => x.name, x => x);
        currentColor = Color;
    }
}
