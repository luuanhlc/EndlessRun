using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VehicleManager : MonoBehaviour
{
    public List<VehicleInfor> vehicle = new List<VehicleInfor>();
    private List<List<GameObject>> pools= new List<List<GameObject>>();

    private List<GameObject> temp = new List<GameObject>();

    private void Awake()
    {
        pool();
    }

    private void pool()
    {
        for(int i = 0; i < vehicle.Count; i++)
        {
            for(int j = 0; j < vehicle[i].Number; j++)
            {
                temp.Add(Instantiate(vehicle[i].vehicle, transform.position, Quaternion.identity));
            }
            pools.Add(temp);
            temp.Clear();
        }
    }


}
[Serializable]
public class VehicleInfor
{
    public GameObject vehicle;
    public int Number;
}
