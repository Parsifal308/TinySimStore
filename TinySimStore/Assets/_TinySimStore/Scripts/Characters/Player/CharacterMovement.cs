﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TinySimStore.Character.Player
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour
    {
        #region FIELDS
        private Animator animator;
        private Vector2 movementInput;
        private Rigidbody2D rb;

        [Header("INPUT SETTINGS:"), Space(5)]
        [SerializeField] private string movementActionName = "Movement";

        [Header("MOVEMENT SETTINGS:"), Space(5)]
        [SerializeField] private float speed = 2.5f;
        #endregion

        #region PROPERTIES
        #endregion

        #region UNITY METHODS
        void Start()
        {
            SubscribeInput();
            if (TryGetComponent<Rigidbody2D>(out Rigidbody2D rb)) this.rb = rb;
            animator = GetComponentInChildren<Animator>();
        }
        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + movementInput * Time.fixedDeltaTime * speed);
        }
        
        #endregion

        #region PRIVATE METHODS
        private void SubscribeInput()
        {
            try
            {
                PlayerManager.Instance.PlayerInput.currentActionMap.FindAction(movementActionName).performed += MovementPerformed;
                PlayerManager.Instance.PlayerInput.currentActionMap.FindAction(movementActionName).canceled += MovementCanceled;

            }
            catch (System.Exception)
            {
                Debug.LogError("An error occurred while trying to subscribe to the input's phase events. Check that the name of the correct action in <" + this.GetType() + "> has been given from the inspector");
            }
        }
        private void UnsubscribeInput()
        {
            try
            {
                PlayerManager.Instance.PlayerInput.currentActionMap.FindAction(movementActionName).performed -= MovementPerformed;
                PlayerManager.Instance.PlayerInput.currentActionMap.FindAction(movementActionName).canceled -= MovementCanceled;
            }
            catch (System.Exception)
            {
                Debug.LogError("An error occurred while trying to unsubscribe to the input's phase events. Check that the name of the correct action in <" + this.GetType() + "> has been given from the inspector");
            }
        }
        #endregion

        #region PUBLIC METHODS
        #endregion

        #region EVENTS CALLBACKS
        private void MovementCanceled(InputAction.CallbackContext context)
        {
            movementInput = Vector2.zero;
            animator.SetBool("IsMoving", false);
        }

        private void MovementPerformed(InputAction.CallbackContext context)
        {
            movementInput = context.ReadValue<Vector2>();
            animator.SetBool("IsMoving", true);
            if (movementInput.x>0f)
            {
                animator.transform.rotation=Quaternion.Euler(0, 0, 0);
            }
            else if (movementInput.x<0f) 
            {
                animator.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        #endregion
    }
}