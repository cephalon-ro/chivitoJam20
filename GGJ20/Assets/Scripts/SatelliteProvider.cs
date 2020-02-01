using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class SatelliteProvider :MonoBehaviour
    {
        List<Satellite> satellites;

        void Start()
        {
            satellites = GetComponentsInChildren<Satellite>().ToList();
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
    }
}
