using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    private float _horizontalInput;
    private float _verticalInput;
    private float _inBoundLeft = -27.8356f;
    private float _inBoundRight = -3.4842f;
    [SerializeField] private float _permaZAxis = -.43f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        playerZAxis();
    }

    void playerMovement()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * _horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * _verticalInput * _speed * Time.deltaTime);

        if (transform.position.x > _inBoundRight)
        {
            transform.position = new Vector3(_inBoundRight, transform.position.y, transform.position.z);
        }

        else if (transform.position.x < _inBoundLeft)
        {
            transform.position = new Vector3(_inBoundLeft, transform.position.y, transform.position.z);

        }

        
    }

    void playerZAxis()
    {
        if (transform.position.z != _permaZAxis)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _permaZAxis);
        }
    }
}
