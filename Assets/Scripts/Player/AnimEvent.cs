using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
    public void RollDone()
    {
        GameManager.Ins.PlayerController.RollDone();
    }
}
