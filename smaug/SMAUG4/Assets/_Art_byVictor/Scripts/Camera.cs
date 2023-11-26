using UnityEngine;

public class Camera : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Speed of camera movement
    public float sensitivity = 2.0f; // Mouse sensitivity for rotation

    private Vector3 lastMousePosition;

    void Update()
    {
        // Camera movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection);

        // Camera rotation
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            transform.Rotate(Vector3.up * delta.x * sensitivity);
            transform.Rotate(Vector3.left * delta.y * sensitivity);
            lastMousePosition = Input.mousePosition;
        }
    }
}
