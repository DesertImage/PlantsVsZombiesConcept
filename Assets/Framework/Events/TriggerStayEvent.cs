using DesertImage.Subjects;
using UnityEngine;

namespace PlantsVsZombies.Events
{
    public struct TriggerStayEvent
    {
        public ISubject Source;
        public Collider Other;
    }
}