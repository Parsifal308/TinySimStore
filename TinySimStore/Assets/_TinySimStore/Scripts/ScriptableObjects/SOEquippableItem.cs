using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinySimStore.DB
{
    [CreateAssetMenu(fileName = "New Equippable Item", menuName = "Tiny Sim Store/Equippable Item")]
    public class SOEquippableItem : SOItemBase
    {
        #region FIELDS
        [SerializeField] private List<Sprite> equipmentSprite;
        #endregion
    }
}