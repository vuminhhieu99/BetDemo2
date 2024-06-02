using Bet.Bussiness.Interfaces;
using Bet.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bet.Bussiness.Version1
{
    public class AttachmentBussiness: IAttachmentBussiness
    {

        public readonly string pathImage = BetUtil.GetValueAppSetting("Attactment:pathImage");
        public AttachmentBussiness() {          
        }

        public async Task<byte[]> GetImage(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                string path = $"{BetUtil.RootPath}{this.pathImage}/{fileName}";
                
                byte[] buffer = ReadAllBytes(path);
                return buffer;
            }
            return new byte[0];
        }


        #region handle 
        private byte[] ReadAllBytes(string path)
        {
            byte[] buffer = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            return buffer;
        }
        #endregion
    }
}
