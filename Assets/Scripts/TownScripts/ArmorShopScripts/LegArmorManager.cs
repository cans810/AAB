using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegArmorManager : MonoBehaviour
{
    public static LegArmorManager Instance { get; private set; }

    public List<Item> legArmors = new List<Item>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

