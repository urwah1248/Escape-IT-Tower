using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public int NumberOfRopes;
    public GameObject fireExtinguisherModel;
    public GameObject ropeModel;
    public GameObject fire;
    public Text PickupText;
    [SerializeField] Text RopesText;
    public bool AxePickedup;
    public bool ExtinguisherPickedup;
    [SerializeField] Transform AxePosition;
    [SerializeField] Quaternion AxeRotation;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Rope")
        {
            PickupText.gameObject.SetActive(true);
            PickupText.text = "Press E to pickup";
            if (Input.GetKeyUp(KeyCode.E))
            {
                ItemPickup(other);
            }
        }
        
        if(other.tag == "Axe")
        {
            PickupText.gameObject.SetActive(true);
            PickupText.text = "Press E to pickup";
            if (Input.GetKeyUp(KeyCode.E))
            {
                AxePickup(other);
            }
        }

        if(other.tag == "FireExtinguisher")
        {
            PickupText.gameObject.SetActive(true);
            PickupText.text = "Press E to pickup";
            if (Input.GetKeyUp(KeyCode.E))
            {
                ExtinguisherPickup(other);
            }
        }

        if(other.tag == "Fire")
        {
            if(ExtinguisherPickedup)
            {
                PickupText.gameObject.SetActive(true);
                PickupText.text = "Press F to Extinguish";
                if (Input.GetKeyUp(KeyCode.F))
                {
                    ExtinguishFire();
                }
            }
            else
            {
                PickupText.gameObject.SetActive(true);
                PickupText.text = "Need to put out this fire.";
            }
        }
    }

    private void OnTriggerEnter(Collider collider){
        if(collider.tag == "Finish"){
            SceneManager.LoadScene("EndScene");
        }
    }

    public void numberOfRopes()
    {
        RopesText.text = "Number Of Ropes = " + NumberOfRopes;
    }

    void ItemPickup(Collider item)
    {
        NumberOfRopes++;
        ropeModel.SetActive(true);
        PickupText.gameObject.SetActive(false);
        Destroy(item.gameObject);
        Debug.Log("rope");
        RopesText.text = "Picked up Rope";
    }
    
    void AxePickup(Collider item)
    {
        AxePickedup = true;
        PickupText.gameObject.SetActive(false);
        item.gameObject.transform.parent = AxePosition;
        item.gameObject.transform.position = AxePosition.position;
        item.gameObject.transform.localRotation = AxeRotation;
        item.gameObject.GetComponent<Rigidbody>().useGravity = false;
        item.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log("Axe");
        RopesText.text = "Picked up Axe";
    }
    void ExtinguisherPickup(Collider item)
    {
        ExtinguisherPickedup = true;
        fireExtinguisherModel.SetActive(true);
        PickupText.gameObject.SetActive(false);
        RopesText.text = "Picked up Fire Extinguisher";
        item.gameObject.SetActive(false);
    }

    void ExtinguishFire()
    {
        if(ExtinguisherPickedup){
            Destroy(fire);
            ExtinguisherPickedup = false;
            fireExtinguisherModel.SetActive(false);
        RopesText.text = "Well done, Go Ahead now.";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickupText.gameObject.SetActive(false);
    }
}
