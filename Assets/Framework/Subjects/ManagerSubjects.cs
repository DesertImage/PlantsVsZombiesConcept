﻿using System.Collections.Generic;using DesertImage.Managers;using DesertImage.Pools;namespace DesertImage.Subjects{    public class ManagerSubjects : ManagerBase, IAwake    {        private readonly List<ISubject> _subjects = new List<ISubject>();        private readonly Pool<ISubject> _pool = new SubjectsPool();        #region PUBLIC METHODS        public void onAwake()        {            _pool.register(new Subject(), 50);        }        public void add(ISubject subject)        {            Add(subject);        }        public ISubject getSubject()        {            return Get();        }        public List<ISubject> getSubjects(HashSet<int> filter)        {            return Get(filter);        }        public void remove(ISubject subject)        {            Remove(subject);        }        #endregion        #region ADD / REMOVE        private void Add(ISubject subject)        {            if (_subjects.Contains(subject)) return;            _subjects.Add(subject);        }        private void Remove(ISubject subject)        {            if (!_subjects.Contains(subject)) return;            _subjects.Remove(subject);        }        #endregion        #region GET        private ISubject Get()        {            var newInstance = _pool.getInstance();            _subjects.Add(newInstance);            return newInstance;        }        private List<ISubject> Get(HashSet<int> filter)        {            var subjects = new List<ISubject>();            foreach (var subject in _subjects)            {                foreach (var component in subject.Components)                {                    var finded = 0;                                        foreach (var i in filter)                    {                        if (i == component)                        {                            finded++;                        }                    }                    if (finded == filter.Count)                    {                        subjects.Add(subject);                    }                }                                var hash = subject.GetType().GetHashCode();                if (!filter.Contains(hash)) continue;                subjects.Add(subject);            }            return subjects;        }        #endregion    }}