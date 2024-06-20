using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinySimStore.DB
{
    [CreateAssetMenu(fileName = "New Currency", menuName = "Tiny Sim Store/Currency")]
    public class SOCurrency : ScriptableObject
    {
        #region FIELDS
        [SerializeField] private string currencyName;
        [SerializeField] private string description;
        [SerializeField] private Sprite icon;
        #endregion

        #region PROPERTIES
        #endregion

        #region UNITY METHODS
        #endregion

        #region PRIVATE METHODS
        #endregion

        #region PUBLIC METHODS
        #endregion
    }
}