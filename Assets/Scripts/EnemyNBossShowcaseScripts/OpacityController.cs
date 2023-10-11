using UnityEngine;

public class OpacityController : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float opacity = 1f; // Default to fully opaque
    public bool startOpacityFadeOut = false;

    private void Start()
    {
        // Set the initial opacity when the script starts
        SetOpacity(opacity);
    }

    public void Update(){
        if (startOpacityFadeOut){
            SetOpacity(opacity);
        }
    }

    public void startFadingOut(){
        startOpacityFadeOut = true;
    }

    public void stopFadingOut(){
        startOpacityFadeOut = false;
    }

    // Call this method to update the opacity of this GameObject and its children
    public void SetOpacity(float newOpacity)
    {
        opacity = Mathf.Clamp01(newOpacity); // Ensure the value is between 0 and 1
        ApplyOpacityToChildren(transform);
    }

    private void ApplyOpacityToChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            CanvasRenderer canvasRenderer = child.GetComponent<CanvasRenderer>();

            if (spriteRenderer != null)
            {
                Color currentColor = spriteRenderer.color;
                currentColor.a = opacity;
                spriteRenderer.color = currentColor;
            }
            else if (canvasRenderer != null)
            {
                Color currentColor = canvasRenderer.GetColor();
                currentColor.a = opacity;
                canvasRenderer.SetColor(currentColor);
            }

            // Recursively apply opacity to children of this child
            ApplyOpacityToChildren(child);
        }
    }
}

