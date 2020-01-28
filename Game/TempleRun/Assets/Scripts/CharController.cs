using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    private Rigidbody rb;
    private bool walkingRight = true;
    public Transform rayStart; //We are going to run a ray to make sure we are touching the floor
    private Animator anim;
    private GameManager gameManager;
    public GameObject crystalEffect;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if(!gameManager.gameStarted) //If the gameStarted bool is false which it is by default since we havent called the function
        {
            return;
        }
        else
        anim.SetTrigger("gameStarted"); //This plays an animation. We got rid of the exit time on the transition because it would have to wait till the animation of idle was over before it went back to running

        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime; //Forward is the direction he is facing
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Switch();
        }

        RaycastHit hit;

        if(!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity)) //If we are not hitting anything underneath us (floor)
        {
            anim.SetTrigger("isFalling"); //Set the trigger isFalling
        }
        else
        {
            anim.SetTrigger("notFallingAnymore");
        }

        if(transform.position.y < -2)
        {
            gameManager.EndGame();
        }
    }

    private void Switch()
    {
        if(!gameManager.gameStarted) //If the game hasnt started don't allow movement
        {
            return;
        }

        walkingRight = !walkingRight; //Toggle the bool

        if(walkingRight)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0); //Change the direction hes watching 45 degrees. TO NOTE: Our direction of going right is a rotation of 45 degrees
        }
        else
            transform.rotation = Quaternion.Euler(0, -45, 0); //Change the direction hes watching 45 degrees
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Crystal")
        {
            gameManager.IncreaseScore();
            GameObject g = Instantiate(crystalEffect, rayStart.transform.position, Quaternion.identity); //Remember rayStart is our chest position
            Destroy(g, 2);
            Destroy(other.gameObject);
        }
    }
}
