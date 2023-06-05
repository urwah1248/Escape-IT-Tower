using UnityEngine;
using UnityEngine.UI;

public class RopeAttachment : MonoBehaviour
{
    [SerializeField] GameObject rope; 
    public GameObject RopeStart; 
    public GameObject RopeEnd; 
    public bool collided;

    [SerializeField] float ropeMultiplier;

    [SerializeField] Text GuideText;

    private void Update()
    {
        if (collided)
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                AttachRope();
            }
            
            if (Input.GetKeyUp(KeyCode.G))
            {
                // DettachRope();
            }
        }

        if (collided)
        {
            bool RopeAttached = FindObjectOfType<TriggerCallback>().Fence.GetComponent<FenceScript>().RopeAttached;

            if (RopeAttached)
            {
                GuideText.gameObject.SetActive(true);
                GuideText.text = "Press G to dettach rope";
            }
            if (!RopeAttached)
            {
                GuideText.gameObject.SetActive(true);
                GuideText.text = "Press F to attach rope";
            }
        }

        if(RopeEnd != null){
            if(RopeEnd.transform != null)
            {
                float distance = Vector3.Distance(transform.position, RopeEnd.transform.position);
                if (FindObjectOfType<PlayerMovementRope>().Attached == true)
                {
                    if (distance < 0.55)
                    {
                        DettachRope();
                    }
                }
            }
        }
    }

    void AttachRope()
    {
        if (FindObjectOfType<PlayerBehaviour>().NumberOfRopes <= 0) { return; }
        if (FindObjectOfType<TriggerCallback>().Fence.GetComponent<FenceScript>().RopeAttached == true) { return; }
        FindObjectOfType<PlayerBehaviour>().NumberOfRopes -= 1;
        FindObjectOfType<PlayerBehaviour>().numberOfRopes();
        FindObjectOfType<TriggerCallback>().Fence.gameObject.GetComponent<FenceScript>().RopeAttached = true;
        GameObject Rope = Instantiate(rope);
        FindObjectOfType<TriggerCallback>().Fence.gameObject.GetComponent<FenceScript>().AttachedRope = Rope;
        Debug.Log(RopeStart);
        Rope.transform.position = RopeStart.transform.position;
        float distance = Vector3.Distance(RopeStart.transform.position, RopeEnd.transform.position);
        distance = distance * ropeMultiplier;
        Rope.transform.localScale = new Vector3(distance/2, distance, distance/2);
        /* Rope.AddComponent<FixedJoint>();
         //FixedJoint.connectedBody = FindObjectOfType<TriggerCallback>().Fence.gameObject.GetComponent<FenceScript>().RopeJoint.gameObject.GetComponent<Rigidbody>();
         Rope.GetComponent<Joint>().connectedBody = FindObjectOfType<TriggerCallback>().Fence.gameObject.GetComponent<FenceScript>().RopeJoint.gameObject.GetComponent<Rigidbody>();*/
    }

    void DettachRope()
    {
        GameObject Rope = FindObjectOfType<TriggerCallback>().Fence.gameObject.GetComponent<FenceScript>().AttachedRope;
        //Destroy(Rope);
        FindObjectOfType<TriggerCallback>().Fence.gameObject.GetComponent<FenceScript>().RopeAttached = false;
        FindObjectOfType<TriggerCallback>().Fence.gameObject.GetComponent<FenceScript>().AttachedRope = null;
        FindObjectOfType<PlayerBehaviour>().NumberOfRopes += 1;
        FindObjectOfType<PlayerBehaviour>().numberOfRopes();
        RopeEnd = null;
        RopeStart = null;
        FindObjectOfType<PlayerMovementRope>().Attached = false;
    }
}
