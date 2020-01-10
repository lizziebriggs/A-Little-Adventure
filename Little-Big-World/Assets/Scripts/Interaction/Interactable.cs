using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    // == Interaction Variables ==
    [Header("Interaction")]
    public GameObject interactText = null;
    [SerializeField] private bool pickupable;


    void Start()
    {
        interactText.SetActive(false);
    }


    public void PickUpItem()
    {
        if(Input.GetKeyDown(KeyCode.Return))
            Destroy(gameObject);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            PlayerController interactor = other.GetComponent<PlayerController>();

            if(interactor.isCurrentCharacter)
            {
                interactText.SetActive(true);
                PickUpItem();
            }
            else
                interactText.SetActive(false);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            interactText.SetActive(false);
    }
}
