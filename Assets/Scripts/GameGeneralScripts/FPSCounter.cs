using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    private float deltaTime = 0.0f;

    private void Awake()
    {
        // Make sure the GameObject with this script is not destroyed when loading a new scene.
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        int fps = Mathf.RoundToInt(1.0f / deltaTime);
        string text = $"FPS: {fps}";
        GUI.Label(new Rect(10, 10, 100, 20), text);
    }
}
