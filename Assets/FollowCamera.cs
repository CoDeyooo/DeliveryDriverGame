using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        this.transform.position = this.objectToFollow.transform.position + new Vector3(0,0,-10);
    }
}
