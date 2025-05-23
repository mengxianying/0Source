using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage
{
    public partial class IndexChanlCount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindPageConfig();
            }
        }

        private void BindPageConfig()
        {

            PageConfig pageConfig = WebInit.pageConfig;
            //��ҳ����
            txtNews.Text = pageConfig.IndexNewsCount;
            txtBulletin.Text = pageConfig.IndexBulletinCount;
            txtUpdateProduct.Text = pageConfig.IndexNewUpdateProduct;
            txtUpdateSoft.Text = pageConfig.IndexNewUpdateSoft;

            txtSoft.Text = pageConfig.IndexSoft;
            txtSchool.Text = pageConfig.IndexSchool;
            txtBar.Text = pageConfig.IndexBar;
            txtBbs.Text = pageConfig.IndexBbs;

            txtLinkCount.Text = pageConfig.IndexLinkCount;
            LinkCountPic.Text = pageConfig.IndexLinkCountPic;

            //��������

            txtBType.Text = pageConfig.BulletinTypeCount;
            txtBUpdate.Text = pageConfig.BulletinNewUpdateCount;
            txtBNewHot.Text = pageConfig.BulletinNewHotCount;

            //��Ѷ����

            txtNType.Text = pageConfig.NewsTypeCount;
            txtNUpdate.Text = pageConfig.NewsNewUpdateCount;
            txtNNewHot.Text = pageConfig.NewsNewHotCount;

            //���ѧԺ����

            txtShoolType.Text = pageConfig.ScholTypeCount;
            txtScholCenterList.Text = pageConfig.ScholCenterList;
            txtScholHot.Text = pageConfig.ScholHotCount;
            txtScholsoft.Text = pageConfig.Scholsoft;
            txtScholsoure.Text = pageConfig.Scholsoure;

            //Ƶ��������������


            txtBrokerBulletin.Text = pageConfig.BrokerBulletin;

            //�����Ƕ����

            txtSoftLength.Text = pageConfig.SoftLength;
            txtSoftCount.Text = pageConfig.SoftCount;
            txtCstLength.Text = pageConfig.CstLength;
            txtCstCount.Text = pageConfig.CstCount;


            Sourcelegth.Text = pageConfig.Sourcelegth;
            Sourcelie.Text = pageConfig.Sourcelie;
            Sourcecountlegth.Text = pageConfig.Sourcecountlegth;
            Sourcecountlie.Text = pageConfig.Sourcecountlie;
            SourceMlegth.Text = pageConfig.SourceMlegth;
            SourceMlie.Text = pageConfig.SourceMlie;


            Softlength.Text = pageConfig.Softlength;
            Softlie.Text = pageConfig.Softlie;

            Softxzlength.Text = pageConfig.Softxzlength;
            Softxzlie.Text = pageConfig.Softxzlie;

            SoftMlength.Text = pageConfig.SoftMlength;
            SoftMlie.Text = pageConfig.SoftMlie;

            WebFunc.GetModules();

        }

        protected void btnIndex_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            int intWebPageNum = 20;
            if (!int.TryParse(this.txtNews.Text, out intWebPageNum))
            {
                errMsg += "������Ѷ����Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtBulletin.Text, out intWebPageNum))
            {
                errMsg += "��վ��������Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtUpdateProduct.Text, out intWebPageNum))
            {
                errMsg += "������Ʒ����Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtUpdateSoft.Text, out intWebPageNum))
            {
                errMsg += "������Դ����Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtSoft.Text, out intWebPageNum))
            {
                errMsg += "��Դ��������Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtSchool.Text, out intWebPageNum))
            {
                errMsg += "���ѧԺ����Ӧ��Ϊ������";

            }
            if (!int.TryParse(this.txtBar.Text, out intWebPageNum))
            {
                errMsg += "ƴ��������Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtBbs.Text, out intWebPageNum))
            {
                errMsg += "�ȵ���̳����Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtLinkCount.Text, out intWebPageNum))
            {
                errMsg += "������������Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.LinkCountPic.Text, out intWebPageNum))
            {
                errMsg += "ͼƬ��������Ӧ��Ϊ������";
            }
            ///����

            if (!int.TryParse(this.txtBType.Text, out intWebPageNum))
            {
                errMsg += "�����������Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtBUpdate.Text, out intWebPageNum))
            {
                errMsg += "���¹�������Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtBNewHot.Text, out intWebPageNum))
            {
                errMsg += "�ȵ㹫������Ӧ��Ϊ������";
            }

            ///��Ѷ
            if (!int.TryParse(this.txtNType.Text, out intWebPageNum))
            {
                errMsg += "��Ѷ�������Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtNUpdate.Text, out intWebPageNum))
            {
                errMsg += "������Ѷ����Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtNNewHot.Text, out intWebPageNum))
            {
                errMsg += "�ȵ���Ѷ����Ӧ��Ϊ������";
            }

            ///ѧԺ

            if (!int.TryParse(this.txtShoolType.Text, out intWebPageNum))
            {
                errMsg += "���ѧԺ�������Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtScholCenterList.Text, out intWebPageNum))
            {
                errMsg += "���ѧԺ�б�����Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtScholHot.Text, out intWebPageNum))
            {
                errMsg += "�����ȵ�����Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtScholsoft.Text, out intWebPageNum))
            {
                errMsg += "������Ʒ����Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtScholsoure.Text, out intWebPageNum))
            {
                errMsg += "������Դ����Ӧ��Ϊ������";
            }


            if (!int.TryParse(this.txtBrokerBulletin.Text, out intWebPageNum))
            {
                errMsg += "�����˹�������Ӧ��Ϊ������";
            }

            //�����Ƕ
            if (!int.TryParse(this.txtSoftLength.Text, out intWebPageNum))
            {
                errMsg += "�����Ƕ��ʾ����Ӧ��Ϊ������";
            }

            if (!int.TryParse(this.txtSoftCount.Text, out intWebPageNum))
            {
                errMsg += "�����Ƕ��ʾ����Ӧ��Ϊ������";
            }

            if (!int.TryParse(this.txtCstLength.Text, out intWebPageNum))
            {
                errMsg += "������ʾ����Ӧ��Ϊ������";
            }

            if (!int.TryParse(this.txtCstCount.Text, out intWebPageNum))
            {
                errMsg += "������ʾ����Ӧ��Ϊ������";
            }

            if (!int.TryParse(this.Softlength.Text, out intWebPageNum))
            {
                errMsg += "������Ʒ���س���Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.Softlie.Text, out intWebPageNum))
            {
                errMsg += "������Ʒ������Ӧ��Ϊ������";
            }

            if (!int.TryParse(this.Softxzlength.Text, out intWebPageNum))
            {
                errMsg += "������Ʒ���س���Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.Softxzlie.Text, out intWebPageNum))
            {
                errMsg += "������Ʒ������Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.SoftMlength.Text, out intWebPageNum))
            {
                errMsg += "������Ʒ���س���Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.SoftMlie.Text, out intWebPageNum))
            {
                errMsg += "������Ʒ������Ӧ��Ϊ������";
            }

            if (!int.TryParse(this.Sourcelegth.Text, out intWebPageNum))
            {
                errMsg += "����������س���Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.Sourcelie.Text, out intWebPageNum))
            {
                errMsg += "�������������Ӧ��Ϊ������";
            }


            if (!int.TryParse(this.Sourcecountlegth.Text, out intWebPageNum))
            {
                errMsg += "��������س���Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.Sourcecountlie.Text, out intWebPageNum))
            {
                errMsg += "�����������Ӧ��Ϊ������";
            }

            if (!int.TryParse(this.SourceMlegth.Text, out intWebPageNum))
            {
                errMsg += "ÿ��������س���Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.SourceMlie.Text, out intWebPageNum))
            {
                errMsg += "ÿ�����������Ӧ��Ϊ������";
            }




            if (errMsg.Length > 0)
            {
                Page.RegisterStartupScript("����", JS.Alert("���ύ����Ϣ�����´������޸ĺ��ύ��\\r\\n" + errMsg));
                return;
            }

            PageConfig pageConfig = new PageConfig();

            pageConfig.IndexNewsCount = txtNews.Text;
            pageConfig.IndexBulletinCount = txtBulletin.Text;
            pageConfig.IndexNewUpdateProduct = txtUpdateProduct.Text;
            pageConfig.IndexNewUpdateSoft = txtUpdateSoft.Text;

            pageConfig.IndexSoft = txtSoft.Text;
            pageConfig.IndexSchool = txtSchool.Text;
            pageConfig.IndexBar = txtBar.Text;
            pageConfig.IndexBbs = txtBbs.Text;

            pageConfig.IndexLinkCount = txtLinkCount.Text;
            pageConfig.IndexLinkCountPic = LinkCountPic.Text;

            ///����
            pageConfig.BulletinTypeCount = txtBType.Text;
            pageConfig.BulletinNewUpdateCount = txtBUpdate.Text;
            pageConfig.BulletinNewHotCount = txtBNewHot.Text;

            ///��Ѷ
            pageConfig.NewsTypeCount = txtNType.Text;
            pageConfig.NewsNewUpdateCount = txtNUpdate.Text;
            pageConfig.NewsNewHotCount = txtNNewHot.Text;

            ///ѧԺ
            pageConfig.ScholTypeCount = txtShoolType.Text;
            pageConfig.ScholCenterList = txtScholCenterList.Text;
            pageConfig.ScholHotCount = txtScholHot.Text;
            pageConfig.Scholsoft = txtScholsoft.Text;
            pageConfig.Scholsoure = txtScholsoure.Text;

            //Ƶ��������������

            pageConfig.BrokerBulletin = txtBrokerBulletin.Text;

            //�����Ƕ�����޸�
            pageConfig.SoftLength = txtSoftLength.Text;
            pageConfig.SoftCount = txtSoftCount.Text;
            pageConfig.CstLength = txtCstLength.Text;
            pageConfig.CstCount = txtCstCount.Text;



            pageConfig.Softlength = Softlength.Text;
            pageConfig.Softlie = Softlie.Text;
            pageConfig.Softxzlength = Softxzlength.Text;
            pageConfig.Softxzlie = Softxzlie.Text;
            pageConfig.SoftMlength = SoftMlength.Text;
            pageConfig.SoftMlie = SoftMlie.Text;


            pageConfig.Sourcelegth = Sourcelegth.Text;
            pageConfig.Sourcelie = Sourcelie.Text;

            pageConfig.Sourcecountlegth = Sourcecountlegth.Text;
            pageConfig.Sourcecountlie = Sourcecountlie.Text;

            pageConfig.SourceMlegth = SourceMlegth.Text;
            pageConfig.SourceMlie = SourceMlie.Text;



            WebInit.pageConfig = pageConfig;
            BindPageConfig();
        }


    }
}
