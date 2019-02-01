using DesertImage.Subjects;
using UnityEngine;

namespace PlantsVsZombies.Events
{
    public struct TriggerEnterEvent
    {
        public ISubject Source;
        public Collider2D Other;
    }
}