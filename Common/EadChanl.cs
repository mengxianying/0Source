using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Common
{
    public enum EadChanl
    {
        /// <summary>
        /// ��ҳ���Żõ�Ƭ
        /// </summary>
       ��ҳ=1,

       /// <summary>
       /// ����
       /// </summary>
       ���� = 2,

         /// <summary>
         /// ����
         /// </summary>       
        ����=3,

       

       /// <summary>
       /// ѧԺ
       /// </summary>
        ѧԺ=4,
        /// <summary>
        /// ƴ����
        /// </summary>

        ƴ���� = 5,
        /// <summary>
        /// ����
        /// </summary>
        ���� = 7,

         /// <summary>
        /// �Ĳ���
        /// </summary>

        �Ĳ��� = 6

    }

    public enum EadClass
    { 
    ///<summary>
    ///ͨ�����
    ///</summary>

        ͼƬ���=0,
        ///<summary>
        ///���ֹ��
        ///</summary>
        
        ���ֹ��=1,
   

        /// <summary>
        /// flash���
        /// </summary>
        flash��� = 3,

        /// <summary>
        /// �������
        /// </summary>
        ������� = 4,
        /// <summary>
        /// �������
        /// </summary>
        ������� = 5,
        /// <summary>
        /// javascript�ű����
        /// </summary>
        JS��� =6
    }

    public enum EadPlaceType
    {
        ///<summary>
        ///��ҳͼƬ
        ///</summary>

        ��ҳͷ��ͼƬ�����= 0,
        ///<summary>
        ///���ֹ��
        ///</summary>

        ��ҳͷ�����ֹ���� = 1,

        ///<summary>
        ///��ҳ�м�_��վ������������
        ///</summary>
        ��ҳ�м�_��վ������������= 2,

        ///<summary>
        /// ��ҳ�м�_�����������
        ///</summary>
        ��ҳ�м�_����������� = 3,
        ///������ҳ
        ����_����ͨ����� = 4

    }

}
