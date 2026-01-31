using UnityEngine;

public class ContaminatedState : State
{
    private float _contaminationAmount;
    private Collider _hitBox;
    private float _interactorPower = 0;
    private ContaminatedBox _context;
    public ContaminatedState(float amount, Collider hitbox, ContaminatedBox context) 
    {
        _contaminationAmount = amount;
        _hitBox = hitbox;
        _context = context;
    }

    public override void Interact()
    {
        if(_context.GetInteractorSuit() != 0) return;
        if (_interactorPower == 0)
        {
            _interactorPower = _context.GetInteractorPower();
        }
        _contaminationAmount -= _interactorPower;
        if (_contaminationAmount <= 0)
        {
            _context.ChangeState();
        }
        
    }

}
