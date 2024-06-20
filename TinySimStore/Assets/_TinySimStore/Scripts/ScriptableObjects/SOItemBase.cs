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
    }

    [Serializable]
    public class Price
    {
        [SerializeField] private int amount;
        [SerializeField] private SOCurrency currency;
    }
}