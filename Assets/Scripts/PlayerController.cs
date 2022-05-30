using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerAnimationController playerAnimationController;

    [SerializeField]
    private GunController gunController;

    [SerializeField]
    private float movementSpeed = 200.0f;

    [SerializeField]
    private float maxSpeed = 10.0f;

    #region Properties

    private const string _MovmentInputHorizontalName = "Horizontal";
    private const string _MovmentInputVerticalName = "Vertical";

    private Vector2 GetPlayerMovementInput => new Vector2(Input.GetAxisRaw(_MovmentInputHorizontalName), Input.GetAxisRaw(_MovmentInputVerticalName));

    private const string _ShooterInputHorizontalName = "Arrows Horizontal";
    private const string _ShooterInputVerticalName = "Arrows Vertical";

    private Vector2 GetPlayerShooterInput => new Vector2(Input.GetAxis(_ShooterInputHorizontalName), Input.GetAxis(_ShooterInputVerticalName));

    #endregion

    private Rigidbody2D rigidbody2D;

    private void OnValidate()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.isKinematic = false;
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    private void OnEnable()
    {        
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovmnetHandler();

        ShooterHandler();
    }

    private void MovmnetHandler()
    {
        Vector2 movInput = GetPlayerMovementInput;

        MoveCharacter(movInput.normalized);

        SetPlayerAnimationDir(movInput.normalized);
    }
    private void MoveCharacter(in Vector2 direction) => rigidbody2D.velocity = Vector2.ClampMagnitude((direction * movementSpeed) * Time.deltaTime, maxSpeed);

    private void ShooterHandler()
    {
        Vector2 shooterInput = GetPlayerShooterInput;

        if (shooterInput != Vector2.zero)
        {            
            gunController.Fire(shooterInput.normalized);
            SetPlayerAnimationDir(shooterInput.normalized);

        }
    }

    #region Animation Handler

    private void SetPlayerAnimationDir(in Vector2 direction) => SetPlayerAnimationDir(direction.y, direction.x);

    private void SetPlayerAnimationDir(in float vertical, in float horizontal) => playerAnimationController.Movement(vertical, horizontal);

    #endregion

    public void Die()
    {       
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        LiteEvents.OnPlayerDeadCallback?.Invoke();
    }
}

