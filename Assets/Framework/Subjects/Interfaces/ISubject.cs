﻿using System.Collections.Generic;namespace DesertImage.Subjects{    public interface ISubject : IPoolable    {        Dictionary<int, object>.KeyCollection Components { get; }        void add<T>(T component);        void add<T>() where T : new();        void remove<T>();                T get<T>();        void listen<T>(IListen listener);        void unlisten<T>(IListen listener);        void send<T>(T arguments);    }}