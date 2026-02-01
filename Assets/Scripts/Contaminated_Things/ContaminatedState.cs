using UnityEngine;

public class ContaminatedState : State
{
    private float _contaminationAmount;
    private Collider _hitBox;
    private float _interactorPower = 0;
    private ContaminatedBox _context;
    private BarraDeLimpieza _barra;
    public ContaminatedState(float amount, Collider hitbox, ContaminatedBox context) 
    {
        _contaminationAmount = amount;
        _hitBox = hitbox;
        _context = context;
        _barra = _context.GetBarra();
        _barra.SetMaxFill(_contaminationAmount);
    }

    public override void Interact()
    {
        if(_context.GetInteractorSuit() != 0) return;
        if (_interactorPower == 0)
        {
            _interactorPower = _context.GetInteractorPower();
        }
        _contaminationAmount -= _interactorPower;
        _barra.RemoveClean(_interactorPower);
        Debug.Log($"SE ESTA LIMPIANDO! QUEDA " +_contaminationAmount);
        if (_contaminationAmount <= 0)
        {
            Debug.Log($"SE Limpió ");
            _context.ChangeState();
        }
        
    }

}
