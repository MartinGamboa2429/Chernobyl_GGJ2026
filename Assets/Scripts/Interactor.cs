using System;
using Unity.VisualScripting;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactorSource;
    [SerializeField] private float _interactRange;
    [SerializeField] private float  _power;
    //[SerializeField] private Collider _acivationBox;
    [SerializeField] private GameObject _acivationBox;

    private int _suit = 0;
    
    public LayerMask _layermask;

    public float GetPower()
    {
        return _power;
    }
    public int GetSuit()
    {
        return _suit;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButton(0))
        // {
        //     _acivationBox.SetActive(true);
        //     //Debug.Log("Deberia Prenderse");
        // }
        // else
        // {
        //     _acivationBox.SetActive(false);
        // } 

        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeSuit(0);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ChangeSuit(1);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Interactor Interact ");
        if (other.gameObject.CompareTag("Contaminated"))
        {
            if (other.TryGetComponent(out IInteractable iteractableObj))
            {
                iteractableObj.Interact(this);      
            }
        }

    }

    public void ChangeSuit(int suit)
    {
        _suit = suit;
        Debug.Log($"Traje cambiado a "+suit);
    }
}

// RaycastHit hit;

//         if (Input.GetMouseButton(0)){
//             //Debug.Log("Mouse Pressed");
//             if (Physics.Raycast(_interactorSource.position, _interactorSource.forward, 
//                 out hit, _interactRange, _layermask))
//             {
//                 if (hit.collider.gameObject.TryGetComponent(out IInteractable iteractableObj))
//                 {
//                     iteractableObj.Interact(this);
//                 }
//                 Debug.DrawLine(_interactorSource.position, hit.point, Color.red );
//                 //Debug.Log("Deberia Dibujar");
//             }
//             else
//             {
//                 Debug.DrawLine(_interactorSource.position, hit.point, Color.green );
//                 //Debug.Log("Deberia ser Verde");
//             }
            
//         }
//         if (Input.GetMouseButton(0))
//         {
//             _acivationBox.SetActive(true);
//             Debug.Log("Deberia Prenderse");
//         }
//         else
//         {
//             _acivationBox.SetActive(false);
//         }   



// [SerializeField] private Transform _interactorSource;
//     [SerializeField] private float _interactRange;

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.E)){
//             Ray ray = new Ray(_interactorSource.position, _interactorSource.forward);
//             if (Physics.Raycast(ray, out RaycastHit hitInfo, _interactRange))
//             {
//                 if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable iteractableObj))
//                 {
//                     iteractableObj.Interact();
//                 }
//             }
//         }
//     }