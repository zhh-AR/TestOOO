using UnityEngine;

public class CubeKeyboardMouseController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float verticalSpeed = 2f;
    [SerializeField] private float mouseRotateSpeed = 180f;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Awake()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private void Update()
    {
        MoveWithKeyboard();
        RotateWithMouse();
        ResetTransform();
    }

    private void MoveWithKeyboard()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float forward = Input.GetAxisRaw("Vertical");
        float vertical = 0f;

        if (Input.GetKey(KeyCode.E))
        {
            vertical += 1f;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            vertical -= 1f;
        }

        Vector3 movement = new Vector3(horizontal, 0f, forward).normalized * moveSpeed;
        movement.y = vertical * verticalSpeed;

        transform.Translate(movement * Time.deltaTime, Space.World);
    }

    private void RotateWithMouse()
    {
        if (!Input.GetMouseButton(1))
        {
            return;
        }

        float yaw = Input.GetAxis("Mouse X") * mouseRotateSpeed * Time.deltaTime;
        float pitch = -Input.GetAxis("Mouse Y") * mouseRotateSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, yaw, Space.World);
        transform.Rotate(Vector3.right, pitch, Space.Self);
    }

    private void ResetTransform()
    {
        if (!Input.GetKeyDown(KeyCode.R))
        {
            return;
        }

        transform.SetPositionAndRotation(startPosition, startRotation);
    }
}
