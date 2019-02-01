﻿using System;using System.Collections.Generic;using DesertImage.Managers;using DesertImage.Subjects;using Framework.Timer;using UnityEngine;using Random = UnityEngine.Random;namespace DesertImage{    public static class FrameworkExtensions    {        #region COLLECTIONS        public static T GetRandomElement<T>(this T[] array)        {            var rand = default(T);            if (array.Length > 0)            {                rand = array[Random.Range(0, array.Length)];            }            return rand;        }        public static T GetRandomElement<T>(this T[,] array)        {            var rand = default(T);            if (array.Length > 0)            {                rand = array[Random.Range(0, array.GetLength(0)), Random.Range(0, array.GetLength(1))];            }            return rand;        }        public static T GetRandomElement<T>(this List<T> list)        {            var rand = default(T);            if (list.Count > 0)            {                rand = list[Random.Range(0, list.Count)];            }            return rand;        }        public static T GetRandomElement<T>(this List<T> list, T exceptElement)        {            var rand = default(T);            if (list.Count <= 0) return rand;            rand = list[Random.Range(0, list.Count)];            if (rand.Equals(exceptElement) && list.Count > 1)            {                rand = GetRandomElement(list, exceptElement);            }            return rand;        }        public static T GetRandomElement<T>(this List<T> list, List<T> exceptList)        {            var rand = default(T);            if (list.Count <= 0) return rand;            rand = list[Random.Range(0, list.Count)];            if (exceptList.Contains(rand) && exceptList.Count < list.Count)            {                rand = list.GetRandomElement(exceptList);            }            return rand;        }        public static T GetLast<T>(this List<T> list)        {            var rand = default(T);            return list.Count <= 0 ? rand : list[list.Count - 1];        }        #endregion        #region EVENTS        public static void Send<T>(this object sender, T arguments = default(T))        {            var manager = Core.Instance.get<ManagerEvents>();            if (manager == null)            {                Debug.LogError("THERE IS NO MANAGER EVENT");                return;            }            manager.send<T>(arguments);        }        public static void Listen<T>(this IListen listener)        {            var manager = Core.Instance.get<ManagerEvents>();            if (manager == null)            {                Debug.LogError("THERE IS NO MANAGER EVENT");                return;            }            manager.add<T>(listener);        }        public static void Unlisten<T>(this IListen listener)        {            var manager = Core.Instance.get<ManagerEvents>();            if (manager == null)            {                Debug.LogError("THERE IS NO MANAGER EVENT");                return;            }            manager.remove<T>(listener);        }        #endregion        #region TIMERS        public static Timer DoActionWithDelay(this object sender, Action action, float delay)        {            var timersManager = Core.Instance.get<ManagerTimers>();            var timer = timersManager.playAction(action, delay);            return timer;        }        #endregion                #region TWEENS        public static LTDescr TweenMove(this Transform transform, Vector3 position, float time = .3f,            LeanTweenType easeType = LeanTweenType.easeOutExpo)        {            if (!transform) return null;            LeanTween.cancel(transform.gameObject);            return LeanTween.move(transform.gameObject, position, time).setEase(easeType);        }        public static LTDescr TweenMove(this Transform transform, Transform targetTransform, float time = .3f,            LeanTweenType easeType = LeanTweenType.easeOutExpo)        {            if (!transform) return null;            LeanTween.cancel(transform.gameObject);            return LeanTween.move(transform.gameObject, targetTransform, time).setEase(easeType);        }        public static LTDescr TweenMoveLocal(this Transform transform, Vector3 position, float time = .3f,            LeanTweenType easeType = LeanTweenType.easeOutExpo)        {            if (!transform) return null;            LeanTween.cancel(transform.gameObject);            return LeanTween.moveLocal(transform.gameObject, position, time).setEase(easeType);        }        public static LTDescr TweenMoveLocalX(this Transform transform, float newX, float time = .3f,            LeanTweenType easeType = LeanTweenType.easeOutExpo)        {            if (!transform) return null;            LeanTween.cancel(transform.gameObject);            return LeanTween.moveLocalX(transform.gameObject, newX, time).setEase(easeType);        }        public static LTDescr TweenMoveLocalX(this Transform transform, float from, float newX, float time = .3f,            LeanTweenType easeType = LeanTweenType.easeOutExpo)        {            if (!transform) return null;            LeanTween.cancel(transform.gameObject);            return LeanTween.moveLocalX(transform.gameObject, newX, time).setFrom(from).setEase(easeType);        }        public static LTDescr TweenMoveY(this Transform transform, float newY, float time = .3f,            LeanTweenType easeType = LeanTweenType.easeOutExpo)        {            if (!transform) return null;            LeanTween.cancel(transform.gameObject);            return LeanTween.moveY(transform.gameObject, newY, time).setEase(easeType);        }        public static LTDescr TweenMoveLocalY(this Transform transform, float newY, float time = .3f,            LeanTweenType easeType = LeanTweenType.easeOutExpo)        {            if (!transform) return null;            LeanTween.cancel(transform.gameObject);            return LeanTween.moveLocalY(transform.gameObject, newY, time).setEase(easeType);        }        public static LTDescr TweenMoveLocalZ(this Transform transform, float newZ, float time = .3f,            LeanTweenType easeType = LeanTweenType.easeOutExpo)        {            if (!transform) return null;            LeanTween.cancel(transform.gameObject);            return LeanTween.moveLocalZ(transform.gameObject, newZ, time).setEase(easeType);        }        public static LTDescr TweenRotate(this Transform transform, Vector3 newRotation, float time = .3f,            LeanTweenType easeType = LeanTweenType.easeOutExpo)        {            return !transform                ? null                : LeanTween.rotate(transform.gameObject, newRotation, time).setEase(easeType);        }        public static LTDescr TweenRotateX(this Transform transform, float newX, float time = .3f,            LeanTweenType easeType = LeanTweenType.easeOutExpo)        {            return !transform                ? null                : LeanTween.rotateX(transform.gameObject, newX, time).setEase(easeType);        }        public static LTDescr TweenRotateLocal(this Transform transform, Vector3 newRotation, float time = .3f,            LeanTweenType easeType = LeanTweenType.easeOutExpo)        {            return !transform                ? null                : LeanTween.rotateLocal(transform.gameObject, newRotation, time).setEase(easeType);        }        public static LTDescr TweenScale(this Transform transform, Vector3 newScale, float time = .3f,            LeanTweenType easeType = LeanTweenType.easeOutExpo)        {            return !transform ? null : LeanTween.scale(transform.gameObject, newScale, time).setEase(easeType);        }        public static LTDescr TweenScale(this Transform transform, Vector3 fromScale, Vector3 newScale,            float time = .3f,            LeanTweenType easeType = LeanTweenType.easeOutExpo)        {            return !transform                ? null                : LeanTween.scale(transform.gameObject, newScale, time).setEase(easeType).setFrom(fromScale);        }        public static LTDescr TweenAlpha(this CanvasGroup canvasGroup, float newAlpha, float time = .3f,            LeanTweenType easeType = LeanTweenType.linear)        {            return !canvasGroup                ? null                : LeanTween.value(canvasGroup.gameObject, value => { canvasGroup.alpha = value; }, canvasGroup.alpha,                        newAlpha, time)                    .setEase(easeType);        }        public static LTDescr TweenShake(this Transform transform, float amplitude = .2f, float duration = .42f,            int loopsCount = 1)        {            return LeanTween.rotateAroundLocal(transform.gameObject,                    new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), z: Random.Range(0f, 1f)),                    amplitude, duration)                .setEase(LeanTweenType.easeShake)                .setLoopClamp(loopsCount);        }        public static LTDescr TweenShakeZ(this Transform transform, float amplitude = .2f, float duration = .42f,            int loopsCount = 1)        {            return LeanTween.rotateAroundLocal(transform.gameObject,                    Vector3.forward,                    Random.Range(-amplitude - .1f, amplitude + .1f), duration)                .setEase(LeanTweenType.easeShake)                .setLoopClamp(loopsCount);        }        #endregion        #region SUBJECTS        public static void AddToSubjects(this ISubject subject)        {            var manager = Core.Instance.get<ManagerSubjects>();            if (manager == null) return;            manager.add(subject);        }        public static void RemoveFromSubjects(this ISubject subject)        {            var manager = Core.Instance.get<ManagerSubjects>();            if (manager == null) return;            manager.remove(subject);        }        public static ISubject GetNewSubject(this object sender)        {            var manager = Core.Instance.get<ManagerSubjects>();            return manager == null ? null : manager.getSubject();        }        public static List<ISubject> GetSubjects(this object sender, HashSet<int> filter)        {            var manager = Core.Instance.get<ManagerSubjects>();            return manager == null ? null : manager.getSubjects(filter);        }        #endregion    }}