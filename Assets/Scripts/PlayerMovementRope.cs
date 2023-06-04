using StarterAssets;
using UnityEngine;

public class PlayerMovementRope : MonoBehaviour
{
    public bool Attached;
    [SerializeField] float fallSpeed;
    [SerializeField] float ClimbSpeed;

    private void Update()
    {
        Move();
        if(FindObjectOfType<RopeAttachment>().collided == true)
        {
            if(FindObjectOfType<TriggerCallback>().Fence.GetComponent<FenceScript>().RopeAttached == true)
            {
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    AttachToRope();
                }
            }
        }
    }

    void AttachToRope()
    {
        if (Attached) { return; }
        Attached = true;
        Transform RopeStart = FindObjectOfType<TriggerCallback>().Fence.GetComponent<FenceScript>().RopeEnd.transform;
        Vector3 Pos = new Vector3(RopeStart.position.x, 7, RopeStart.position.z);
        transform.position = Pos;
        Vector3 Fence = FindObjectOfType<TriggerCallback>().Fence.GetComponent<FenceScript>().AttachedRope.transform.position;
        transform.position = new Vector3(Fence.x + 0.507824f, Fence.y - 0.4383257f, Fence.z);
        transform.LookAt(FindObjectOfType<TriggerCallback>().Fence.transform);
        transform.rotation = new Quaternion(0, transform.rotation.x, 0, transform.rotation.w);
    }

    void Move()
    {
        if (Attached == false) { return; }
        GameObject RopeStart = GetComponent<RopeAttachment>().RopeStart;
        GameObject RopeEnd = GetComponent<RopeAttachment>().RopeEnd;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            float distance = Vector3.Distance(transform.position, RopeEnd.transform.position);
            if (distance < 0.52) { return; }
            transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed, transform.position.z);
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            float distance = Vector3.Distance(transform.position, RopeStart.transform.position);
            if(distance < 0.52) { return; }
            transform.position = new Vector3(transform.position.x, transform.position.y + ClimbSpeed, transform.position.z);
        }
    }
}
