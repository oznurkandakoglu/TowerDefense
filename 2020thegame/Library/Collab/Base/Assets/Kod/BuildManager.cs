﻿using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogError ("More than one BuildManager in scene.");
            return;
        }
        instance = this;
    }

    public GameObject syringeTurretPrefab;

    void Start() 
    {
        turretToBuild = syringeTurretPrefab;    
    }
    private GameObject turretToBuild;

    public GameObject GetTurretToBuild () 
    { 
        return turretToBuild;
    }
}
