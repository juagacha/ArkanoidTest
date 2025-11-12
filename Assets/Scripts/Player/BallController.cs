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
    private bool ballIsActive = false;
    private Vector3 ballPosition;
    private Vector3 ballInitialForce;
    [SerializeField] private AudioClip sfxPaddleHit;
    [SerializeField] private GameObject LevelController;
    private LevelController levelcont;



    void Start()
    {
        gameObject.transform.SetParent(paddle);
        playerInput = GetComponentInParent<PlayerInput>();
        if (playerInput == null) { Debug.LogError("PlayerInput not found!"); }
        rb = GetComponent<Rigidbody>();
        if (rb == null) { Debug.LogError("Rigidbody not found!"); }
        levelcont = LevelController.GetComponent<LevelController>();
        if (rb == null) { Debug.LogError("LevelController not found!"); }
        GameManager.Instance.SetNewLife(true);
        ballIsActive = false;
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
            if (sfxPaddleHit != null)
            {
                AudioManager.Instance.PlaySFX(sfxPaddleHit);
            }
            Vector3 directionImpact = collision.relativeVelocity;
            directionImpact = CheckLowDirection(directionImpact);
            directionImpact.x *= -2;
            directionImpact.z *= 2;
            rb.AddForce(directionImpact, ForceMode.Impulse);
        }

    }

    private void OnEnable()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            this.gameObject.SetActive(false);
            rb.linearVelocity = Vector3.zero;
            rb.rotation = Quaternion.identity;
            
            rb.Sleep();
            levelcont.BallWasDestroyed(1);
            if (levelcont.GetNumberOfLives()!=0)
            {
                GameManager.Instance.SetNewLife(true);
                //rb.WakeUp();
                gameObject.transform.SetParent(paddle);
                rb.transform.localScale = new Vector3(0.5f, 2f, 2f);
                transform.localPosition = startPosition;
                this.gameObject.SetActive(true);
            }
            Debug.LogError("Game Over");
        }
    }

    private void ResetBall() 
    {
        //rb.linearVelocity = Vector3.zero;
        //rb.rotation = Quaternion.identity;
        //rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.WakeUp();
    }

    private void OnCollisionExit(Collision other) 
    {
        //aplicar aceleracion al salir de una colision
        var velocity = rb.linearVelocity;
        velocity += velocity.normalized * 5f;
        rb.linearVelocity =  CheckLowDirection(velocity);
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
    /// <summary>
    ///genera direccion de fuerza inicial aleatoria por ahora fija
    /// <summary>
    private Vector3 RandominitialForce() 
    {
        ballInitialForce = new Vector3(10f, 0f, 20f);
        return ballInitialForce;
    }

    /// <summary>
    ///Si la velocidad de impacto es muy baja la aumenta, para aumentar la velocidad
    /// <summary>
    private Vector3 CheckLowDirection(Vector3 velocity) 
    {
        /*if (dir.x < 10 && dir.x >= 0) { dir.x += 1; }
        if (dir.x > -10 && dir.x < 0) { dir.x += -1; }
        if (dir.z < 1) { dir.z += 1; }
        return dir;*/

        if (Vector3.Dot(velocity.normalized, Vector3.forward) < 0.1f)
        {
            velocity += velocity.z > 0 ? Vector3.forward * 3f : Vector3.back * 4f;
        }

        if (velocity.magnitude > 20.0f)
        {
            velocity = velocity.normalized * 20.0f;
        }


        return velocity;

    }




}
