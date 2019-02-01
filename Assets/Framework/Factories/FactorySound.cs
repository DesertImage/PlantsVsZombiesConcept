using System;
using System.Collections.Generic;
using DesertImage.Enums;
using PlantsVsZombies.Audio;
using DesertImage.Pools;
using UnityEngine;

namespace DesertImage
{
    [CreateAssetMenu(fileName = "FactorySound", menuName = "Factories/Sound")]
    public class FactorySound : Factory, IAwake
    {
        private const string PrefabName = "SoundEffect";

        #region PRIVATE

        public List<SoundNode> Nodes;

        private PoolGameObject _pool;

        private GameObject _objPrefab;

        #endregion

        #region PUBLIC METHODS

        public void onAwake()
        {
            Init();
        }

        public void spawn2D(SoundId id, float volume = 1f)
        {
            Spawn2D(id, volume);
        }

        #endregion

        #region INIT

        private void Init()
        {
            _pool = new PoolGameObject(GameObject.Find("Pools").transform);

            RegisterTemplate();
        }

        private void RegisterTemplate()
        {
            if (_pool == null) return;

            _objPrefab = new GameObject(PrefabName);

            _objPrefab.transform.parent = GameObject.Find("Pools").transform;
            
            _objPrefab.AddComponent<AudioSource>().playOnAwake = false;
            _objPrefab.AddComponent<SoundBase>();

            _pool.register(_objPrefab, 50);
        }

        #endregion

        #region SPAWN

        private void Spawn2D(SoundId id, float volume)
        {
            if (_pool == null) return;

            var obj = _pool.getInstance(_objPrefab);

            var soundBase = obj.GetComponent<SoundBase>();

            foreach (var node in Nodes)
            {
                if (node.Id != id) continue;

                soundBase.play(node.SoundClip, volume);
                
                break;
            }
        }

        #endregion

        #region RETURN

        private void ReturnInstance(GameObject obj, AudioClip audioClip)
        {
            obj.SetActive(false);
            obj.transform.parent = null;

            _pool.returnInstance(obj, PrefabName);
        }

        #endregion
    }

    [Serializable]
    public class SoundNode
    {
        [SerializeField] private string _name;

        public SoundId Id;
        public AudioClip SoundClip;

        public int RegisterCount;
    }
}