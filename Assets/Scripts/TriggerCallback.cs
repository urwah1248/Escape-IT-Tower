using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCallback : MonoBehaviour
{
    public Collider Fence;
    public Collider Glass;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Fence")
        {
            FindObjectOfType<RopeAttachment>().RopeStart = other.GetComponent<FenceScript>().RopeStart;
            FindObjectOfType<RopeAttachment>().RopeEnd = other.GetComponent<FenceScript>().RopeEnd;
            FindObjectOfType<RopeAttachment>().collided = true;
            Fence = other.GetComponent<Collider>();
        }
        
        if (other.tag == "Glass")
        {
            Glass = other;
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
        if (other.tag == "Glass")
        {
            Glass = null;
        }
    }
}
