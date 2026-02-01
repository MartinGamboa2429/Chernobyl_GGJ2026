using System;
using UnityEngine;


public class PlayerController : MonoBehaviour {
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    private Vector3 _input;
    [SerializeField] private GameObject _acivationBox;
    [SerializeField] private Interactor _interactor;
    [SerializeField] private GameTimer _timer;

    private void Update() {
        GatherInput();
        Look();
        if (Input.GetMouseButton(0))
        {
            _acivationBox.SetActive(true);
            //Debug.Log("Deberia Prenderse");
        }
        else
        {
            _acivationBox.SetActive(false);
        }
        
    }

    private void FixedUpdate() {
        Move();
    }

    private void GatherInput() {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look() {
        if (_input == Vector3.zero) return;

        var toIso = _input.ToIso();
        var rot = Quaternion.LookRotation(toIso, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void Move() {
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mask0"))
        {
            _interactor.ChangeSuit(0);
        }
        if (other.gameObject.CompareTag("Mask1"))
        {
            _interactor.ChangeSuit(1);
        }
        if (other.gameObject.CompareTag("Safezone"))
        {
            _timer.ReiniciarContador();
        }
    }

}
