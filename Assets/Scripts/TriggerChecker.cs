using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    //script for checking if the player has entered the trigger area of the object.
    bool isAlreadyCollected = false;
    private void OnTriggerEnter(Collider other)
    {
        if (isAlreadyCollected) return;
        if (other.CompareTag("Player"))
        {
            StackMechanic stackm;
            if(other.TryGetComponent(out stackm))
            {
                stackm.AddNewItem(this.transform);
                isAlreadyCollected = true;
            }
        }
    }


}
