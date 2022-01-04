using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer Renderer;

    private Material cubeMat;

    private Vector3 scaleValue = new Vector3(0.002f, 0.002f, 0.002f);

    private float rotateRateX = 10f;
    private float rotateRateY = 1f;
    private float rotateRateZ = 4f;

    private float rColor;
    private float gColor;
    private float bColor;

    private float xMove = 1.0f;
    private float yMove = 1.0f;
    private float zMove = 1.0f;

    
    void Start()
    {   
        cubeMat = Renderer.material;
        cubeMat.color = new Color(0.5f, 1.0f, 0.3f, 1f);
    }
    
    void Update()
    {
        Rotate();
        Scale();
        Move();
        Control();
    }

    private void Rotate()
    {
        // Rotates cube
        transform.Rotate(rotateRateX * Time.deltaTime, rotateRateY * Time.deltaTime, rotateRateZ * Time.deltaTime);
    }

    private void Scale()
    {
        // Changes scale of cube
        transform.localScale += scaleValue;
    }

    private void Paint()
    {
        // Paints cube
        cubeMat.color = new Color(rColor, gColor, bColor);
    }

    private void Move()
    {
        // Moves cube
        transform.Translate(new Vector3(xMove, yMove, zMove) * Time.deltaTime);
    }

    private void Control()
    {
        // Generates random rotate, color, position values when cube's scale is more than 3

        if (transform.localScale.x > 3.0f)
        {
            transform.localScale = Vector3.one;

            rotateRateX = Random.Range(0f, 100f);
            rotateRateY = Random.Range(0f, 100f);
            rotateRateZ = Random.Range(0f, 100f);

            rColor = Random.Range(0f, 1f);
            bColor = Random.Range(0f, 1f);
            gColor = Random.Range(0f, 1f);

            xMove = Random.Range(-10f, 10f);
            yMove = Random.Range(-10f, 10f);
            zMove = Random.Range(-10f, 10f);

            transform.position = Vector3.zero;

            Paint();
        }
    }
}
