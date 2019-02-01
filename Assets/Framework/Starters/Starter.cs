using UnityEngine;

namespace Framework.Starters
{
    public abstract class Starter : MonoBehaviour
    {
        public static Starter Instance
        {
            get
            {
                if (!_instance)
                    _instance = FindObjectOfType<Starter>();

                return _instance;
            }
        }

        private static Starter _instance;

        private void Awake()
        {
            Init();
        }

        protected abstract void Init();
    }
}