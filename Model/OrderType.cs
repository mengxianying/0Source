using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    public enum OrderType
    {
        //0���ж�����1���ն�����2δȷ�ϣ�3δ���4δ������5�Ѹ��6�ѷ�����7��ȡ��
        All = 0,
        Today = 1,
        NoConfirm = 2,
        NoPayed = 3,
        NoPorted = 4,
        HasPayed = 5,
        HasPorted = 6,
        HasCancel = 7
    }
}
