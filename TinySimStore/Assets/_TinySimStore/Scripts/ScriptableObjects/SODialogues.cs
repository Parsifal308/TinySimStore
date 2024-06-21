using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TinySimStore.DB
{
    [CreateAssetMenu(fileName = "New Dialogue ", menuName = "Tiny Sim Store/Dialogue")]
    public class SODialogues : ScriptableObject
    {
        #region FIELDS
        [SerializeField] private List<string> lines;
        #endregion

        #region PROPERTIES
        public List<string> Lines { get { return lines; } }
        #endregion
    }
}