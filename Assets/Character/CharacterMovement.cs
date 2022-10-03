using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 10f)]
    private float _speed = 1;
    [SerializeField]
    Rigidbody2D rigid;

    private float _movementX;
    private float _movementY;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        _movementX = Input.GetAxisRaw("Horizontal");
        _movementY = Input.GetAxisRaw("Vertical");

        Vector3 currentPosition = transform.position;

        //transform.position = currentPosition + new Vector3(_movementX, _movementY, 0) * _speed * Time.deltaTime;
        rigid.MovePosition(currentPosition + new Vector3(_movementX, _movementY, 0) * _speed * Time.deltaTime);
    }
}
