using System;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 类对象池
    /// </summary>
    public class ClassObjectPool : IDisposable
    {
        /// <summary>
        /// 类对象池集合
        /// </summary>
        private Dictionary<int, Queue<object>> mClassObjectPoolDict;

        /// <summary>
        /// 类对象池常驻数量集合
        /// </summary>
        public Dictionary<int, byte> ClassObjectResidentDict { private set; get; }

#if UNITY_EDITOR
        //在监视面板上显示的信息数据
        public Dictionary<Type, int> InspectorDict = new Dictionary<Type, int>();
#endif

        public ClassObjectPool() {
            mClassObjectPoolDict = new Dictionary<int, Queue<object>>();
            ClassObjectResidentDict = new Dictionary<int, byte>();
        }

        /// <summary>
        /// 从对象池中取出一个对象
        /// </summary>
        /// <typeparam name="T">要取出的对象类型</typeparam>
        public T Dequeue<T>() where T : class, new() {
            lock (mClassObjectPoolDict) {
                //先找到这个类型的哈希值
                int key = typeof(T).GetHashCode();
                Queue<object> queue = null;
                mClassObjectPoolDict.TryGetValue(key, out queue);
                if (queue == null) {
                    queue = new Queue<object>();
                    mClassObjectPoolDict[key] = queue;
                }

                //开始从队列中获取对象
                if (queue.Count > 0) {
                    //Debug.Log("从池子中获取对象");
                    object obj = queue.Dequeue();
#if UNITY_EDITOR
                    var type = obj.GetType();
                    if (InspectorDict.ContainsKey(type)) {
                        InspectorDict[type]--;
                    } else {
                        InspectorDict[type] = 0;
                    }
#endif
                    return (T)obj;
                } else {
                    //Debug.Log("池子中没有,生成对象");
                    return new T();
                }

            }
        }

        /// <summary>
        /// 将对象回收进池子中
        /// </summary>
        /// <param name="obj">要回收的对象</param>
        public void Enqueue(object obj) {
            lock(mClassObjectPoolDict) {
                Debug.Log("对象回池:" + obj.GetType().Name);
                int key = obj.GetType().GetHashCode();
                Queue<object> queue = null;
                mClassObjectPoolDict.TryGetValue(key, out queue);
#if UNITY_EDITOR
                var type = obj.GetType();
                if(InspectorDict.ContainsKey(type)) {
                    InspectorDict[type]++;
                } else {
                    InspectorDict[type] = 1;
                }
#endif

                if (queue != null) queue.Enqueue(obj);
            }
        }

        /// <summary>
        /// 设置类对象池的常驻数量
        /// </summary>
        public void SetResidentCount<T>(byte count) where T : class {
            var key = typeof(T).GetHashCode();
            ClassObjectResidentDict[key] = count;
        }

        /// <summary>
        /// 释放类对象池
        /// </summary>
        public void ReleaseClassObjectPool() {
            lock(mClassObjectPoolDict) {
                int queueCount = 0;//队列的数量
                //定义迭代器
                var enumerator = mClassObjectPoolDict.GetEnumerator();
                while (enumerator.MoveNext()) {
                    int key = enumerator.Current.Key;
                    //拿到队列
                    Queue<object> queue = mClassObjectPoolDict[key];
                    queueCount = queue.Count;
#if UNITY_EDITOR
                    Type type = null;
#endif
                    //池中数量大于常驻数量的时候,才进行释放
                    byte residentCount = 0;
                    ClassObjectResidentDict.TryGetValue(key, out residentCount);
                    while (queueCount > residentCount) {
                        //队列中有可释放的对象
                        object obj = queue.Dequeue();//队列中取出一个,这个对象没有任何引用,就变成了野指针,等待GC回收
                        queueCount--;
#if UNITY_EDITOR
                        //编辑器面板上的数据也进行减少
                        type = obj.GetType();
                        InspectorDict[type]--;
#endif
                    }

                    if (queueCount <= 0) {
#if UNITY_EDITOR
                        if (type != null) {
                            InspectorDict.Remove(type);
                        }
#endif
                    }
                }

                //整个项目中,有一处GC即可
                GC.Collect();
            }

        }

        public void Dispose() {
            mClassObjectPoolDict.Clear();
        }

    }
}
