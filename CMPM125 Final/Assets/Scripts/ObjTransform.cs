using UnityEngine;

public class ObjTransform : MonoBehaviour
{
    // Alternate code to move this object to a new x,y,z location specified in the inspector
    // public Vector3 newPosition;
    // public void MoveTo(){
    //     transform.position = newPosition;
    // }

    // Move this object to another object (likely an empty object)
    public GameObject targetPos;
    private Vector3 originalPosition;

    void Start(){
        originalPosition = transform.position;
    }

    public void MoveToObject(){
        Debug.Log("Moving object to " + targetPos.transform.position);
        transform.position = targetPos.transform.position;
    }

    public void RevertPosition(){
        transform.position = originalPosition;
    }
}
