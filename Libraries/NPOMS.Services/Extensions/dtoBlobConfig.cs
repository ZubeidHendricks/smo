using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Extensions
{
    public class dtoBlobConfig
    {
        /// <summary>
        /// only needed when using a User Assigned Identity
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Name of Storage Account
        /// </summary>
        public string Storage01 { get; set; }

        /// <summary>
        /// Name of Container
        /// </summary>
        public string BlobContainer { get; set; }

        /// <summary>
        /// Name and folder path
        /// </summary>
        public string FolderPath01 { get; set; }

        /// <summary>
        /// generated storage account end point
        /// </summary>
        public string BlobContainerEndPoint
        {
            get
            {
                return $"https://{Storage01}.blob.core.windows.net/{BlobContainer}";
            }
        }
        public string DataLakesEndPoint
        {
            get
            {
                return $"https://{Storage01}.dfs.core.windows.net";
            }
        }
    }
}
