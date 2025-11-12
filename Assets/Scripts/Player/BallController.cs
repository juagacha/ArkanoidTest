using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    PlayerInput playerInput;
    Rigidbody rb;
    [SerializeField] private Transform paddle; 
    [SerializeField] private float speedBall = 5f;
    private Vector3 startPosition = new Vector3(0, 0, 2f); // posicion inicial
    private bool isNewBall;
    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector3 ballInitialForce;


    void Start()
    {
        gameObject.transform.SetParent(paddle);
        playerInput = GetComponentInParent<PlayerInput>();
        if (playerInput == null) { Debug.LogError("PlayerInput not found!"); }
        rb = GetComponent<Rigidbody>();
        if (rb == null) { Debug.LogError("Rigidbody not found!"); }
        ballIsActive = false;
        GameManager.Instance.SetNewLife(true);
        transform.localPosition = startPosition;
    }
        
    void Update()
    {
        Debug.Log(GameManager.Instance.GetNewLife());
        isNewBall = GameManager.Instance.GetNewLife();
        if (isNewBall) {
            LaunchBall();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle")) 
        {
            Vector3 directionImpact = collision.relativeVelocity;
            directionImpact = ChangeLowDirection(directionImpact);
            directionImpact.x *= -2;
            directionImpact.z *= 2;
            rb.AddForce(directionImpact, ForceMode.Impulse);
        }

    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            this.gameObject.SetActive(false);
            GameManager.Instance.SetGameOver();
            Debug.LogError("Game Over");
        }
    }

    private void OnCollisionExit(Collision other) 
    {
        //aplicar aceleracion al salir de una colision
        var velocity = rb.linearVelocity;
        velocity += velocity.normalized * 0.01f;
    }
        

    /// <summary>
    ///  metodo para el impulso inicial de la bola
    /// </summary>
    private void LaunchBall() 
    {
        Debug.Log("is a new ball");
        if (playerInput.actions["Jump"].IsPressed())
        {
            Debug.Log("jump was pressed");
            {
                gameObject.transform.SetParent(null); // desvincula del padre
                if (rb == null) { Debug.LogError("Rigidbody not found!"); }
                else
                {
                    ballInitialForce = RandominitialForce();
                    rb.AddForce(ballInitialForce, ForceMode.Impulse);
                }
                ballIsActive = true;
                GameManager.Instance.SetNewLife(false);
            }
        }
    }
    /// <summary>
    ///genera direccion de fuerza inicial aleatoria por ahora fija
    /// <summary>
    private Vector3 RandominitialForce() 
    {
        ballInitialForce = new Vector3(20f, 0f, 40f);
        return ballInitialForce;
    }

    /// <summary>
    ///Si la velocidad de impacto es muy baja la aumenta, para aumentar la velocidad
    /// <summary>
    private Vector3 ChangeLowDirection(Vector3 dir) 
    {
        if (dir.x < 10 && dir.x >= 0) { dir.x += 1; }
        if (dir.x > -10 && dir.x < 0) { dir.x += -1; }
        if (dir.z < 1) { dir.z += 1; }
        return dir;
    }




}
