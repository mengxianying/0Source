function attention()
{
    //�ж��Ƿ��¼
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url:"../WebChipped.asmx/username",
            data:"{}",
            dataType:"json",
            complete:function(result){
                //�ѵ�¼
                if(result.responseText.split('"')[1].split('"')[0]!=0 && result.responseText!=null && result.responseText!="")
                {
                    //��ӹ�ע
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url:"../WebChipped.asmx/Attention",
                        data:"{AName:'"+ $("#Aname").val() +"'}",
                        dataType:"json",
                        complete:function(result){
                            if(result.responseText==0)
                            {
                                alert('���Ѿ���ע������û�');
                                return false;
                            }
                            if(result.responseText==1)
                            {
                                alert('��ע�ɹ�');
                            }
                        }
                    });
                }
                else
                {
                    alert('��û�е�¼,���ȵ�¼');
                }
            }
          });
}


