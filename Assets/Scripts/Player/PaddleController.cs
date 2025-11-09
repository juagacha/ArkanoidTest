using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    PlayerInput playerInput;
    public int paddleSpeed = 5; //velocidad del paddle
    private Vector2 inputs;
    public int zPosition; // cambia en 3d 
    private Vector3 startPosition = new Vector3(0, 0, -13f); // posicion inicial

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        transform.position = startPosition;
    }


    void Update()
    {
        inputs = playerInput.actions["Move"].ReadValue<Vector2>();
        if (inputs != Vector2.zero)
        {
            Vector3 movement = new Vector3(inputs.x, 0, 0).normalized;
            transform.Translate(movement * Time.deltaTime * paddleSpeed);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -26f, 26f), transform.position.y, transform.position.z);
        }
    }
}
