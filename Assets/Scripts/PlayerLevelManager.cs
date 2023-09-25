using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLevelManager : MonoBehaviour
{
    private Player player;
    public static bool leveledUP;
    public static int level = 1;
    public static double xp = 0;
    public Image XpBarInner;
    public double allXPForLevelUP;
    public float xpFillSpeed = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        player = Player.Instance;
        leveledUP = false;
        XpBarInner.fillAmount = 0;
    }

    private void Update()
    {
        if (BattleSystem.state == BattleState.WON)
        {
            addXP();
            calculateAllXPNeededForLevelUp();
            StartCoroutine(FillXPBarSlowly());
            BattleSystem.state = BattleState.IN_AFTER_BATTLE_WAITING;
        }
        else if (BattleSystem.state == BattleState.LOST)
        {
            calculateAllXPNeededForLevelUp();
            StartCoroutine(FillXPBarSlowly());
            BattleSystem.state = BattleState.IN_AFTER_BATTLE_WAITING;
        }

        managePlayerLevel();
    }

    private IEnumerator FillXPBarSlowly()
    {
        float currentFill = XpBarInner.fillAmount;
        float targetFill = (float)(xp / allXPForLevelUP);

        while (currentFill < targetFill)
        {
            currentFill += xpFillSpeed * Time.deltaTime;
            XpBarInner.fillAmount = Mathf.Clamp01(currentFill);
            yield return null;
        }

        XpBarInner.fillAmount = targetFill;
    }

    public void addXP(){
        xp += 50;
    }

    public void calculateAllXPNeededForLevelUp(){
        if (level == 1){
            allXPForLevelUP = xpForLevel_2;
        }
        if (level == 2){
            allXPForLevelUP = xpForLevel_3;
        }
        if (level == 3){
            allXPForLevelUP = xpForLevel_4;
        }
    }

    public void managePlayerLevel(){
        if (xp <= xpForLevel_3 && xp >= xpForLevel_2 && level != 2){
            level = 2;
            leveledUP = true;
        }
        else if (xp <= xpForLevel_4 && xp >= xpForLevel_3 && level != 3){
            level = 3;
            leveledUP = true;
        }
    }

    private int xpForLevel_2 = 50;
    private int xpForLevel_3 = 150;
    private int xpForLevel_4 = 250;
    private int xpForLevel_5 = 350;
}
