using System;
using System.IO;
using UnityEngine;
using XLua;

namespace YouYou
{
    /// <summary>
    /// Lua 管理器
    /// </summary>
    public class LuaManager : ManagerBase
    {

        /// <summary>
        /// 全局的xLua引擎
        /// </summary>
        public static LuaEnv luaEnv;

        public void Init() {
            //1.实例化xlua引擎
            luaEnv = new LuaEnv();

#if DISABLE_ASSETBUNDLE
            //2.设置xLua的脚本路径
            luaEnv.DoString(string.Format("package.path = '{0}/?.bytes'", Application.dataPath + "/Download/xLuaLogic/"));
#else
            mLuaEnv.AddLoader(MyLoader);
            //mLuaEnv.DoString(string.Format("package.path = '{0}/?.bytes'", Application.persistentDataPath));
#endif
            luaEnv.DoString("require 'Main'");
        }

        /// <summary>
        /// 自定义的Loader
        /// </summary>
        private byte[] MyLoader(ref string filePath) {
            string path = Application.persistentDataPath + "/" + filePath + ".lua";
            byte[] buffer = null;
            using (FileStream fs = new FileStream(path, FileMode.Open)) {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
            }
            buffer = SecurityUtil.Xor(buffer);
            buffer = System.Text.Encoding.UTF8.GetBytes(System.Text.Encoding.UTF8.GetString(buffer).Trim());
            return buffer;
        }

        /// <summary>
        /// 执行lua脚本
        /// </summary>
        public void DoString(string str) {
            luaEnv.DoString(str);
        }


    }
}
