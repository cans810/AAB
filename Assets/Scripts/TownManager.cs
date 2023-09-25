using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownManager : MonoBehaviour
{
    public GameObject townObject;
    public GameObject homeObject;
    public GameObject arenaObject;
    public GameObject weaponShopObject;
    public GameObject armorShopObject;

    GameObject enemyGenerator;

    GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        homeObject.SetActive(false);
        arenaObject.SetActive(false);
        weaponShopObject.SetActive(false);
        armorShopObject.SetActive(false);

        enemyGenerator = GameObject.Find("GladiatorGenerator");

        playerObject = GameObject.Find("Player");
        playerObject.GetComponent<Player>().transform.position = new Vector3(-1,-4.536973f,0);
        playerObject.GetComponent<Player>().transform.localScale = new Vector3(playerObject.GetComponent<Player>().transform.localScale.x*2/5f, playerObject.GetComponent<Player>().transform.localScale.y*2/5f, 
        playerObject.GetComponent<Player>().transform.localScale.z*2/5f);
        
    }

    void OnEnable(){
        playerObject.GetComponent<Player>().transform.localScale = new Vector3(playerObject.GetComponent<Player>().transform.localScale.x*2/5f, playerObject.GetComponent<Player>().transform.localScale.y*2/5f, 
        playerObject.GetComponent<Player>().transform.localScale.z*2/5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (RandomEnemyGenerator.Instance != null){
            Destroy(RandomEnemyGenerator.Instance);
        }
        playerObject.GetComponent<Player>().transform.position = new Vector3(-1,-4.536973f,0);
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


    public void enterFirstBattle(){
        GameObject sceneLoader = GameObject.Find("SceneLoader");
        sceneLoader.GetComponent<SceneLoader>().FadeToLevel("FirstBattleScene");
    }

}
