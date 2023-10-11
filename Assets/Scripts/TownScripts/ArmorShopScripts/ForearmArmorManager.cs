using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForearmArmorManager : MonoBehaviour
{
    public static ForearmArmorManager Instance { get; private set; }

    public List<Item> foreArmArmors = new List<Item>();

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

