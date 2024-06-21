using System.Collections;
using System.Collections.Generic;
using TinySimStore.DB;
using System.Linq;
using UnityEngine;
using System;
using TinySimStore.Manager;

namespace TinySimStore.Inventory
{
    public class CharacterInventory : MonoBehaviour
    {
        #region FIELDS
        [SerializeField] private List<SOItemBase> content= new List<SOItemBase>();
        #endregion

        #region PROPERTIES
        public List<SOItemBase> Content { get {  return content; } }
        #endregion

        #region UNITY METHODS

        #endregion

        #region PRIVATE METHODS
        #endregion

        #region PUBLIC METHODS
        public void UpdateUI()
        {
        }
        #endregion
    }
}