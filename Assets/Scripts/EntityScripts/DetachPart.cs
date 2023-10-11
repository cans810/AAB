using UnityEngine;

public class DetachPart : MonoBehaviour
{
    public GameObject detachedHeadBonePrefab;
    public Transform headDetachPoint; // The point where the detached head will be instantiated.
    public GameObject detachedHeadObjectPrefab;
    public Transform headDetachObjectPoint; // The point where the detached head will be instantiated.
    private bool isDetached = false;
    GameObject detachedBoneHead;
    GameObject detachedObjectHead;

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
    public void AttachHead_Death_1(){
        if (isDetached){
            detachedHeadBonePrefab.SetActive(true);
            detachedHeadObjectPrefab.SetActive(true);
            isDetached = false;
            Destroy(detachedBoneHead);
        }
    }
}