using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    private Camera mainCamera;
    public float smoothSpeed = 1.0f;
    public Vector3 offset;
    public float minOrthographicSize = 3.0f; // Minimum orthographic size
    public float initialOrthographicSize = 5.0f; // Initial orthographic size for the zoom-in effect
    public float zoomInSpeed = 2.7f; // Speed of the initial zoom-in effect

    public static bool zoomInEffectDone = false;

    private void Start()
    {
        player = Player.Instance.transform;
        enemy = EnemyGeneratorController.Instance.transform;
        mainCamera = Camera.main;
        mainCamera.orthographicSize = initialOrthographicSize;
    }

    private void Update()
    {
        //Debug.Log(mainCamera.orthographicSize);

        if (!zoomInEffectDone)
        {
            // Calculate the step size based on zoomInSpeed
            float step = zoomInSpeed * Time.deltaTime;

            // Move orthographic size towards minOrthographicSize
            mainCamera.orthographicSize = Mathf.MoveTowards(mainCamera.orthographicSize, 3, step);

            // Check if the zoom-in effect is done
            if (Mathf.Approximately(mainCamera.orthographicSize, 3))
            {
                zoomInEffectDone = true;
            }
        }
        else
        {
            // Regular camera updates
            float targetOrthographicSize = CalculateOrthographicSize();
            if (mainCamera.orthographicSize != targetOrthographicSize)
            {
                mainCamera.orthographicSize = Mathf.MoveTowards(mainCamera.orthographicSize, targetOrthographicSize, smoothSpeed * Time.deltaTime);
            }

            UpdateCameraPosition();
        }
    }

    private float CalculateOrthographicSize()
    {
        // Calculate the horizontal and vertical distances between player and enemy
        float distanceX = Mathf.Abs(player.position.x - enemy.position.x) / 2.0f + (player.localScale.x + enemy.localScale.x) * 2.5f;
        float distanceY = Mathf.Abs(player.position.y - enemy.position.y) / 2.0f + (player.localScale.y + enemy.localScale.y) * 2.5f;

        // Calculate the required orthographic size based on the larger of the two distances
        float orthoSizeX = distanceX / mainCamera.aspect;
        float orthoSizeY = distanceY;

        // Ensure the orthographic size is not below the minimum (3)
        float calculatedOrthographicSize = Mathf.Max(Mathf.Max(orthoSizeX, orthoSizeY), minOrthographicSize);

        if (calculatedOrthographicSize < 3){
            calculatedOrthographicSize = 3;
        }

        return calculatedOrthographicSize;
    }


    private void UpdateCameraPosition()
    {
        // Calculate the midpoint between player and enemy
        Vector3 midpoint = (player.position + enemy.position) / 2.0f;

        // Set the camera's position with an offset
        Vector3 targetPosition = new Vector3(midpoint.x + offset.x, transform.position.y, transform.position.z + offset.z);

        // Smoothly move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }

    void OnDisable(){
        zoomInEffectDone = false;
    }
}
