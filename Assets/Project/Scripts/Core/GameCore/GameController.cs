using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : GameManager
{
    public static GameController Instance;

    [SerializeField] private Transform cameraMain;
    public Transform CameraMain { get => cameraMain; set => cameraMain = value; }

    [SerializeField] private Transform player;
    public Transform Player { get => player; set => player = value; }


    protected override void Awake()
    {
        base.Awake();
        if(Instance == null)
        {
            Instance = this;
        }    
        else
        {
            Destroy(this);
        }
    }

    protected override void LoadComponents()
    {
        loadPrefabs();
    }

    private void loadPrefabs()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cameraMain = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
}
