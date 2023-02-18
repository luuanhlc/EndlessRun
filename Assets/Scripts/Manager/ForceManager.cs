using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceManager : MonoBehaviour
{
    private List<GameObject> force = new List<GameObject>();
    [SerializeField] private int maxForceObj;
    [SerializeField] private GameObject poolForceParent;

    private List<GameObject> acctiveForce = new List<GameObject>();

    private void Awake()
    {
        Pool();
    }

    private void Pool()
    {
        for(int i = 0; i < maxForceObj; i++)
        {
            acctiveForce.Add(Instantiate(GameManager.Ins.assetD.force, poolForceParent.transform.position, Quaternion.identity));
        }
    }

    public void poolUnActive(GameObject gameObject)
    {
        gameObject.SetActive(false);
        //acctiveForce.Remove(gameObject);
        force.Add(gameObject);
    }

}
