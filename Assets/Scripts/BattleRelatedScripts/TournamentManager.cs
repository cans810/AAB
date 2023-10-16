using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentManager : MonoBehaviour
{

    public static TournamentManager Instance { get; private set; }

    public string currentTournament;
    public List<string> tournaments;
    public bool canEnterCurrentTournament;
    public int enemysToBeat;

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

    // Start is called before the first frame update
    void Start()
    {
        canEnterCurrentTournament = false;
        tournaments.Add("first");
        tournaments.Add("second");
        tournaments.Add("third");
        tournaments.Add("fourth");
        tournaments.Add("fifth");
        tournaments.Add("sixth");
        tournaments.Add("seventh");
        tournaments.Add("eightth");
        tournaments.Add("nineth");
        tournaments.Add("ten");
        tournaments.Add("eleven");
        tournaments.Add("twelve");
        tournaments.Add("thirteen");
        tournaments.Add("fourteen");
        tournaments.Add("fifteen");
        tournaments.Add("sixteen");
        tournaments.Add("seventeen");
        tournaments.Add("eighteen");
        tournaments.Add("nineteen");
        tournaments.Add("twenty");
        tournaments.Add("twentyone");
        tournaments.Add("twentytwo");
        tournaments.Add("twentythree");
        currentTournament = tournaments[0];
    }

    // Update is called once per frame
    void Update()
    {
        // if can enter current tournament, find which tournament it is, and generate it once the player clicks on the tournament.
        //Debug.Log(enemysToBeat);
    }

    public void generateTournament(){
        if (currentTournament.Equals("first")){
            enemysToBeat = 1;
        }
        else if (currentTournament.Equals("second")){
            enemysToBeat = 1;
        }
        GameObject sceneLoader = GameObject.Find("SceneLoader");
        sceneLoader.GetComponent<SceneLoader>().FadeToLevel("ShowcaseEnemy");
    }
}
