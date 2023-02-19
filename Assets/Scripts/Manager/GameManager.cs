using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmazingAssets.CurvedWorld;

public class GameManager : MonoBehaviour
{
    public static GameManager Ins;
    public PlayerController PlayerController;
    public RoadManager RoadManager;
    public UIManager UIManager;
    public ForceManager ForceManager;
    public Asset assetD;
    public CurvedWorldController CurveController;

    private bool _isPlaying = false;

    public bool IsPlaying { get { return _isPlaying; } set { _isPlaying = value; } }

    #region singleton
    private void Awake()
    {
        Ins = this;
        Application.targetFrameRate = 400;
        QualitySettings.vSyncCount = 0;
    }
    #endregion

    #region
    public int CurrentLane;
    #endregion

    #region Manager
    [HideInInspector] public float Speed = 10;
    #endregion
}
