using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isPaused = false;
    public bool isGameOver = false;
    public bool inBattle = false;
    public bool inArena = false;
    public bool inWeaponShop = false;
    public bool inArmorShop = false;
    public bool inHome = false;
    public bool inTown = false;
    public static Enemy currentEnemy;
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
        currentArena = "underground_arena";
    }

    private void Update()
    {
        if (inBattle){
            currentEnemy = EnemyGeneratorController.Instance.GetComponent<Enemy>();
        }
        if (inArena){

        }
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }

        if (isGameOver)
        {
            // Handle game over logic
        }*/
    }

    public void TogglePauseGame()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0.0f; // Pause the game
        }
        else
        {
            Time.timeScale = 1.0f; // Resume the game
        }
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
