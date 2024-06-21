using System;
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
        private NPC nearNPC;
        [Header("INPUT SETTINGS:"), Space(5)]
        [SerializeField] private string interactActionName = "Interact";
        #endregion

        #region PROPERTIES
        public NPC NearNPC { get { return nearNPC; } set { nearNPC = value; } }
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
        private void Start()
        {
            SubscribeInput();
        }
        #endregion

        #region PRIVATE METHODS
        private void SubscribeInput()
        {
            try
            {
                PlayerManager.Instance.PlayerInput.currentActionMap.FindAction(interactActionName).performed += InteractPerformed;

            }
            catch (System.Exception)
            {
                Debug.LogError("An error occurred while trying to subscribe to the input's phase events. Check that the name of the correct action in <" + this.GetType() + "> has been given from the inspector");
            }
        }

        #endregion

        #region PUBLIC METHODS
        #endregion

        #region EVENTS CALLBACKS
        private void InteractPerformed(InputAction.CallbackContext context)
        {
            if (nearNPC!=null)
            {
                nearNPC.Interact();
            }
        }
        #endregion
    }
}