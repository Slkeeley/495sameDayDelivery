using System.Collections.Generic;
using SameDayDelivery.Controls;
using SameDayDelivery.ScriptableObjects;
using SameDayDelivery.Utility;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace SameDayDelivery.PackageSystem
{
    public class PackagePickup : MonoBehaviour
    {
        [SerializeField] private GameData gameData;
        [Tooltip("Time in seconds until throw charge is at maximum force.")]
        public float maxChargeTime = 1f;
        [Tooltip("Maximum throw force after 'Max Charge Time' seconds.")]
        public float maxThrowForce = 10f;

        [SerializeField] private Transform packageMount;
        [SerializeField] private Transform packagesParent;
        [SerializeField] private Package carryingPackage;
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _throwReticle;
        [SerializeField] private Color _reticleStartColor = new Color(0f, 1f, 1f, 0.25f);
        [SerializeField] private Color _reticleEndColor = new Color(0f, 1f, 1f, 0.9f);
        [SerializeField] private Animator _fullChargeAnimator;
        [SerializeField] private bool _buttonDown;
        [SerializeField] private float _throwCharge;
        [SerializeField] private Animator _sheldonAnimator;
        [SerializeField] private UpgradeItem _upgradeWorkGloves;
        [SerializeField] private UnityEvent onPackageThrow;
        [SerializeField] private UnityEvent onPickup;
        
        private readonly List<Package> _availablePackages = new List<Package>();
        private PlayerControlManager _playerControls;
        private bool _justPickedUp;
        private Image _throwReticleImage;
        private bool _growPlaying;
        private static readonly int GrowParam = Animator.StringToHash("Grow");
        private static readonly int LockParam = Animator.StringToHash("Lock");
        private Vector3 _reticleOriginalScale;
        private static readonly int PickupAnim = Animator.StringToHash("Pickup");

        private void Awake()
        {
            _playerControls = GetComponent<PlayerControlManager>();
            _throwReticle.SetActive(false);
            _throwReticleImage = _throwReticle.GetComponent<Image>();
            _reticleOriginalScale = _throwReticle.transform.localScale;
        }

        private void OnEnable()
        {
            _playerControls.InteractBegin += ButtonDown;
            _playerControls.InteractEnd += ButtonUp;
        }

        private void OnDisable()
        {
            _playerControls.InteractBegin -= ButtonDown;
            _playerControls.InteractEnd -= ButtonUp;
        }

        private void Update()
        {
            if (_growPlaying)
            {
                _fullChargeAnimator.SetBool(LockParam, true);
                _fullChargeAnimator.SetBool(GrowParam, false);
                _growPlaying = false;
            }

            if (!_buttonDown) return;
            if (!carryingPackage) return;

            _throwCharge += Time.deltaTime;
            _throwCharge = Mathf.Clamp(_throwCharge, 0f, maxChargeTime);
            var percentCharge = Mathf.InverseLerp(0f, maxChargeTime, _throwCharge);

            var frequency = Mathf.Lerp(0.25f, 0.5f, percentCharge);
            var amplitude = Mathf.Lerp(0.15f, 1f, percentCharge);
            var shakeTime = Mathf.Lerp(0.15f, 0.35f, percentCharge);
            CinemachineShake.Instance.ShakeCamera(amplitude, frequency, shakeTime);

            // change scale
            _throwReticle.transform.localScale = _reticleOriginalScale * percentCharge;

            // change color
            percentCharge = (percentCharge < 1f) ? 0f : 1f;
            _throwReticleImage.color = Color.Lerp(_reticleStartColor, _reticleEndColor, percentCharge);

            if (!(percentCharge >= 1f)) return;

            // charge is full and animation not playing
            if (_growPlaying)
            {
                _fullChargeAnimator.SetBool(GrowParam, false);
                _fullChargeAnimator.SetBool(LockParam, true);
                _growPlaying = false;
                return;
            }

            _growPlaying = true;

            _fullChargeAnimator.SetBool(GrowParam, true);
        }

        private void ButtonUp()
        {
            _buttonDown = false;
            if (!carryingPackage) return;
            if (_justPickedUp)
            {
                _justPickedUp = false;
                _fullChargeAnimator.SetBool(LockParam, true);
                return;
            }

            ThrowPackage();

        }

        private void ButtonDown()
        {
            if (carryingPackage)
            {
                gameData.carryingPackage = carryingPackage;
                _buttonDown = true;
                _throwCharge = 0f;
                _throwReticle.SetActive(true);
                _fullChargeAnimator.SetBool(LockParam, false);
            }
            else
            {
                PickupPackage();
            }
        }

        private void ThrowPackage()
        {
            Transform localTransform;
            (localTransform = carryingPackage.transform).SetParent(packagesParent);
            localTransform.position = packageMount.position;

            var forward = _camera.transform.forward;

            // gets ratio of chargeTime to maxChargeTime
            var percentCharge = Mathf.InverseLerp(0f, maxChargeTime, _throwCharge);
            var chargeTimeRatio = percentCharge;

            // modifies throw force by a ValueA of the upgrade gloves which should be a percentage
            var modMaxThrowForce = (_upgradeWorkGloves != null && _upgradeWorkGloves.purchased) ? 
                (maxThrowForce * _upgradeWorkGloves.valueA.uValue) : maxThrowForce;
            
            // Interpolated value from 0 to maxThrowForce based on ratio of chargeTime to maxChargeTime
            var power = Mathf.Lerp(0f, modMaxThrowForce, chargeTimeRatio);

            // drops the package with a force based on the camera's forward vector and the power based on the time
            // holding down the drop button.
            carryingPackage.Throw(forward, power);

            onPackageThrow?.Invoke();
            
            onPackageThrow?.Invoke();
            carryingPackage = null;
            gameData.carryingPackage = null;
            _justPickedUp = false;

            _throwReticle.SetActive(false);

            _fullChargeAnimator.SetBool(LockParam, false);

            var frequency = Mathf.Lerp(0.5f, 2.5f, percentCharge);
            var amplitude = Mathf.Lerp(0.15f, 4f, percentCharge);
            var shakeTime = Mathf.Lerp(0.15f, 0.35f, percentCharge);

            CinemachineShake.Instance.ShakeCamera(amplitude, frequency, shakeTime);
        }

        private void PickupPackage()
        {
            if (_availablePackages.Count <= 0) return;

            var targetPackage = _availablePackages[0];
            var finalDistance = Vector3.Distance(transform.position, targetPackage.transform.position);

            foreach (var package in _availablePackages)
            {
                var newDistance = Vector3.Distance(transform.position, package.transform.position);
                if (!(finalDistance < newDistance)) continue;
                finalDistance = newDistance;
                targetPackage = package;
            }

            carryingPackage = targetPackage;
            gameData.carryingPackage = carryingPackage;
            carryingPackage.Pickup();
            carryingPackage.transform.position = packageMount.position;
            carryingPackage.transform.SetParent(packageMount);
            _justPickedUp = true;
            _sheldonAnimator.SetBool(PickupAnim, true);
            Debug.Log($"Pickup");
            onPickup?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            var package = other.GetComponent<Package>();
            if (!package) return;
            _availablePackages.Add(package);
        }

        private void OnTriggerExit(Collider other)
        {
            var package = other.GetComponent<Package>();
            if (!package) return;
            if (_availablePackages.Contains(package))
                _availablePackages.Remove(package);
        }

        public void StopReticleGrowAnimation()
        {
            _fullChargeAnimator.SetBool(GrowParam, false);
            _growPlaying = false;
        }

        public bool CarryingPackage() => carryingPackage != null;

        public Package GetCarryingPackage() => carryingPackage;

        public void PickupAnimationCompleted()
        {
            _sheldonAnimator.SetBool(PickupAnim, false);
        }
    }
}
