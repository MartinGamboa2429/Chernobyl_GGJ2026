
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;


public class ContaminatedBox : MonoBehaviour, IInteractable
{
    
    [SerializeField] private float _contaminationAmount;
    [SerializeField] Collider _hitBox;
    [SerializeField] private int _init = 0;
    private float _interactorPower = 0;
    private State _currentState;
    private bool cleanned = false;
    private int _interactorSuit = -1;

    public float GetInteractorPower()
    {
        return _interactorPower;
    }
    public int GetInteractorSuit()
    {
        return _interactorSuit;
    }
    void Start()
    {
        if(_init == 0){_currentState = new ContaminatedState(_contaminationAmount,_hitBox, this);}
        else if (_init == 1) {_currentState = new ContaminatedState(_contaminationAmount,_hitBox, this);}
        
    }
    public void SetState(State state)
    {
        _currentState = state;
    }
    public void Interact(Interactor interactor)
    {
        Debug.Log("BOX INTERACT");
        if (cleanned) return;
        if (_interactorPower == 0)
        {
            _interactorPower = interactor.GetPower();
        }
        _contaminationAmount -= _interactorPower;
        _currentState.Interact();
        
    }
    public void ChangeState()
    {
        cleanned = true;
        _hitBox.enabled = false;
        //cambiar textura
    }    
}
