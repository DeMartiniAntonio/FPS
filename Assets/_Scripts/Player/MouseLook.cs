using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    private float rotationX = 0f;
    private float rotationY = 0f;
    private int sensitivity = 5;
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX -= mouseY * sensitivity;
        //rotationY += mouseX * sensitivity; 

        rotationX = Mathf.Clamp(rotationX, -90, 90);
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0f);
        playerBody.Rotate(Vector3.up*mouseX);
    }
}
