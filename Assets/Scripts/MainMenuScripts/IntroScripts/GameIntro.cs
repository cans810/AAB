using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameIntro : MonoBehaviour
{
    public GameObject inspiredBy;
    public GameObject agameby;
    
    // Start is called before the first frame update
    void Start()
    {
        inspiredBy.SetActive(true);
        agameby.SetActive(false);
    }
}
