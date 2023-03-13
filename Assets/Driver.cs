using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    private float rotationSpeed = 250f;
    private float moveSpeed = 20f;
    private float slowedMoveSpeed = 10f;
    private float boostedMoveSpeed = 40f;
    private float currentMoveSpeed = 20f;

    private bool isBoosted = false;
    private bool isSlowed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.tag)
        {
            case "Boost":
                this.isBoosted = true;
                this.currentMoveSpeed = this.boostedMoveSpeed;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Road")
        {
            this.isSlowed = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Road":
                this.isSlowed = false;
                break;
            case "Boost":
                this.isBoosted = true;
                break;
            default:
                this.isSlowed = true;
                break;
        }
    }

    private void Update()
    {
        if (this.currentMoveSpeed < this.moveSpeed && this.currentMoveSpeed > this.slowedMoveSpeed)
        {
            this.isSlowed = false;
            this.isBoosted = false;
        }

        this.SetCurrentMoveSpeed();

        var rotationAmount = -Input.GetAxis("Horizontal") * this.rotationSpeed * Time.deltaTime;
        var moveAmount = Input.GetAxis("Vertical") * this.currentMoveSpeed * Time.deltaTime;

        if (moveAmount != 0)
        {
            this.transform.Rotate(new Vector3(0, 0, rotationAmount));
        }
        
        this.transform.Translate(new Vector2(0, moveAmount));
    }

    private void SetCurrentMoveSpeed()
    {
        if (this.isBoosted)
        {
            var slowDownSpeed = this.isSlowed ? 20 : 10;
            this.currentMoveSpeed -= slowDownSpeed * Time.deltaTime;
        }
        else if (this.isSlowed)
        {
            this.currentMoveSpeed = this.slowedMoveSpeed;
        }
        else
        {
            this.currentMoveSpeed = this.moveSpeed;
        }
    }
}
