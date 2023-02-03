using UnityEngine;

namespace SameDayDelivery
{
    public class PackagePickup : MonoBehaviour
    {
        public Transform packageMount;
        public GameObject targetPackage;
        public float dropTime = 1f;
        public GameObject packagesParent;

        private bool _carrying;

        private float _dropTimer;

        private void Awake()
        {
            _dropTimer = dropTime;
        }

        private void Update()
        {
            if (_dropTimer > 0)
                _dropTimer -= Time.deltaTime;

            if (!Input.GetKey(KeyCode.E)) return;
            Debug.Log($"E pressed");
            if (!_carrying) return;
            Debug.Log($"carrying package");
            if (_dropTimer > 0) return;
            Debug.Log($"drop timer done");
            Drop();
        }

        public void Pickup(GameObject package)
        {
            targetPackage = package;
            var rb = package.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.detectCollisions = false;
            package.transform.SetParent(packageMount);
            package.transform.localPosition = Vector3.zero;
            package.transform.rotation = Quaternion.identity;
            _carrying = true;
            _dropTimer = dropTime;
            targetPackage.GetComponent<Package>().ResetPickupTimer();
        }

        public void Drop()
        {
            Debug.Log($"Drop");
            var rb = targetPackage.GetComponent<Rigidbody>();
            targetPackage.transform.SetParent(packagesParent.transform);
            rb.isKinematic = false;
            rb.detectCollisions = true;
            _carrying = false;
        }
    }
}
