using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaerInputManager : Singleton<PlaerInputManager>
{
    public Vector2 MovementInput { get; private set; }
    public bool AttackInput { get; private set; }
    public bool DashInput { get; private set; }
    public bool ESCInput { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        MovementInput = Vector2.zero;
        AttackInput = false;
        DashInput = false;
        ESCInput = false;
    }


    public void OnMovement(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInput = true;
        }
        else if (context.canceled)
        {
            AttackInput = false;
        }
    }

    public void UseAttack()
    {
        AttackInput = false;
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DashInput = true;
        }
        else if (context.canceled)
        {
            DashInput = false;
        }
    }

    public void UseDash()
    {
        DashInput = false;
    }

    public void OnESC(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ESCInput = true;
        }
        else if (context.canceled)
        {
            ESCInput = false;
        }
    }

    public void UseESC()
    {
        ESCInput = false;
    }
}
