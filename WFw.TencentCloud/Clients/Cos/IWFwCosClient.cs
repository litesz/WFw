using COSXML.Transfer;
using System.Collections.Generic;

namespace WFw.TencentCloud.Clients.Cos
{
    public interface IWFwCosClient
    {
        bool TransferUploadBytes(string cosPath, byte[] data, string filename = "", bool isAttachment = false);

        bool DeleteObject(string key);

        bool DeleteMutiObjects(List<string> keys);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">对象在存储桶中的位置标识符，即称对象键</param>
        /// <param name="localDir">本地文件夹</param>
        /// <param name="localFileName">指定本地保存的文件名</param>
        /// <returns></returns>
        COSXMLDownloadTask GetDownloadTask(string key, string localDir, string localFileName);
    }
}
