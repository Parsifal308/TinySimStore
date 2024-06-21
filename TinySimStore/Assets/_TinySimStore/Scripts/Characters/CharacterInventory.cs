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
        [SerializeField] private List<SOItemBase> content;
        [SerializeField] private Money coins;
        #endregion

        #region PROPERTIES
        public List<SOItemBase> Content { get {  return content; } }
        public Money Coins { get {  return coins; } }
        #endregion

        #region UNITY METHODS

        #endregion

        #region PRIVATE METHODS
        #endregion

        #region PUBLIC METHODS
        public void AddToEmpty(SOItemBase newItem)
        {
            for (int i = 0; i < content.Count; i++)
            {
                if (content[i] == null)
                {
                    content[i] = newItem;
                    return;
                }
            }
            content.Add(newItem);
        }
        #endregion
    }
}