using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMovement Movement;

    void Start()
    {
        Movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        Movement.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;

        Movement.Rotate(rotation);


        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 camRotation = new Vector3(xRot, 0f, 0f) * lookSensitivity;

        Movement.camRotate(camRotation);
    }
}
