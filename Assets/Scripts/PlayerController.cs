using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // player speed
    [SerializeField] float playerSpeed = 3.0f;
    [SerializeField] float turnSpeed = 150f;

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
        float turn = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        transform.Rotate(0f, turn * turnSpeed * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * move * playerSpeed * Time.deltaTime);

        animation.SetBool("isMoving", Mathf.Abs(move) > 0.1f);
      
        
    }
}
