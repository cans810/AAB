using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestplateManager : MonoBehaviour
{
    public static ChestplateManager Instance { get; private set; }

    public List<Item> chestplates = new List<Item>();

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
