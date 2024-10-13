using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// Lua组件
    /// </summary>
    public class LuaComponent : YouYouBaseComponent
    {
        private LuaManager mLuaManager;

        protected override void OnAwake() {
            base.OnAwake();
            mLuaManager = new LuaManager();
        }

        protected override void OnStart() {
            base.OnStart();
            mLuaManager.Init();
        }

        public override void Shutdown() {
            
        }
    }
}
