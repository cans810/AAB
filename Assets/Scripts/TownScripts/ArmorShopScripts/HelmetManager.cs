using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetManager : MonoBehaviour
{
    public static HelmetManager Instance { get; private set; }

    public List<Item> helmets = new List<Item>();

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
