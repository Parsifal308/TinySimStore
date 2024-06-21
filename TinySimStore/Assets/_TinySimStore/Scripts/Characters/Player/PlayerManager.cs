using System.Collections;
using System.Collections.Generic;
using TinySimStore.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TinySimStore.Character.Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerManager : Singleton<PlayerManager>
    {
        #region FIELDS
        private CharacterMovement characterMovement;
        private PlayerInput playerInput;
        private Rigidbody2D rb;
        private CharacterEquipment equipment;
        private CharacterInventory inventory;
        #endregion

        #region PROPERTIES
        public PlayerInput PlayerInput { get { return playerInput; } }
        public CharacterMovement CharacterMovement { get { return characterMovement; } }
        public CharacterEquipment CharacterEquipment { get { return equipment; } }
        public CharacterInventory CharacterInventory { get { return inventory; } }
        #endregion

        #region UNITY METHODS
        void Awake()
        {
            base.Awake();
            if (TryGetComponent<PlayerInput>(out PlayerInput playerInput)) this.playerInput = playerInput;
            if (TryGetComponent<CharacterMovement>(out CharacterMovement characterMovement)) this.characterMovement = characterMovement;
            if (TryGetComponent<CharacterEquipment>(out CharacterEquipment equipment)) this.equipment = equipment;
            if (TryGetComponent<CharacterInventory>(out CharacterInventory inventory)) this.inventory = inventory;
        }
        #endregion

        #region PRIVATE METHODS
        #endregion

        #region PUBLIC METHODS
        #endregion
    }
}