using DesertImage.Events;
using DesertImage.Subjects;
using PlantsVsZombies.Events;
using UnityEngine;

namespace DesertImage
{
    public class CollisionComponent : MonoBehaviour
    {
        private ISubject _subject;

        private void Awake()
        {
            _subject = GetComponentInParent<ISubject>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            this.Send(new TriggerEnterEvent {Source = _subject, Other = other});
            
            var subject = other.GetComponentInParent<ISubject>();
            
            if (subject == null) return;
            
            _subject.send(new TriggerEnterEvent() {Source = subject, Other = other});  
//            subject.send(new TriggerEnterEvent() {Source = _subject, Other = other});  
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            this.Send(new CollisionEnterEvent() {Source = _subject});

            var subject = other.collider.GetComponentInParent<ISubject>();
            
            if (subject == null) return;
            
            _subject.send(new CollisionEnterEvent() {Source = subject});  
//            subject.send(new CollisionEnterEvent() {Source = _subject, Other = other});            
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            this.Send(new CollisionStayEvent() {Source = _subject});

            var subject = other.collider.GetComponentInParent<ISubject>();
            
            if (subject == null) return;
            
            _subject.send(new CollisionStayEvent() {Source = subject});  
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            this.Send(new CollisionExitEvent() {Source = _subject});

            var subject = other.collider.GetComponentInParent<ISubject>();
            
            if (subject == null) return;
            
            _subject.send(new CollisionExitEvent() {Source = subject});  
        }
    }
}