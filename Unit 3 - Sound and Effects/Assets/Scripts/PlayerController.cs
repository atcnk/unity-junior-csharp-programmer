using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpSound;   
    [SerializeField] private AudioClip crashSound;

    private AudioSource playerAudio;
    private Rigidbody playerRB;
    private Animator playerAnim;

    private bool isOnGround = true;
    public bool gameOver = false;

    private float jumpForce = 700f;
    private float gravityModifier = 1.5f;

    private void Start()
    {
        GetComponents();

        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            Jump();
        }
    }

    private void Jump()
    {
        playerAudio.PlayOneShot(jumpSound, 1.0f);
        playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        dirtParticle.Stop();
        playerAnim.SetTrigger("Jump_trig");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            dirtParticle.Play();
            Debug.Log("dirtParticle.Play();");
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game over!");
        gameOver = true;
        
        playerAudio.PlayOneShot(crashSound, 1.0f);

        dirtParticle.Stop();
        explosionParticle.Play();
        
        playerAnim.SetInteger("DeathType_int", 1);
        playerAnim.SetBool("Death_b", true);
    }

    private void GetComponents()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }
}
