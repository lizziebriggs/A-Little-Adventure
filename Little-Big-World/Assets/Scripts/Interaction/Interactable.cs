using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // == Interaction Variables ==
    [Header("Interaction")]
    public GameObject popup = null;
    [SerializeField] bool pickupable = false;
    public GameObject toBeInteractedBy = null;


    void Start()
    {
        gameObject.tag = "Interactable";
        popup.SetActive(false);
    }


    public void PickUpItem()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            MarkAsPickedUp();
            Destroy(gameObject);
        }
    }


    public virtual void MarkAsPickedUp() { }


    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            if(other.GetComponent<PlayerController>().isCurrentCharacter)
            {
                popup.SetActive(true);

                if(pickupable && other.gameObject == toBeInteractedBy)
                    PickUpItem();
            }
            else
                popup.SetActive(false);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            popup.SetActive(false);
    }
}
