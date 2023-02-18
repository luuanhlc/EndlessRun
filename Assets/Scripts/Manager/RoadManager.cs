using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    #region Pooling
    [Header("Pool")]
    [Header("Road")]
    [SerializeField] private GameObject Platform;
    [Header("Pool Parent")]
    [SerializeField] private GameObject Pool;
    [Header("Max Road")]
    [SerializeField] private int poolNumber;

    public int i = 0;

    public List<Flatform> platS;
    #endregion

    private void Awake()
    {
        PoolingObject();
    }

    private void PoolingObject()
    {
        platS = new List<Flatform>();
        for (i = 0; i < poolNumber; i++)
        {
            Flatform temp = Instantiate(Platform, new Vector3(0, 0, 16) * i, Quaternion.identity).GetComponent<Flatform>();
            platS.Add(temp);
        }
    }

    public void SwapPos(GameObject gameObject)
    {
        platS.Remove(gameObject.GetComponent<Flatform>());
        platS.Add(gameObject.GetComponent<Flatform>());
        gameObject.transform.position = new Vector3(0, 0, 16) * i;
        i++;
    }
}
