using System;
using System.Collections;
using System.Collections.Generic;
using TinySimStore.Character.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TinySimStore.Manager
{
    public class UIManager : Singleton<UIManager>
    {
        #region FIELDS
        private DialoguePanel dialoguePanel;
        private StoreUI store;
        private InventoryUI inventory;
        [Header("INPUT SETTINGS:"), Space(5)]
        [SerializeField] private string pauseActionName = "Pause";
        [SerializeField] private string inventoryActionName = "Inventory";
        [SerializeField] private string characterActionName = "Character";

        [Header("USER INTERFASES:"), Space(5)]
        [SerializeField] private CanvasGroup pauseCanvas;
        [SerializeField] private CanvasGroup characterCanvas;
        [SerializeField] private CanvasGroup inventoryCanvas;
        [SerializeField] private CanvasGroup storeCanvas;
        [SerializeField] private CanvasGroup dialogueCanvas;

        #endregion

        #region PROPERTIES
        public InventoryUI Inventory { get { return inventory; } }
        public StoreUI Store { get { return store; } }
        public DialoguePanel DialoguePanel { get { return dialoguePanel; } }
        public CanvasGroup DialogueCanvas { get { return dialogueCanvas; } }
        public CanvasGroup StoreCanvas { get { return storeCanvas; } }
        #endregion

        #region UNITY METHODS
        private void Start()
        {
            SubscribeInput();
            dialoguePanel = dialogueCanvas.GetComponent<DialoguePanel>();
            store = storeCanvas.GetComponent<StoreUI>();
            inventory= inventoryCanvas.GetComponent<InventoryUI>();
        }
        #endregion

        #region PRIVATE METHODS
        private void SubscribeInput()
        {
            try
            {
                PlayerManager.Instance.PlayerInput.currentActionMap.FindAction(pauseActionName).performed += PausePerformed;
                PlayerManager.Instance.PlayerInput.currentActionMap.FindAction(inventoryActionName).performed += InventoryPerformed;
                PlayerManager.Instance.PlayerInput.currentActionMap.FindAction(characterActionName).performed += CharacterPerformed;
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
                PlayerManager.Instance.PlayerInput.currentActionMap.FindAction(pauseActionName).performed -= PausePerformed;
                PlayerManager.Instance.PlayerInput.currentActionMap.FindAction(inventoryActionName).performed -= InventoryPerformed;
                PlayerManager.Instance.PlayerInput.currentActionMap.FindAction(characterActionName).performed -= CharacterPerformed;
            }
            catch (System.Exception)
            {
                Debug.LogError("An error occurred while trying to unsubscribe to the input's phase events. Check that the name of the correct action in <" + this.GetType() + "> has been given from the inspector");
            }
        }
        #endregion

        #region PUBLIC METHODS
        public void ShowCanvas(CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        public void HideCanvas(CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        #endregion

        #region EVENTS CALLBACKS
        private void CharacterPerformed(InputAction.CallbackContext context)
        {
            HideCanvas(inventoryCanvas);
            HideCanvas(storeCanvas);
            HideCanvas(pauseCanvas);
            if (characterCanvas.alpha == 1)
            {
                HideCanvas(characterCanvas);
            }
            else
            {
                ShowCanvas(characterCanvas);
            }
        }

        private void InventoryPerformed(InputAction.CallbackContext context)
        {
            HideCanvas(characterCanvas);
            HideCanvas(storeCanvas);
            HideCanvas(pauseCanvas);
            if (inventoryCanvas.alpha == 1)
            {
                HideCanvas(inventoryCanvas);
            }
            else
            {
                ShowCanvas(inventoryCanvas);
            }
        }
        private void PausePerformed(InputAction.CallbackContext context)
        {
            HideCanvas(inventoryCanvas);
            HideCanvas(characterCanvas);
            HideCanvas(storeCanvas);
            PlayerManager.Instance.CharacterMovement.enabled = true;
            if (pauseCanvas.alpha == 1)
            {
                HideCanvas(pauseCanvas);
            }
            else
            {
                ShowCanvas(pauseCanvas);
            }
        }
        #endregion
    }
}