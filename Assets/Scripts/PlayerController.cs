using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class PlayerController : MonoBehaviour
{
    // player speed
    [SerializeField] float playerSpeed = 3.0f;
    [SerializeField] float turnSpeed = 150f;

    // x and y movement varaibles
    private float move;
    private float turn;

    // rigidbidy and animator assignment
    private Rigidbody rb;
    private Animator animation;

    // count variable
    private int count;
    public TextMeshProUGUI countText;

    // sound effect
    public AudioClip pickupSound;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animation = GetComponent<Animator>();
        count = 0;
        SetCountText();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        turn = Input.GetAxis("Horizontal");
        move = Input.GetAxis("Vertical");
        animation.SetBool("isMoving", Mathf.Abs(move) > 0.1f);
      
    }

    void FixedUpdate()
    {
        Quaternion turnBy = Quaternion.Euler(0f, turn * turnSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * turnBy);
        rb.MovePosition(rb.position + transform.forward * move * playerSpeed * Time.fixedDeltaTime);
        rb.angularVelocity = Vector3.zero;
    }

    void SetCountText()
    {
        countText.text = count.ToString() + "/6";
        if (count >= 6)
        {
            SceneManager.LoadScene("Win Scene");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            audioSource.PlayOneShot(pickupSound);
            SetCountText();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Lose Scene");
        }
    }
}
