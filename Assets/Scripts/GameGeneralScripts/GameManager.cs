using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static Enemy currentEnemy;
    public GameObject player;
    public string currentArena;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        currentArena = "underground_arena";
    }

    private void Update()
    {

    }

    public void TogglePauseGame()
    {

    }

    private IEnumerator ActivatePlayerAfterDelay()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        yield return new WaitForSeconds(0.3f); // Wait for 1 second.

        // Activate the Player GameObject.
        playerObject.SetActive(true);
    }

    private bool IsCurrentScene(string sceneName)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        return currentScene.name == sceneName;
    }
}
