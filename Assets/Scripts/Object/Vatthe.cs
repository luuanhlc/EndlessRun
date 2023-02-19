using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vatthe : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
