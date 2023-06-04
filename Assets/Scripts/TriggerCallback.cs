using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCallback : MonoBehaviour
{
    public Collider Fence;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Fence")
        {
            FindObjectOfType<RopeAttachment>().RopeStart = other.GetComponent<FenceScript>().RopeStart;
            FindObjectOfType<RopeAttachment>().RopeEnd = other.GetComponent<FenceScript>().RopeEnd;
            FindObjectOfType<RopeAttachment>().collided = true;
            Fence = other.GetComponent<Collider>();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Fence")
        {
            FindObjectOfType<RopeAttachment>().collided = false;
            FindObjectOfType<PlayerBehaviour>().PickupText.gameObject.SetActive(false);
            //Fence = null;
            //FindObjectOfType<RopeAttachment>().RopeStart = null;
        }
    }
}
