using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public int NumberOfRopes;
    public Text PickupText;
    [SerializeField] Text RopesText;
    public bool AxePickedup;
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
        PickupText.gameObject.SetActive(false);
        Destroy(item.gameObject);
        Debug.Log("rope");
        RopesText.text = "Number Of Ropes = " + NumberOfRopes;
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
        RopesText.text = "Number Of Ropes = " + NumberOfRopes;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Rope")
        {
            PickupText.gameObject.SetActive(false);
        }
    }
}
