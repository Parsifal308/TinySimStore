using System.Collections;
using System.Collections.Generic;
using TinySimStore.Inventory;
using UnityEngine;

namespace TinySimStore.Character
{
    public class NPC : MonoBehaviour
    {
        #region FIELDS
        [SerializeField] private bool isVendor;
        private CharacterInventory inventory;
        #endregion

        #region PROPERTIES
        #endregion

        #region UNITY METHODS
        private void Awake()
        {
            if (TryGetComponent<CharacterInventory>(out CharacterInventory inventory)) this.inventory = inventory;
        }
        #endregion

        #region PRIVATE METHODS
        #endregion

        #region PUBLIC METHODS
        #endregion
    }
}