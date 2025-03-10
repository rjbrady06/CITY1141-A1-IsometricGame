using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _turnSpeed = 360;
    [SerializeField] private Animator _animator;

    private Vector3 _input;

    void Start()
    {
        _animator = GetComponent<Animator>();   
    } 
    void Update()
    {
        GatherInput();
        Look();
    } 

    void FixedUpdate()
    {
        Move();
    }

    void GatherInput()
   {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
   }

    void Look()
    {
        if (_input != Vector3.zero)
        {
            _animator.SetBool("isMoving?" , true);
            Quaternion toRotation = Quaternion.LookRotation(_input, Vector3.up);
            

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation , _turnSpeed * Time.deltaTime);
        }
        else
        {
            _animator.SetBool("isMoving?" , false);
        }
    }

    void Move()
    {
        _rb.MovePosition(transform.position + (transform.forward * _input.magnitude)* _speed * Time.deltaTime);
    }

    
   
}
