using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinySimStore.DB
{
    public abstract class SOItemBase : ScriptableObject
    {
        #region FIELDS
        [SerializeField] protected string itemName;
        [SerializeField] protected string description;
        [SerializeField] protected Sprite icon;
        [SerializeField] protected Price price;
        #endregion

        #region PROPERTIES
        public string ItemName { get { return itemName; } }
        public string Description { get { return description; } }
        public Sprite Icon { get { return icon; } }
        public Price Price { get { return price; } }

        #endregion
    }

    [Serializable]
    public class Price
    {
        #region FIELDS
        [SerializeField] private int amount;
        [SerializeField] private SOCurrency currency;
        #endregion

        #region PROPERTIES
        public int Amount { get { return amount; } }
        public SOCurrency Currency { get { return currency; } }
        #endregion
    }
}