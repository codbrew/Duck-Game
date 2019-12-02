
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Transform rightBound;
    public Transform LeftBound;
    void FixedUpdate()
    {
        //Vector3 desiredPosition = transform.position = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        //transform.position = smoothedPosition;

        transform.position = new Vector3(target.position.x,
        transform.position.y, transform.position.z);
        if(transform.position.x >= rightBound.position.x)
        {
            print(true);
            transform.position = new Vector3(rightBound.position.x, transform.position.y, transform.position.z);
        }
        if(transform.position.x <= LeftBound.position.x)
        {
            transform.position = new Vector3(LeftBound.position.x, transform.position.y, transform.position.z);
        }
    }
    
}
