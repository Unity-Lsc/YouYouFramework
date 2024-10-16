using System.Collections.Generic;
using System.Xml.Linq;

/// <summary>
/// AssetBundle管理类
/// </summary>
public class AssetBundleDAL
{
    /// <summary>
    /// XML路径
    /// </summary>
    private string mXmlPath;

    /// <summary>
    /// 返回的数据集合
    /// </summary>
    private List<AssetBundleEntity> mDataList = null;

    public AssetBundleDAL(string path) {
        mXmlPath = path;
        mDataList = new List<AssetBundleEntity>();
    }

    /// <summary>
    /// 返回XML数据
    /// </summary>
    /// <returns></returns>
    public List<AssetBundleEntity> GetList() {
        mDataList.Clear();

        //1.读取XML,把数据添加到mDataList里面
        XDocument xDoc = XDocument.Load(mXmlPath);
        XElement root = xDoc.Root;
        XElement assetBundleNode = root.Element("AssetBundle");
        IEnumerable<XElement> lst = assetBundleNode.Elements("Item");
        int index = 0;
        foreach (XElement item in lst) {
            AssetBundleEntity entity = new AssetBundleEntity();
            entity.Key = "key" + ++index;
            entity.Name = item.Attribute("Name").Value;
            entity.Tag = item.Attribute("Tag").Value;
            entity.Version = StringUtil.ToInt(item.Attribute("Tag").Value);
            entity.Size = StringUtil.ToLong(item.Attribute("Size").Value);
            entity.ToPath = item.Attribute("ToPath").Value;

            IEnumerable<XElement> pathList = item.Elements("Path");
            foreach (XElement path in pathList)
            {
                entity.PathList.Add(string.Format("Assets/{0}", path.Attribute("Value").Value));
            }
            mDataList.Add(entity);
        }

        return mDataList;
    }

}
