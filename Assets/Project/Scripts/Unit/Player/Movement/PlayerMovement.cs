using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Unit, IMoveable
{
    private void Update() 
    {
        Moveable();
    }

    public void Moveable()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        
        this.transform.parent.Translate(movement * movementSpeed * Time.deltaTime);
    }
}
