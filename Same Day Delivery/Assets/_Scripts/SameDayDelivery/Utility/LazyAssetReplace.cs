using System;
using System.Collections.Generic;
using UnityEngine;

namespace SameDayDelivery.Utility
{
    public class LazyAssetReplace : MonoBehaviour
    {
        public GameObject gameObjectReplacement;
        public Mesh meshLoopUp;
        private MeshFilter[] _potentialAssetsToReplace;
        private List<GameObject> _assetsToReplace = new List<GameObject>();

        private void Start()
        {
            
            
            _potentialAssetsToReplace = FindObjectsOfType<MeshFilter>();
            foreach (var meshFilter in _potentialAssetsToReplace)
            {
                if (meshFilter.sharedMesh == meshLoopUp)
                    _assetsToReplace.Add(meshFilter.gameObject);
            }

            foreach (var go in _assetsToReplace)
            {
                go.SetActive(false);
                var replacement = Instantiate(gameObjectReplacement, go.transform.parent, true);
                replacement.transform.localPosition = go.transform.localPosition;
                replacement.transform.localScale = go.transform.localScale;
                replacement.transform.localRotation = go.transform.localRotation;
                replacement.SetActive(true);
            }
        }
    }
}