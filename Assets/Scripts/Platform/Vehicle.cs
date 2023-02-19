using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : Vatthe
{
    private void Update()
    {
        transform.position -= new Vector3(0, 0, .1f);
    }
    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }*/
}
