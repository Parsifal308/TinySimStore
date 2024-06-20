using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TinySimStore.Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerManager : Singleton<PlayerManager>
    {
        #region FIELDS
        private CharacterMovement characterMovement;
        private PlayerInput playerInput;
        private Rigidbody2D rb;
        #endregion

        #region PROPERTIES
        public PlayerInput PlayerInput { get { return playerInput; } }
        public CharacterMovement CharacterMovement { get { return characterMovement; } }
        #endregion

        #region UNITY METHODS
        void Awake()
        {
            base.Awake();
            if (TryGetComponent<PlayerInput>(out PlayerInput playerInput)) this.playerInput = playerInput;
            if (TryGetComponent<CharacterMovement>(out CharacterMovement characterMovement)) this.characterMovement = characterMovement;
        }
        #endregion

        #region PRIVATE METHODS
        #endregion

        #region PUBLIC METHODS
        #endregion
    }
}