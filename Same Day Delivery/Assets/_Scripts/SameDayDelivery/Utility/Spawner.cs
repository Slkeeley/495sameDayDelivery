using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SameDayDelivery.Utility
{
    public class Spawner : MonoBehaviour
    {
        public bool spawnOnStart = true;
        public List<GameObject> spawnPrefabs = new List<GameObject>();
        [Tooltip("Chance the spawner will spawn nothing.")]
        [Range(0f, 1f)]
        public float misfireChance;

        [Tooltip("If set, spawner will spawn at this transform rather than using the transform of the object " +
                 "its attached to.")]
        public Transform overrideSpawnLocation;

        [Header("Gizmo Properties")]
        [SerializeField]
        private Mesh _previewMesh;

        [SerializeField]
        private float _gizmoAlpha = 0.1f;

        [SerializeField]
        private float _gizmoScale = 0.5f;
        
        [SerializeField]
        private Vector3 _gizmoOffset = Vector3.up;
        


        private void Start()
        {
            if (!spawnOnStart) return;
            if (misfireChance >= 1f) return;
            
            float r = Random.Range(0f, 1f);
            if (r <= misfireChance) return;
            
            if (spawnPrefabs.Count <= 0) return;
            
            GameObject prefab = spawnPrefabs[Random.Range(0, spawnPrefabs.Count)];
            Transform transform1 = overrideSpawnLocation ? overrideSpawnLocation : transform;
            GameObject instance = Instantiate(prefab, transform1.position, quaternion.identity);
            instance.transform.forward = transform1.forward;
            instance.transform.SetParent(transform);
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Color defaultColor = Gizmos.color;
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position + _gizmoOffset, transform.position + transform.forward + _gizmoOffset);
            Gizmos.color = new Color(0f, 1f, 0f, _gizmoAlpha);
            if (_previewMesh)
                Gizmos.DrawMesh(_previewMesh, transform.position + _gizmoOffset, Quaternion.Euler(transform.forward), _gizmoScale * Vector3.one);
            else
                Gizmos.DrawSphere(transform.position + _gizmoOffset, _gizmoScale);
            Gizmos.color = defaultColor;
        }
#endif
    }
}