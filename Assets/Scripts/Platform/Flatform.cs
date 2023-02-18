using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flatform : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Ins.RoadManager.SwapPos(this.gameObject);
        }
    }
}
