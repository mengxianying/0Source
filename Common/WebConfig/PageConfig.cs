using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Common
{
    public struct PageConfig
    {


        //<IndexNewsCount value="18" />
        //<IndexBulletinCount value="10" />
        //<IndexNewUpdateProduct value="10" />
        //<IndexNewUpdateSoft value="10" />

        //<IndexSoft value="8" />
        //<IndexSchool value="8" />
        //<IndexBar value="8" />
        //<IndexBbs value="8" />





        /// <summary>
        /// ��ҳ��������
        /// </summary>
        public string IndexNewsCount;

        /// <summary>
        /// ��ҳ��վ��������
        /// </summary>
        public string IndexBulletinCount;

        /// <summary>
        /// ��ҳ���¸��²�Ʒ����
        /// </summary>
        public string IndexNewUpdateProduct;

        /// <summary>
        /// ��ҳ��ҳ���¸����������
        /// </summary>
        public string IndexNewUpdateSoft;

        /// <summary>
        /// ��ҳ��Դ��������
        /// </summary>
        public string IndexSoft;

        /// <summary>
        /// ��ҳ���ѧԺ����
        /// </summary>
        public string IndexSchool;

        /// <summary>
        /// ��ҳƴ��������
        /// </summary>
        public string IndexBar;

        /// <summary>
        /// ��ҳ�ȵ���̳����
        /// </summary>
        public string IndexBbs;

        /// <summary>
        /// ��ҳ������������
        /// </summary>
        public string IndexLinkCount;

        /// <summary>
        /// ��ҳͼƬ������������
        /// </summary>
        public string IndexLinkCountPic;

        //<BulletinTypeCount value="24" />
        //<BulletinNewUpdateCount value="9"  />
        //<BulletinNewHotCount value="8"  />


        //<NewsTypeCount value="24" />
        //<SchollTypeCount value="8" />   


        /// <summary>
        /// ��վ������ҳ�����ʾ����
        /// </summary>
        public string BulletinTypeCount;

        /// <summary>
        /// ��վ������ҳ������ʾ����
        /// </summary>
        public string BulletinNewUpdateCount;

        /// <summary>
        /// ��վ������ҳ�ȵ���ʾ����
        /// </summary>
        public string BulletinNewHotCount;

        /// <summary>
        /// ������Ѷ��ҳ�����ʾ����
        /// </summary>
        public string NewsTypeCount;

        /// <summary>
        /// ������Ѷ��ҳ������ʾ����
        /// </summary>
        public string NewsNewUpdateCount;

        /// <summary>
        /// ������Ѷ��ҳ�ȵ���ʾ����
        /// </summary>
        public string NewsNewHotCount;

        /// <summary>
        /// ���ѧԺ��ҳ�����ʾ����
        /// </summary>
        public string ScholTypeCount;

        /// <summary>
        /// ���ѧԺ�м��б���ʾ����
        /// </summary>
        public string ScholCenterList;

        /// <summary>
        /// ���ѧԺ��ҳ�ȵ���ʾ����
        /// </summary>
        public string ScholHotCount;

        /// <summary>
        /// ���ѧԺ��ҳ��Ʒ��ʾ����
        /// </summary>
        public string Scholsoft;

        /// <summary>
        /// ���ѧԺ��ҳ��Դ��ʾ����
        /// </summary>
        public string Scholsoure;




        /// <summary>
        /// �����˹���
        /// </summary>
        public string BrokerBulletin;

        /// <summary>
        /// �����Ƕ��ʾ����
        /// </summary>
        public string SoftLength;

        /// <summary>
        ///�����Ƕ��ʾ���� 
        /// </summary>
        public string SoftCount;
        /// <summary>
        /// ������ʾ����
        /// </summary>
        public string CstLength;
        /// <summary>
        /// ������ʾ����
        /// </summary>
        public string CstCount;





        /// <summary>
        /// ������Ʒ��ʾ����
        /// </summary>
        public string Softlength;

        /// <summary>
        /// ������Ʒ��ʾ����
        /// </summary>
        public string Softlie;

        /// <summary>
        /// ��Ʒ������ʾ����
        /// </summary>
        public string Softxzlength;

        /// <summary>
        /// ��Ʒ������ʾ����
        /// </summary>
        public string Softxzlie;


        /// <summary>
        ///���� ��Ʒ������ʾ����
        /// </summary>
        public string SoftMlength;

        /// <summary>
        /// ������Ʒ������ʾ����
        /// </summary>
        public string SoftMlie;



        /// <summary>
        /// ��Դ��ʾ����
        /// </summary>
        public string Sourcelegth;

        /// <summary>
        /// ��Դ��ʾ����
        /// </summary>
        public string Sourcelie;

                /// <summary>
        /// ��Դ��������ʾ����
        /// </summary>
        public string Sourcecountlegth;

        /// <summary>
        /// ��Դ��������ʾ����
        /// </summary>
        public string Sourcecountlie;


                /// <summary>
        /// ������Դ��ʾ����
        /// </summary>
        public string SourceMlegth;

        /// <summary>
        /// ������Դ��ʾ����
        /// </summary>
        public string SourceMlie;
        


    }

    public struct SiteConfig
    {
        public string WebTitle;

        /// <summary>
        /// �������ߺ󱻹���Աɾ�����۳��Ļ���
        /// </summary>

        public string wenkf;

        /// <summary>
        /// �ش����ߺ󱻹���Աɾ�����۳��Ļ���
        /// </summary>

        public string dakf;

        /// <summary>
        /// �û��ش������߲���Ϊ��Ѵ����õĻ���
        /// </summary>

        public string dajiadf;

        /// <summary>
        /// �û�ע��ʱ��õĻ���
        /// </summary>

        public string regf;

        /// <summary>
        /// �û��ش�һ���������õĻ���
        /// </summary>

        public string dadf;

        /// <summary>
        /// ���ⱻѡΪ�����Ƽ����������õĻ���
        /// </summary>
        public string tjwendf;


        /// <summary>
        /// ���ⱻѡΪ�����Ƽ���ѻش������õĻ���
        /// </summary>

        public string tjdadf;


        /// <summary>
        /// �û����������������
        /// </summary>

        public string mdf;


        /// <summary>
        /// ����15���ڲ��������۳��Ļ���
        /// </summary>

        public string gqkf;


        /// <summary>
        /// �����������
        /// </summary>

        public string clwendf;

        /// <summary>
        /// ���������Ϊ��������
        /// </summary>

        public string OverTime;
        /// <summary>
        ///  ���۱�ɾ���������ߵĻ��ֽ����۳���
        /// </summary>


        public string plkf;
        /// <summary>
        /// �����Ƽ���
        /// </summary>

        public string CommendNum;


        /// <summary>
        /// �����ȵ���
        /// </summary>

        public string HotNum;


        /// <summary>
        /// ���ͷ�������
        /// </summary>

        public string PointNum;


        /// <summary>
        /// �������������
        /// </summary>

        public string StateNNum;

        /// <summary>
        /// �½����������
        /// </summary>
        public string StateYNum;

        /// <summary>
        /// ƴ���ɹ���
        /// </summary>
        public string BarBulletin;
    }
    /// <summary>
    /// ��Ʊ������������
    /// �����ˣ�Сΰ
    /// ����ʱ�䣺2010-11-15
    /// </summary>
    public struct MarketConfig
    {
       //--------------------------------��ҳ����------------------------
        /// <summary>
        /// �Ƽ���Ŀ����ʾ����
        /// </summary>
        public string ItemName;
        /// <summary>
        /// �Ƽ���Ŀ����ʾ����
        /// </summary>
        public string ItemCount;

        /// <summary>
        /// �̼����� ��ʾ����
        /// </summary>
        public string ShopName;
        /// <summary>
        /// �̼����� ��ʾ����
        /// </summary>
        public string ShopCount;

        /// <summary>
        /// ��Ŀ������Ϣ ��ʾ����
        /// </summary>
        public string ItemServerName;
        /// <summary>
        /// ��Ŀ������Ϣ ��ʾ����
        /// </summary>
        public string ItemServerCount;
        //-----------------------------------end-----------------------------

        //-----------------------------------����ҳ����----------------------
        /// <summary>
        /// ������ϸ��Ϣ ��ʾ����
        /// </summary>
        public string ParticularName;
        /// <summary>
        /// ������ϸ��Ϣ ��ʾ����
        /// </summary>
        public string ParticularCount;

    }

    /// <summary>
    /// ƽ̨����ʱ������
    /// 2013-01-04
    /// zhouwei
    /// </summary>
    public struct PlatformTimeConfig
    {
        //3D ����ʱ��
        public string FC3DDataTime;

        //���ֲʿ���ʱ��
        public string FC7LCTime;

        //˫ɫ�򿪽�ʱ��
        public string FCSSDataTime;

        //����3 5����ʱ��
        public string TCPL35DataTime;

        //���ǲʿ���ʱ��
        public string TC7XCDataTime;

        //����͸����ʱ��
        public string TCDLTDataTime;

        //ǿ��ִ�п��� ����
        public string LottCompulsory;

        //����ִ�п���ҳ��ʱ��
        public string ExecutionTime;

    }
    /// <summary>
    /// ƽ̨���ֿ�����ֹʱ������
    /// 2013-01-09
    /// </summary>
    public struct PlatformEndTimeConfig
    { 
        //3D ������ֹʱ��
        public string FC3DEndTime;

        //˫ɫ�� ������ֹʱ��
        public string FCSSQEndTime;

        //����3 5 ������ֹʱ��
        public string TCPL35EndTime;
    }

    /// <summary>
    /// ���ƽ̨-��ѡ�������
    /// </summary>
    public struct SwitchConfig
    {
        //������� 
        public string Switch;

        //�ϴ���Χ����
        public string LeastRange;   //��Сע��
        public string MaximumRange; //���ע��

        //��ѡ��� �������� 1000�׻���
        public string InTwo;   //2D ��2λ�����
        public string InOne;   //1D ��1λ�����
        public string InZero;  //0D ��0λ�����

        //����������
        public string InTwoUpperlimit;   //2D����
        public string InTwoLowerlimit;   //2D����

        public string InOneUpperlimit;  //1D����
        public string InOneLowerlimit;  //1D����

        public string InZeroUpperlimit; //0D����
        public string InZeroLowerlimit; //0D����

        //�����������
        public string IntegralTwo;  //2D
        public string IntegralOne;  //1D
        public string IntegralZero; //0D 
        public string IntegralGroup; //ȫ��

        //����������
        public string CoinTwo;  //2D 
        public string CoinOne;  //1D
        public string CoinZero; //0D
        public string CoinGroup;  //ȫ��
    }
    /// <summary>
    /// ���ƽ̨-��ѡ�������
    /// </summary>
    public struct GroupNumConfig
    {

        //�ϴ���Χ����
        public string LeastRange;   //��Сע��
        public string MaximumRange; //���ע��

        //��ѡ��� �������� ��6
        public string InTwo;   //2D ��2λ�����
        public string InOne;   //1D ��1λ�����
        public string InZero;  //0D ��0λ�����

        //��ѡ��� �������� ��3
        public string InTwozt;   //2D ��2λ�����
        public string InOnezt;   //1D ��1λ�����
        public string InZerozt;  //0D ��0λ�����

        //��ѡ��� �������� ����
        public string InTwobz;   //2D ��2λ�����
        public string InOnebz;   //1D ��1λ�����
        public string InZerobz;  //0D ��0λ�����

        //����������
        public string InTwoUpperlimit;   //2D����
        public string InTwoLowerlimit;   //2D����

        public string InOneUpperlimit;  //1D����
        public string InOneLowerlimit;  //1D����

        public string InZeroUpperlimit; //0D����
        public string InZeroLowerlimit; //0D����

        //�����������
        public string IntegralTwo;  //2D
        public string IntegralOne;  //1D
        public string IntegralZero; //0D 
        public string IntegralGroup; //ȫ��

        //����������
        public string CoinTwo;  //2D 
        public string CoinOne;  //1D
        public string CoinZero; //0D
        public string CoinGroup;  //ȫ��
    }
    /// <summary>
    /// ��̨XML���ò���
    /// </summary>
    public struct lottIntegral
    {
        public string h3HitOne;
        public string h3HitTwo;
        public string h3HitThree;

        public string h6HitOne;
        public string h6HitTwo;
        public string h6HitThree;
        public string h6HitFour;
        public string h6HitFive;
        public string h6HitSix;

        public string s3hHit;

        public string s6hHit;

        public string lHit;

        public string l3Hit;

        public string s3lHit;

        public string s6lHit;


        public string h3l61Hit;
        public string h3l60Hit;
        public string h3l51Hit;
        public string h3l50Hit;
        public string h3l41Hit;
        public string h3l40Hit;
        public string h3l31Hit;
        public string h3l30Hit;
        public string h3l21Hit;
        public string h3l20Hit;
        public string h3l11Hit;
        public string h3l01Hit;

        public string h2l61Hit;
        public string h2l60Hit;
        public string h2l51Hit;
        public string h2l50Hit;
        public string h2l41Hit;
        public string h2l40Hit;
        public string h2l31Hit;
        public string h2l30Hit;
        public string h2l21Hit;
        public string h2l20Hit;
        public string h2l11Hit;
        public string h2l01Hit;


        public string ddHit;

        public string sdHitOne;
        public string sdHitTwo;

        public string GroupHit;
        public string dirHit;

        public string sMHitOne;
        public string sMHitTwo;

        public string dKHit;

        public string dhHit;

        public string shHit;

        public string dw5Hit;
        public string dw3Hit;
        public string m5Hit;
    }

}
