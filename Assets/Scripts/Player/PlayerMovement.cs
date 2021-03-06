using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public Camera mainCamera;

    public float speed = 5.00f;
    public float turnSmoothTime = 0.1f;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0.0f , vertical).normalized;
        
        transform.position = new Vector3 (transform.position.x, 1, transform.position.z);

        if (direction.magnitude >= 0.1f)
        {
            characterController.Move(direction * speed * Time.deltaTime);
        }
        RotatePlayerToMouse();
    }

    void RotatePlayerToMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit))
        {
            Vector3 previousEulerAngles = transform.eulerAngles;
            transform.LookAt(raycastHit.point);
            transform.eulerAngles = new Vector3(previousEulerAngles.x, transform.eulerAngles.y, previousEulerAngles.z);
        }
    }
}
