using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalfArmorManager : MonoBehaviour
{
    public static CalfArmorManager Instance { get; private set; }

    public List<Item> calfArmors = new List<Item>();

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

