using UnityEngine;

public class SpriteColorSetter : MonoBehaviour
{
    public Color desiredColor = Color.red; // Adjust this value to your desired color

    public void SetSpriteColor()
    {
        // Get all child objects of the current GameObject
        foreach (Transform child in transform)
        {
            // Check if the child has a SpriteRenderer component
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            
            if (spriteRenderer != null)
            {
                // Set the color of the sprite to the desired color
                spriteRenderer.color = desiredColor;
            }

            // Recursively call the method for nested child objects
            SetSpriteColorRecursive(child.gameObject);
        }
    }

    private void SetSpriteColorRecursive(GameObject obj)
    {
        foreach (Transform child in obj.transform)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            
            if (spriteRenderer != null)
            {
                spriteRenderer.color = desiredColor;
            }

            SetSpriteColorRecursive(child.gameObject);
        }
    }
}
