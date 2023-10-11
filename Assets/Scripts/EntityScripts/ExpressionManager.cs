using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressionManager : MonoBehaviour
{
    public string eyes_state;
    public string mouth_state;

    void Awake() {
        eyes_state = "eyesNormal";
        mouth_state = "mouthNormal";
    }
}
