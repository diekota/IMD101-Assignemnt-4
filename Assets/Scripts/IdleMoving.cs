using UnityEngine;
using Unity.VisualScripting;

public class IdleMoving : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
}
