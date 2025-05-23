using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    [Serializable]
    public class CM_MainBySoftwareType
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int cMID;

        public int CMID
        {
            get { return cMID; }
            set { cMID = value; }
        }

        private int softInfo;

        public int SoftInfo
        {
            get { return softInfo; }
            set { softInfo = value; }
        }

        private int beginVersion;

        public int BeginVersion
        {
            get { return beginVersion; }
            set { beginVersion = value; }
        }
        private int endVersion;

        public int EndVersion
        {
            get { return endVersion; }
            set { endVersion = value; }
        }

        private string softwareName;

        public string SoftwareName
        {
            get { return softwareName; }
            set { softwareName = value; }
        }

        private string installName;

        public string InstallName
        {
            get { return installName; }
            set { installName = value; }
        }
    }
}
