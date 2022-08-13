using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    VariableJoystick joystick;

    [SerializeField]
    float movementspeed;

    private Camera main_camera;

    [SerializeField]
    float rotationDamping;

    [SerializeField]
    Animator animator;

    void Start()
    {
        main_camera = Camera.main; // cachelemek için, her updatede sürekli camerayý bastan aratmamak için
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = CalculateMovement();

        if(Vector3.Magnitude(movement) < 0.1f) 
        {
            animator.SetBool("isWalking", false);           
        }
        else 
        {
            animator.SetBool("isWalking", true);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * rotationDamping);// Lerp, hareketi smootlastýrmak için.
        }     
        Move(movement*movementspeed);
        
    }

    private void Move(Vector3 motion) //Karakterin hareket ettirmek için
    {
        characterController.Move(motion*Time.deltaTime); //motion*Time.deltaTime da 1 snde 60 frame olduðu i.in onu düþürmek için
    }

    //movement wrt joystick movement
    private Vector3 CalculateMovement() // karakterin ne kadar hareket edeceðini belirlemek için
    {
        Vector3 forward = main_camera.transform.forward; 
        Vector3 right = main_camera.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize(); // scalemek için, büyüklük 1 kalsýn diye
        right.Normalize();

        return forward * joystick.Vertical + right * joystick.Horizontal; // karakterin hareket mesafesi joystickin yönüne baðlanýr
    }
}
