using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class SatelliteDetector : MonoBehaviour
    {
        public float DetectionRange;
        public SatelliteProvider Provider;
        public NewController player;

        private void Start() {
            player = GetComponentInParent<NewController>();
        }

        void Update() {
            var candidate = Provider.ClosestInRange(transform.position, DetectionRange);
            if (candidate != null)
            {
                Debug.Log($"Estoy cerca del satelite con codename: {candidate.codename}");
                player.onSat = true;
                player.touchSat = candidate;
                candidate.satText.gameObject.SetActive(true);
                candidate.satText.text = candidate.codename;
            }
            else {
                player.onSat = false;
                player.touchSat = null;
            }
        }
    }
}
