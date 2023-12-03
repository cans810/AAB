using UnityEngine;

public class DetachPart : MonoBehaviour
{
    public GameObject detachedHeadBonePrefab;
    public Transform headDetachPoint; // The point where the detached head will be instantiated.
    public GameObject detachedHeadObjectPrefab;
    public Transform headDetachObjectPoint; // The point where the detached head will be instantiated.
    private bool isDetached = false;
    private bool isDetachedRightArm = false;
    GameObject detachedBoneHead;
    GameObject detachedObjectHead;

    public GameObject detachedRightArmBonePrefab;
    public GameObject detachedRightArmObjectPrefab;

    public GameObject detachedRightForeArmBonePrefab;
    public GameObject detachedRightForeArmObjectPrefab;
    public GameObject detachedRightForeArmArmorObjectPrefab;

    // Call this method when you want to trigger the detachment effect.
    public void DetachHead_Death_1()
    {
        if (!isDetached)
        {
            // Play the detachment animation here if needed.
            
            // Instantiate the detached head prefab.
            GameObject headPartsContainer = new GameObject("Head Parts");

            detachedBoneHead = Instantiate(detachedHeadBonePrefab, headDetachPoint.position, Quaternion.identity);

            detachedObjectHead = new GameObject("DetachedHeadObject");
            detachedObjectHead.AddComponent<SpriteRenderer>();
            detachedObjectHead.GetComponent<SpriteRenderer>().sprite = detachedHeadObjectPrefab.GetComponent<SpriteRenderer>().sprite;
            detachedObjectHead.GetComponent<SpriteRenderer>().color = detachedHeadObjectPrefab.GetComponent<SpriteRenderer>().color;

            detachedBoneHead.transform.SetParent(headPartsContainer.transform);
            detachedObjectHead.transform.SetParent(headPartsContainer.transform);

            detachedBoneHead.transform.localScale = gameObject.transform.localScale;
            detachedBoneHead.transform.rotation = detachedHeadBonePrefab.transform.rotation;

            if (gameObject.tag.Equals("Player")){
                if (gameObject.GetComponent<ActionsManager>().side.Equals("left")){
                    detachedObjectHead.transform.localScale = gameObject.transform.localScale;
                    detachedObjectHead.transform.rotation = Quaternion.Euler(0,0,89);
                    

                    detachedObjectHead.transform.position = new Vector3(detachedBoneHead.transform.position.x*109/100, detachedBoneHead.transform.position.y, detachedBoneHead.transform.position.z);
                }
                else if (gameObject.GetComponent<ActionsManager>().side.Equals("right")){
                    detachedObjectHead.transform.localScale = gameObject.transform.localScale;
                    detachedObjectHead.transform.rotation = Quaternion.Euler(0,0,-89);
                    

                    detachedObjectHead.transform.position = new Vector3(detachedBoneHead.transform.position.x*109/100, detachedBoneHead.transform.position.y, detachedBoneHead.transform.position.z);
                }
            }

            else if (gameObject.tag.Equals("Enemy")){
                if (gameObject.GetComponent<EnemyActionsManager>().side.Equals("left")){
                    detachedObjectHead.transform.localScale = gameObject.transform.localScale;
                    detachedObjectHead.transform.rotation = Quaternion.Euler(0,0,89);

                    detachedObjectHead.transform.position = new Vector3(detachedBoneHead.transform.position.x*109/100, detachedBoneHead.transform.position.y, detachedBoneHead.transform.position.z);
                }
                else if (gameObject.GetComponent<EnemyActionsManager>().side.Equals("right")){
                    detachedObjectHead.transform.localScale = gameObject.transform.localScale;
                    detachedObjectHead.transform.rotation = Quaternion.Euler(0,0,-89);
                    
                    detachedObjectHead.transform.position = new Vector3(detachedBoneHead.transform.position.x*109/100, detachedBoneHead.transform.position.y, detachedBoneHead.transform.position.z);
                }
            }

            detachedHeadBonePrefab.SetActive(false);
            detachedHeadObjectPrefab.SetActive(false);
            
            isDetached = true;
        }
    }

    public void DetachArm()
    {
        if (!isDetachedRightArm)
        {
            GameObject detachedRightArmObject = new GameObject("(detached)right_arm");
            
            detachedRightArmObject.transform.SetParent(gameObject.transform);
            detachedRightArmObject.transform.localPosition = new Vector3(1.47f,2.06f,0);
            detachedRightArmObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -278.373f));
            detachedRightArmObject.transform.localScale = detachedRightArmBonePrefab.transform.localScale;

