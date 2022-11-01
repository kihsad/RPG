using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace RPG.Units.Player
{
    
    public class PlayerController : MonoBehaviour
    {
        
        private PlayerControls _controls;
        private float _speed = 5f;
        private Rigidbody _rigidBody;

        private void Awake()
        {
            _controls = new PlayerControls();
            _controls.GameMap.FastAttack.performed += OnFastAttack;
            _controls.GameMap.StrongAttack.performed += OnStrongAttack;
        }

        private void Update()
        {
            OnMovement();
        }

        private void OnMovement()
        {
            var direction = _controls.GameMap.Movement.ReadValue<Vector2>();
            var velocity = new Vector3(direction.x, 0f, direction.y);
            transform.position += velocity * _speed * Time.deltaTime;
        }

        private void OnFastAttack(CallbackContext context)
        { 

        }
        private void OnStrongAttack(CallbackContext context)
        {

        }
        private void OnDestroy()
        {
            _controls.Dispose();
        }

        private void OnEnable()
        {
            _controls.Disable();
        }
    }
}