using UnityEngine.UI;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int NumberOfRopes;
    public Text PickupText;
    [SerializeField] Text RopesText;

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

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Rope")
        {
            PickupText.gameObject.SetActive(false);
        }
    }
}
