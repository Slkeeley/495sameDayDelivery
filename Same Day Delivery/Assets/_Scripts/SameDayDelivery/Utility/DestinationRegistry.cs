using System.Collections;
using System.Collections.Generic;
using SameDayDelivery.PackageSystem;
using UnityEngine;
using Random = UnityEngine.Random;
using SameDayDelivery.Controls;

namespace SameDayDelivery.Utility
{
    public class DestinationRegistry : MonoBehaviour
    {
        public static DestinationRegistry Instance { get => _instance; }
        private static DestinationRegistry _instance;


        public FauxPackageDelivery activeDelivery;
        public List<FauxPackageDelivery> availableDeliveriesList = new List<FauxPackageDelivery>();
        public List<FauxPackageDelivery> deliveredLocationsList = new List<FauxPackageDelivery>();
        [SerializeField]
        private Transform _playerTransform;
        [SerializeField]
        private float _packageDeliveryRange = 30f;

        [SerializeField]
        private GameWatcher _gameWatcher;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
            {
                if (_instance != this)
                    Destroy(gameObject);
            }
        }

        private void Start()
        {
            StartCoroutine(ShortDelay());
        }

        private IEnumerator ShortDelay()
        {
            yield return new WaitForSeconds(1f);
            NextDelivery();
        }

        public void RegisterAvailableDelivery(FauxPackageDelivery delivery)
        {
            availableDeliveriesList.Add(delivery);
        }
        
        public void PackageDelivered(FauxPackageDelivery fauxPackageDelivery, Package package)
        {
            _gameWatcher.PackageReceived();
            availableDeliveriesList.Remove(fauxPackageDelivery);
            deliveredLocationsList.Add(fauxPackageDelivery);
            
            NextDelivery();
        }

        public void NextDelivery()
        {
            if (availableDeliveriesList.Count <= 0)
            {
                Debug.LogError($"No more available delivery locations left.");
                activeDelivery = null;
                return;
            }

            var offset = 0;

            List<FauxPackageDelivery> tempList = new List<FauxPackageDelivery>();
            
            while (tempList.Count <= 0)
            {
                foreach (FauxPackageDelivery fauxPackageDelivery in availableDeliveriesList)
                {
                    if (Vector3.Distance(fauxPackageDelivery.transform.position, _playerTransform.position) <= _packageDeliveryRange + offset)
                    {
                        tempList.Add(fauxPackageDelivery);
                    }
                }

                offset += 10;
            }
            
            if (tempList.Count <= 0)
            {
                Debug.LogError($"No more available delivery locations left.");
                activeDelivery = null;
                return;
            }
            
            activeDelivery = tempList[Random.Range(0, tempList.Count)];
            activeDelivery.Activate();
        }
    }
}