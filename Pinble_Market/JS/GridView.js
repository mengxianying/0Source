
function GridViewColor(myid){

    var GridViewId ="myGridView";
    if(myid != null)
    {
        GridViewId = myid;
    }
    var NormalColor ="#ffffff";
    var AlterColor ="#ffffff";
    var HoverColor="#EAEDF2";
    var SelectColor ="#ffffff";
    if(document.getElementById(GridViewId)=="" || document.getElementById(GridViewId)==null)
    {
        return false;
    }
    else
    {
        //��ȡ����Ҫ���Ƶ���
        var AllRows = document.getElementById(GridViewId).getElementsByTagName("tr");
        //����ÿһ�еı���ɫ���¼���ѭ����1��ʼ����0�����Աܿ���ͷ��һ��
       // AllRows[0].style.color="red";
        for(var i=1; i<AllRows.length; i++){
            //�趨����Ĭ�ϵı���ɫ
            AllRows[i].style.backgroundColor = i%2==0?NormalColor:AlterColor;
           
            //���ָ�������ָ��ı���ɫ�������onmouseover/onmouseout�¼�
            //����ѡ��״̬���з����������¼�ʱ���ı���ɫ
            if(HoverColor != ""){
                AllRows[i].onmouseover = function(){if(!this.selected)this.style.background = HoverColor;}
                if(i%2 == 0){
                    AllRows[i].onmouseout = function(){if(!this.selected)this.style.background = NormalColor;}
                }
                else{
                    AllRows[i].onmouseout = function(){if(!this.selected)this.style.background = AlterColor;}
                }
            }

            //���ָ����������ı���ɫ�������onclick�¼�
            //���¼���Ӧ���޸ı�����е�ѡ��״̬
            if(SelectColor != ""){
                AllRows[i].onclick = function(){
                    this.style.background = this.style.background==SelectColor?HoverColor:SelectColor;
                    this.selected = !this.selected;
                }
            }
        }
    }
}