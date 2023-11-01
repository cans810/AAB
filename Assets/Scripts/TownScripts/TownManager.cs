using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TownManager : MonoBehaviour
{
    public GameObject townObject;
    public GameObject homeObject;
    public GameObject arenaObject;
    public GameObject weaponShopObject;
    public GameObject armorShopObject;
    public Button tournamentButton;

    GameObject enemyGenerator;

    GameObject playerObject;

    void OnEnable(){
        homeObject.SetActive(false);
        arenaObject.SetActive(false);
        weaponShopObject.SetActive(false);
        armorShopObject.SetActive(false);

        enemyGenerator = GameObject.Find("GladiatorGenerator");

        playerObject = GameObject.Find("Player");
        playerObject.GetComponent<Player>().transform.localScale = playerObject.GetComponent<Player>().originalScale;
        playerObject.GetComponent<Player>().transform.position = new Vector3(-1,-4.536973f,0);
        playerObject.GetComponent<Player>().transform.localScale = new Vector3(playerObject.GetComponent<Player>().transform.localScale.x*5/10f, playerObject.GetComponent<Player>().transform.localScale.y*5/10f, 
        playerObject.GetComponent<Player>().transform.localScale.z*5/10f);

        // Freeze the Y-axis position
        playerObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;

        if (tournamentButton != null)
        {
            // Add an event listener to the button's onClick event
            tournamentButton.onClick.AddListener(OnClick);
            tournamentButton.onClick.AddListener(enterTournament);
        }
    }

    void OnDisable(){
        // Freeze the Y-axis position
        playerObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyGeneratorController.Instance != null){
            Destroy(EnemyGeneratorController.Instance);
        }
    }

    public void goToTown(){
        homeObject.SetActive(false);
        weaponShopObject.SetActive(false);
        armorShopObject.SetActive(false);
        arenaObject.SetActive(false);
        townObject.SetActive(true);
    }

    public void goToHome(){
        HomeManager.justEnteredHome = true;
        townObject.SetActive(false);
        weaponShopObject.SetActive(false);
        armorShopObject.SetActive(false);
        arenaObject.SetActive(false);
        homeObject.SetActive(true);
    }

    public void enterWeaponShop(){
        townObject.SetActive(false);
        homeObject.SetActive(false);
        arenaObject.SetActive(false);
        armorShopObject.SetActive(false);
        weaponShopObject.SetActive(true);
    }

    public void enterArena(){
        townObject.SetActive(false);
        homeObject.SetActive(false);
        armorShopObject.SetActive(false);
        weaponShopObject.SetActive(false);
        arenaObject.SetActive(true);
    }

    public void enterArmorShop(){
        townObject.SetActive(false);
        homeObject.SetActive(false);
        arenaObject.SetActive(false);
        armorShopObject.SetActive(true);
        weaponShopObject.SetActive(false);
    }

    public void enterTournament(){
        GameObject sceneLoader2 = GameObject.Find("SceneLoader");
        sceneLoader2.GetComponent<SceneLoader>().FadeToLevel("TournamentShowcaseScene");
    }


    public void enterBattle(){
        GameObject sceneLoader = GameObject.Find("SceneLoader");
        sceneLoader.GetComponent<SceneLoader>().FadeToLevel("ShowcaseEnemy");
    }

    private void OnClick()
    {
        GameObject tournamentManager = GameObject.Find("TournamentManager");
        tournamentManager.GetComponent<TournamentManager>().generateTournament();
        playerObject.GetComponent<Player>().inATournament = true;
    }

}
