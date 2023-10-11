using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmArmorManager : MonoBehaviour
{
    public static ArmArmorManager Instance { get; private set; }

    public List<Item> armArmors = new List<Item>();

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
