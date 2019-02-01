using System;
using DesertImage;
using DesertImage.Managers;

namespace Framework.Timer
{
    public class Timer : IComponent, ITick, IPoolable
    {
        public float Time { get; private set; }
        
        private float _targetTime;
        private Action _action;

        private bool _isPlaying;
            
        #region PUBLIC METHODS

        public void play(Action action, float timeDelay = 1f)
        {
            Play(action, timeDelay);
        }

        public void stop()
        {
            Stop();
        }

        #endregion

        public void tick()
        {
            Count();
        }

        #region PLAY / STOP / RESET

        private void Play(Action action, float timeDelay)
        {
            _isPlaying = true;

            _action = action;

            _targetTime = timeDelay;
        }

        private void Stop()
        {
            _isPlaying = false;

            _action = null;
            
            Reset();
        }

        private void Reset()
        {
            Time = 0f;

            _targetTime = 0f;
        }

        #endregion

        private void Count()
        {
            if(!_isPlaying) return;
            
            Time += UnityEngine.Time.deltaTime;
            
            if(Time < _targetTime) return;
            
            _action();
            
            Stop();
        }

        #region POOL STUFF

        public void onCreate()
        {
            Core.Instance.get<ManagerUpdate>().add(this);
            
            Reset();
        }

        public void returnToPool()
        {
            Core.Instance.get<ManagerUpdate>().remove(this);

            Stop();
        }

        #endregion
    }
}