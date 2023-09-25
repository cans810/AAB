using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour
{
    public Button button;
    public Color wantedColor;
    private Color originialColor;
    private ColorBlock cb;

    // Start is called before the first frame update
    void Start()
    {
        cb = button.colors;
        originialColor = cb.selectedColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeWhenHover(){
        cb.selectedColor = wantedColor;
        button.colors = cb;
    }

    public void changeWhenLeaves(){
        cb.selectedColor = originialColor;
        button.colors = cb;
    }
}
