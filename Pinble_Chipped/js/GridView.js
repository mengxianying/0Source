
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
        //获取所有要控制的行
        var AllRows = document.getElementById(GridViewId).getElementsByTagName("tr");
        //设置每一行的背景色和事件，循环从1开始而非0，可以避开表头那一行
       // AllRows[0].style.color="red";
        for(var i=1; i<AllRows.length; i++){
            //设定本行默认的背景色
            AllRows[i].style.backgroundColor = i%2==0?NormalColor:AlterColor;
           
            //如果指定了鼠标指向的背景色，则添加onmouseover/onmouseout事件
            //处于选中状态的行发生这两个事件时不改变颜色
            if(HoverColor != ""){
                AllRows[i].onmouseover = function(){if(!this.selected)this.style.background = HoverColor;}
                if(i%2 == 0){
                    AllRows[i].onmouseout = function(){if(!this.selected)this.style.background = NormalColor;}
                }
                else{
                    AllRows[i].onmouseout = function(){if(!this.selected)this.style.background = AlterColor;}
                }
            }

            //如果指定了鼠标点击的背景色，则添加onclick事件
            //在事件响应中修改被点击行的选中状态
            if(SelectColor != ""){
                AllRows[i].onclick = function(){
                    this.style.background = this.style.background==SelectColor?HoverColor:SelectColor;
                    this.selected = !this.selected;
                }
            }
        }
    }
}