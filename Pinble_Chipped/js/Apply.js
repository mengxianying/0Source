function attention()
{
    //判断是否登录
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url:"../WebChipped.asmx/username",
            data:"{}",
            dataType:"json",
            complete:function(result){
                //已登录
                if(result.responseText.split('"')[1].split('"')[0]!=0 && result.responseText!=null && result.responseText!="")
                {
                    //添加关注
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url:"../WebChipped.asmx/Attention",
                        data:"{AName:'"+ $("#Aname").val() +"'}",
                        dataType:"json",
                        complete:function(result){
                            if(result.responseText==0)
                            {
                                alert('您已经关注了这个用户');
                                return false;
                            }
                            if(result.responseText==1)
                            {
                                alert('关注成功');
                            }
                        }
                    });
                }
                else
                {
                    alert('您没有登录,请先登录');
                }
            }
          });
}


