using UnityEngine;

public class SortingLayerSetter : MonoBehaviour
{
    public int sortingOrderIncrement; // Adjust this value based on your requirements

    public void IncrementSortingOrder()
    {
        // Get all child objects of the current GameObject
        foreach (Transform child in transform)
        {
            // Check if the child has a SpriteRenderer component
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            
            if (spriteRenderer != null)
            {
                // Add the desired amount to the sorting order
                spriteRenderer.sortingOrder += sortingOrderIncrement;
            }

            // Recursively call the method for nested child objects
            IncrementSortingOrderRecursive(child.gameObject);
        }
    }

    private void IncrementSortingOrderRecursive(GameObject obj)
    {
        foreach (Transform child in obj.transform)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder += sortingOrderIncrement;
            }

            IncrementSortingOrderRecursive(child.gameObject);
        }
    }
}
