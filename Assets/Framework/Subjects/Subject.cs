using System.Collections.Generic;
using DesertImage.Managers;

namespace DesertImage.Subjects
{
    public class Subject : ISubject
    {
        #region PROPERTIS

        public Dictionary<int, object>.KeyCollection Components
        {
            get { return _components.Keys; }
        }

        #endregion
        
        #region PRIVATE

        private readonly ManagerEvents _managerEvents = new ManagerEvents();

        private readonly Dictionary<int, object> _components = new Dictionary<int, object>();

        #endregion

        #region MONO BEHVAIOUR METHODS

        private void Awake()
        {
        }

        #endregion

        #region PUBLIC METHODS

        public void add<T>(T component)
        {
            Add(component);
        }

        public void add<T>() where T : new()
        {
            Add<T>();
        }

        public void remove<T>()
        {
            Remove<T>();
        }

        public void listen<T>(IListen listener)
        {
            Listen<T>(listener);
        }

        public void unlisten<T>(IListen listener)
        {
            Unlisten<T>(listener);
        }

        public void send<T>(T arguments)
        {
            Send<T>(arguments);
        }

        public T get<T>()
        {
            return Get<T>();
        }

        public void onCreate()
        {
            InitStuff();
        }

        public void returnToPool()
        {
            Destroy();
        }
        
        #endregion

        #region INIT

        private void Init()
        {
           Core.Instance.get<ManagerUpdate>().add(this);

            InitStuff();
        }

        protected virtual void InitStuff()
        {
        }

        #endregion

        #region ADD / REMOVE

        private void Add<T>(T component)
        {
            AddComponent(component);
        }

        private void Add<T>() where T : new()
        {
            var newComponent = new T();

            AddComponent(newComponent);
        }

        private void AddComponent<T>(T component)
        {
            if (!(component is IComponent)) return;

            var hash = typeof(T).GetHashCode();

            _components.Add(hash, component);
        }
        
        private void Remove<T>()
        {
            var hash = typeof(T).GetHashCode();
            
            if (!_components.ContainsKey(hash)) return;
            
            _components.Remove(hash);
        }

        #endregion

        #region EVENTS MANAGING

        private void Listen<T>(IListen listener)
        {
            _managerEvents.add<T>(listener);
        }

        private void Unlisten<T>(IListen listener)
        {
            _managerEvents.remove<T>(listener);
        }

        private void Send<T>(T arguments)
        {
            _managerEvents.send<T>(arguments);
        }

        #endregion

        #region GET

        private T Get<T>()
        {
            object obj;

            _components.TryGetValue(typeof(T).GetHashCode(), out obj);

            return (T) obj;
        }

        #endregion

        #region DESTROY

        private void Destroy()
        {
            _components.Clear();
        }

        #endregion
    }
}