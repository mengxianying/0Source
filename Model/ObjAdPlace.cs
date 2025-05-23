using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    public class ObjAdPlace : IComparer<Pbzx.Model.ObjAdPlace>
    {

        private bool _isDesc = true;


        public bool IsDesc
        {
            get { return _isDesc; }
            set { _isDesc = value; }
        }


        private int _id;
        /// <summary>
        /// �����
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        /// <summary>
        /// �������
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _channel;

        /// <summary>
        /// ����Ƶ��
        /// </summary>
        public string  Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }

        private string _rowAndCol;

        /// <summary>
        /// ����������
        /// </summary>
        public string RowAndCol
        {
            get { return _rowAndCol; }
            set { _rowAndCol = value; }
        }

        private int _placeWidth;
        /// <summary>
        /// ���λ���
        /// </summary>
        public int PlaceWidth
        {
            get { return _placeWidth; }
            set { _placeWidth = value; }
        }

        private int _placeHeight;
        /// <summary>
        /// ���λ�߶�
        /// </summary>
        public int PlaceHeight
        {
            get { return _placeHeight; }
            set { _placeHeight = value; }
        }

        private int _typeID;
        /// <summary>
        /// �����
        /// </summary>
        public int TypeID
        {
            get { return _typeID; }
            set { _typeID = value; }
        }

        private bool _IsOpen;

        public bool IsOpen
        {
            get { return _IsOpen; }
            set { _IsOpen = value; }
        }



        #region IComparer ��Ա
        #endregion


        #region IComparer<PBnet_Product> ��Ա

        public int Compare(ObjAdPlace x, ObjAdPlace y)
        {
            if (IsDesc)
            {
                return x.Channel.CompareTo(y.Channel);
            }
            else
            {
                return y.Channel.CompareTo(x.Channel);
            }
        }

        #endregion

        
    }
}
