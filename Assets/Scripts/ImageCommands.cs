using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCommands
{
    public static void ResizeImageToSpriteSize(Image image)
    {
        if (image.sprite == null)
        {
            Debug.LogError("Image sprite is null. Cannot resize.");
            return;
        }

        // Get the size of the new sprite
        Vector2 spriteSize = image.sprite.rect.size;

        // Set the size of the Image GameObject to match the sprite size
        image.rectTransform.sizeDelta = spriteSize;
    }
}
