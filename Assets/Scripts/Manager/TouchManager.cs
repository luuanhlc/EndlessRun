using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    private Vector3 fp; 
    private Vector3 lp;
    private float dragDistance;

    private void Start()
    {
        dragDistance = Screen.width * 15 / 100;
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if( touch.phase == TouchPhase.Moved)
            {
                lp = touch.position;
                
                
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                lp = touch.position;
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {
                        if ((lp.x > fp.x))
                        {
                            Debug.Log("Right swipe");
                            if (GameManager.Ins.CurrentLane != 3)
                            {
                                GameManager.Ins.PlayerController.Turn(GameManager.Ins.CurrentLane, GameManager.Ins.CurrentLane + 1);
                                //SetCurrentLand

                                // idea them mot land dang tren duong den de tinh toan con current lane chi dat khi da o vi tri lane do
                                GameManager.Ins.CurrentLane++;
                                fp = Input.GetTouch(0).position;
                            }
                        }
                        else
                        {
                            Debug.Log("Left swipe");
                            if (GameManager.Ins.CurrentLane != 1)
                            {
                                GameManager.Ins.PlayerController.Turn(GameManager.Ins.CurrentLane, GameManager.Ins.CurrentLane - 1);

                                GameManager.Ins.CurrentLane--;
                                fp = Input.GetTouch(0).position;
                            }
                        }
                    }
                    else
                    {
                        if (lp.y > fp.y)
                        {
                            Debug.Log("Up swipe");
                            if(GameManager.Ins.PlayerController.CanJump)
                                GameManager.Ins.PlayerController.Jump();
                        }
                        else
                        {
                            Debug.Log("Down swipe");

                        }
                    }
                }
                else
                {
                    Debug.Log("Just tap");
                }
            }
        }
    }

    IEnumerator Turn()
    {
        yield return new WaitForSeconds(.1f);
        Debug.Log("Update fp");
    }
}
