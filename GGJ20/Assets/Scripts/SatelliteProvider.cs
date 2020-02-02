using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class SatelliteProvider : MonoBehaviour
    {
        List<Satellite> satellites;
        public GameController ctrl;
        public NameProvider nameProvider;

        void Start()
        {
            ctrl = FindObjectOfType<GameController>();

            UpdateSatellites();
            /*
            satellites = GetComponentsInChildren<Satellite>().ToList();
            
            switch (gameObject.tag)
            {
                case "Provider1":
                    ctrl.SatellitesP1.AddRange(satellites);
                    break;
                case "Provider2":
                    ctrl.SatellitesP2.AddRange(satellites);
                    break;
            }
            */
        }


        private void UpdateSatellites() {
            satellites = GetComponentsInChildren<Satellite>().ToList();
            foreach (Satellite sat in satellites) {
                if (string.IsNullOrEmpty(sat.codename)) {
                    sat.codename = nameProvider.GetSatName();
                }
            }
            switch (gameObject.tag)
            {
                case "Provider1":
                    ctrl.SatellitesP1.AddRange(satellites);
                    break;
                case "Provider2":
                    ctrl.SatellitesP2.AddRange(satellites);
                    break;
            }
        }


        public IEnumerable<Satellite> InRage(Vector3 position, float range)
        {
            return satellites.Where(s => Vector3.Distance(position, s.transform.position) <= range);
        }

        public Satellite ClosestInRange(Vector3 position, float range)
        {
            if (satellites.Any(s => Vector3.Distance(position, s.transform.position) <= range))
            {
               return satellites
                    .Select(s => new {sattelite = s, distance = Vector3.Distance(position, s.transform.position)})
                    .OrderBy(sd => sd.distance)
                    .First().sattelite;
           
            }

            return null;
        }

        public string GetSatName() {
            return nameProvider.GetSatName();
        }
    }
}
