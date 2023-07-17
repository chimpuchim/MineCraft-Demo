using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : GameManager, IMoveable
{
    [Header("Set up player movement")]
        [SerializeField] private float speedMovement;


    private CharacterController controller;


    protected override void Start() 
    {
        controller = this.transform.parent.gameObject.GetComponent<CharacterController>();
    }

    private void Update() 
    {
        Movement();    
    }

    protected override void LoadComponents()
    {
        loadValues();
    }

    private void loadValues()
    {
        speedMovement = 5;
    }

    public void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = this.transform.right * x + this.transform.forward * z;
        controller.Move(move * speedMovement * Time.deltaTime);
    }
}
