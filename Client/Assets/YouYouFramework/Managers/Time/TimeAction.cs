using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 计时器
    /// </summary>
    public class TimeAction
    {
        /// <summary>
        /// 定时器是否处于运行状态
        /// </summary>
        public bool IsRunning { private set; get; }

        /// <summary>
        /// 当前的运行时间
        /// </summary>
        private float mCurRunTime;

        /// <summary>
        /// 当前循环次数
        /// </summary>
        private int mCurLoop;

        /// <summary>
        /// 延迟时间
        /// </summary>
        private float mDelayTime;

        /// <summary>
        /// 时间间隔
        /// </summary>
        private float mInterval;

        /// <summary>
        /// 循环次数(-1表示无限循环 0也表示循环1次)
        /// </summary>
        private int mLoop;

        /// <summary>
        /// 运行开始 回调
        /// </summary>
        private Action mOnStart;

        /// <summary>
        /// 运行中 回调(参数表示剩余次数)
        /// </summary>
        private Action<int> mOnUpdate;

        /// <summary>
        /// 运行完成 回调
        /// </summary>
        private Action mOnComplete;

        /// <summary>
        /// 初始化计时器
        /// </summary>
        /// <param name="delayTime">延迟时间</param>
        /// <param name="interval">间隔</param>
        /// <param name="loop">循环次数</param>
        /// <param name="onStart">运行开始 回调</param>
        /// <param name="onUpdate">运行中 回调</param>
        /// <param name="onComplete">运行完成 回调</param>
        public TimeAction Init(float delayTime, float interval, int loop, Action onStart, Action<int> onUpdate, Action onComplete) {
            mDelayTime = delayTime;
            mInterval = interval;
            mLoop = loop;
            mOnStart = onStart;
            mOnUpdate = onUpdate;
            mOnComplete = onComplete;
            mCurLoop = 0;
            IsRunning = false;
            return this;
        }

        public TimeAction Init(float delayTime, Action onStart) {
            mDelayTime = delayTime;
            mInterval = 0;
            mLoop = 0;
            mOnStart = onStart;
            mOnUpdate = null;
            mOnComplete = null;
            mCurLoop = 0;
            IsRunning = false;
            return this;
        }

        /// <summary>
        /// 运行 计时器
        /// </summary>
        public void Run() {

            //将自己加入循环链表中
            GameEntry.Time.RegisterTimeAction(this);
            //设置当前运行时间
            mCurRunTime = Time.time;
        }

        /// <summary>
        /// 暂停 计时器
        /// </summary>
        public void Pause() {
            IsRunning = false;
        }

        /// <summary>
        /// 停止 计时器
        /// </summary>
        public void Stop() {
            if (mOnComplete != null) mOnComplete();
            IsRunning = false;
            GameEntry.Time.RemoveTimeAction(this);
        }

        /// <summary>
        /// 定时器 运行中
        /// </summary>
        public void OnUpdate() {
            if(!IsRunning && Time.time > mCurRunTime + mDelayTime) {
                //当程序执行到这里,表示第一次延迟时间已经过了
                IsRunning = true;
                mCurRunTime = Time.time;
                if (mOnStart != null) {
                    mOnStart();
                }
            }
            if (!IsRunning) return;
            if(Time.time > mCurRunTime) {
                mCurRunTime = Time.time + mInterval;
                if (mOnUpdate != null) {
                    mOnUpdate(mLoop - mCurLoop);
                }
                if(mLoop > -1) {
                    mCurLoop++;
                    if(mCurLoop >= mLoop) {
                        Stop();
                    }
                }
            }
        }

    }
}