            detachedRightArmObject.AddComponent<SpriteRenderer>();

            // Copy the SpriteRenderer component from the original to the new object.
            SpriteRenderer originalRenderer = detachedRightArmObjectPrefab.GetComponent<SpriteRenderer>();
            SpriteRenderer newRenderer = detachedRightArmObject.GetComponent<SpriteRenderer>();

            if (originalRenderer != null && newRenderer != null)
            {
                newRenderer.sprite = originalRenderer.sprite;
                newRenderer.color = originalRenderer.color;
                newRenderer.sortingLayerName = "ui";
            }

            detachedRightArmObjectPrefab.SetActive(false);
            detachedRightArmBonePrefab.SetActive(false);

            GameObject detachedRightForeArmObject = new GameObject("(detached)right_forearm");
            GameObject detachedRightForeArmBoneObject = new GameObject("(detached)right_forearmbone");
            GameObject detachedRightForeArmArmorObject = new GameObject("(detached)right_forearmarmor");

            detachedRightForeArmObject.transform.SetParent(gameObject.transform);
            detachedRightForeArmObject.transform.localPosition = new Vector3(3.08f,1.89f,0);
            detachedRightForeArmObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -272.373f));
            detachedRightForeArmObject.transform.localScale = detachedRightForeArmBonePrefab.transform.localScale;

            detachedRightForeArmObject.AddComponent<SpriteRenderer>();

            // Copy the SpriteRenderer component from the original to the new object.
            SpriteRenderer originalRenderer2 = detachedRightForeArmObjectPrefab.GetComponent<SpriteRenderer>();
            SpriteRenderer newRenderer2 = detachedRightForeArmObject.GetComponent<SpriteRenderer>();

            if (originalRenderer2 != null && newRenderer2 != null)
            {
                newRenderer2.sprite = originalRenderer2.sprite;
                newRenderer2.color = originalRenderer2.color;
                newRenderer2.sortingLayerName = "ui";
            }

            detachedRightForeArmBoneObject.transform.SetParent(gameObject.transform);
            detachedRightForeArmBoneObject.transform.localPosition = new Vector3(3.08f,1.89f,0);
            detachedRightForeArmBoneObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -272.373f));
            detachedRightForeArmBoneObject.transform.localScale = detachedRightForeArmBonePrefab.transform.localScale;

            detachedRightForeArmBoneObject.AddComponent<SpriteRenderer>();

            // Copy the SpriteRenderer component from the original to the new object.
            SpriteRenderer originalRenderer3 = detachedRightForeArmBonePrefab.GetComponent<SpriteRenderer>();
            SpriteRenderer newRenderer3 = detachedRightForeArmBoneObject.GetComponent<SpriteRenderer>();

            if (originalRenderer3 != null && newRenderer3 != null)
            {
                newRenderer3.sprite = originalRenderer3.sprite;
                newRenderer3.color = originalRenderer3.color;
                newRenderer3.sortingLayerName = "ui";
            }

            detachedRightForeArmArmorObject.transform.SetParent(gameObject.transform);
            detachedRightForeArmArmorObject.transform.localPosition = new Vector3(2.98f,1.89f,0);
            detachedRightForeArmArmorObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -272.373f));
            detachedRightForeArmArmorObject.transform.localScale = detachedRightForeArmArmorObjectPrefab.transform.localScale;

            detachedRightForeArmArmorObject.AddComponent<SpriteRenderer>();

            // Copy the SpriteRenderer component from the original to the new object.
            SpriteRenderer originalRenderer4 = detachedRightForeArmArmorObjectPrefab.GetComponent<SpriteRenderer>();
            SpriteRenderer newRenderer4 = detachedRightForeArmArmorObject.GetComponent<SpriteRenderer>();

            if (originalRenderer4 != null && newRenderer4 != null)
            {
                newRenderer4.sprite = originalRenderer4.sprite;
                newRenderer4.color = originalRenderer4.color;
                newRenderer4.sortingLayerName = "ui";
                newRenderer4.sortingOrder = 10;
            }

            detachedRightForeArmObjectPrefab.SetActive(false);
            detachedRightForeArmBonePrefab.SetActive(false);

            isDetachedRightArm = true;
        }
    }

    public void AttachHead_Death_1(){
        if (isDetached){
            detachedHeadBonePrefab.SetActive(true);
            detachedHeadObjectPrefab.SetActive(true);
            isDetached = false;
            Destroy(detachedBoneHead);
        }
    }
}