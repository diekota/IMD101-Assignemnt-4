using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // player speed
    [SerializeField] float playerSpeed = 3.0f;

    // x and y movement varaibles
    private float movementX;
    private float movementY;

    // rigidbidy and animator assignment
    private Rigidbody rb;
    private Animator animation;

    // count variable
    private int count;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animation = GetComponent<Animator>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal");
        float yValue = 0f;
        float zValue = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(xValue,yValue,zValue);
        bool isWalking = direction.magnitude > 0;

        animation.SetBool("isMoving", isWalking);

        if (direction.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(direction);
            transform.Translate(direction.normalized * playerSpeed * Time.deltaTime, Space.World);
        }

      
        
    }
}
