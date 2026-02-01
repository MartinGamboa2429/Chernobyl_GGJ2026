using UnityEngine;

public class BurningState : State
{
    private float _contaminationAmount;
    private Collider _hitBox;
    private float _interactorPower = 0;
    private ContaminatedBox _context;
    public BurningState(float amount, Collider hitbox, ContaminatedBox context) 
    {
        _contaminationAmount = amount;
        _hitBox = hitbox;
        _context = context;
    }

    public override void Interact()
    {
        if(_context.GetInteractorSuit() != 1) return;
        if (_interactorPower == 0)
        {
            _interactorPower = _context.GetInteractorPower();
        }
        _contaminationAmount -= _interactorPower;
        if (_contaminationAmount <= 0)
        {
            ChangeState();
        }
        
    }
    private void ChangeState()
    {
        _context.SetState(new ContaminatedState(_contaminationAmount*2, _hitBox, _context));
    }

}
