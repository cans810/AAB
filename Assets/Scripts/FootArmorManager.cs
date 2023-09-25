using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootArmorManager : MonoBehaviour
{
    public static FootArmorManager Instance { get; private set; }

    public List<Item> footArmors = new List<Item>();

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

