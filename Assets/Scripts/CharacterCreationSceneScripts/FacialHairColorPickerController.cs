using UnityEngine;
using UnityEngine.UI;

public class FacialHairColorPickerController : MonoBehaviour
{
    public Image colorPreview;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    private Color selectedColor;

    public GameObject entity;
    public GameObject facialHairObject;

    private void Start()
    {
        redSlider.onValueChanged.AddListener(UpdateColor);
        greenSlider.onValueChanged.AddListener(UpdateColor);
        blueSlider.onValueChanged.AddListener(UpdateColor);

        int randomRed = UnityEngine.Random.Range(0,255);
        int randomGreen = UnityEngine.Random.Range(0,255);
        int randomBlue = UnityEngine.Random.Range(0,255);
        selectedColor = new Color(randomRed / 255f, randomGreen / 255f, randomBlue / 255f, 1f);

        // Set the sliders to match the initial color.
        redSlider.value = randomRed;
        greenSlider.value = randomGreen;
        blueSlider.value = randomBlue;

        // Set the color preview to the initial color.
        colorPreview.color = selectedColor;
    }

    private void UpdateColor(float value)
    {
        // Update the selectedColor based on the slider values.
        selectedColor = new Color(redSlider.value/ 255f, greenSlider.value/ 255f, blueSlider.value/ 255f, selectedColor.a);
        
        // Update the color preview.
        colorPreview.color = selectedColor;

        ChangeHairColor();
    }

    public void ConfirmColorSelection()
    {
        // Use the selected color in your game logic.
        Debug.Log("Selected Color: " + selectedColor);
    }

    private void ChangeHairColor(){
        facialHairObject.GetComponent<SpriteRenderer>().color = selectedColor;
    }
}
