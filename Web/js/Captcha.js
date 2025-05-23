// 需要引用的css样式
var yzm_style = document.createElement('link');
yzm_style.rel = 'stylesheet';
yzm_style.href = 'css/yzm_style.css';
document.head.appendChild(yzm_style);

var bootstrap = document.createElement('link');
bootstrap.rel = 'stylesheet';
bootstrap.href = 'css/bootstrap.min.css';
document.head.appendChild(bootstrap);
// 需要引用的js
//document.write("<script src='js/jquery-1.3.2.js' type='text/javascript' charset='utf-8'></script>");
//滑块验证的图片js，如果图片没有出来请调整'images/Verificate/Pic'的路径
//document.write("<script src='js/longbow20230627.js' type='text/javascript' charset='utf-8'></script>");


// 模态框
document.write("<div class='modal fade' tabindex='-1' role='dialog' id='myModal1' aria-labelledby='myModal1' style='display:none;'>");

document.write("<div class='modal-dialog' role='document' style='margin-top: 20%;'>");
document.write("	<div class='modal-content' >");
document.write("		<div class='modal-header'>");
document.write("			<button type='button' class='close' data-dismiss='modal' aria-label='Close'  onclick='closs()'><span aria-hidden='true'>&times;</span></button>");
document.write("			<h3 class='modal-title' id='gridSystemModalLabel'>滑块验证</h3>");
document.write("		</div>");
document.write("		<div class='modal-body' style='height: 270px;'>");
document.write("			<div class='row'>");
document.write("				<div class='col-md-12'>");
document.write("					<div class='login-yzm-con' >");
document.write("						<div id='captcha'></div>");
document.write("					</div>");
document.write("				</div>");
document.write("			</div>");
document.write("		</div>");
document.write("	</div><!-- /.modal-content -->");
document.write("</div><!-- /.modal-dialog -->");

document.write("</div>");



// 打开滑块验证
function Open_yzm(type) {
    document.getElementById("myModal1").style.display = "block";
    document.getElementById("myModal1").style.opacity = "1";
    document.getElementById("myModal1").style.background = "rgba(0,0,0,0.5)";

    if (typeof sliderCaptcha === 'undefined') {
        // 检测是否为360浏览器兼容模式
        if (navigator.userAgent.indexOf('MSIE') !== -1 ||
			    navigator.userAgent.indexOf('Trident') !== -1 ||
			    (navigator.userAgent.indexOf('360EE') !== -1 && document.documentMode)) {

            alert('请切换到极速模式或使用Chrome/Firefox等现代浏览器');
            // 或者提供切换浏览器模式的指导
        } else {




            $('#captcha').sliderCaptcha(
	    {

	        //var that = $(this);
	        // 设置重复图标使用 Font Awesome 的 redo (重做) 图标
	        repeatIcon: 'fa fa-redo',
	        // 设置验证码图片源的函数，这里返回空字符串
	        setSrc: function () {
	            return '';
	        },
	        // 验证成功时的回调函数
	        onSuccess: function () {

	            //start-cghd
	            if (type == "Email") {
	                var txtEmail = document.getElementById("UcRegBase1_txtEmail").value;
	                if (txtEmail != "") {
	                    document.getElementById("UcRegBase1_txtEmail").readonly = true;

	                    $.get("/reg.aspx", { checkEmail: "checkEmail", email: txtEmail }, function (data) {
	                        if (data == "true") {
	                            closs();
	                            alert("邮件发送成功！");
	                        }
	                        else {
	                            closs();
	                            alert(data);
	                        }
	                    });
	                }
	            }
	            else if (type == "Phone") {
	                var txtPhone = document.getElementById("UcRegBase1_txtQQ").value;
	                if (txtPhone != "") {
	                    document.getElementById("UcRegBase1_txtQQ").readonly = true;
	                    $.get("/reg.aspx", { checkPhone: "checkPhone", phone: txtPhone }, function (data) {
	                        if (data == "true") {
	                            closs();
	                            alert("验证码发送成功");
	                        }
	                        else {
	                            closs();
	                            alert(data);
	                        }
	                    });
	                }
	            }
	            else if (type == "CheckEmailCode") {
	                var txtEmail = document.getElementById("txtEmail").value;
	                if (txtPhone != "") {
	                    document.getElementById("txtEmail").readonly = true;

	                    $.get("/reg.aspx", { CheckEmailCode: "CheckEmailCode", email_RM: txtEmail }, function (data) {
	                        if (data == "true") {
	                            closs();
	                            alert("验证码发送成功");
	                        }
	                        else {
	                            closs();
	                            alert(data);
	                        }
	                    });
	                }
	            }
	            else if (type == "CheckPhone") {
	                var txtPhone = document.getElementById("txtQQ").value;
	                if (txtPhone != "") {
	                    document.getElementById("txtQQ").readonly = true;
	                    $.get("/reg.aspx", { CheckPhoneCode: "CheckPhoneCode", phone: txtPhone }, function (data) {
	                        if (data == "true") {
	                            closs();
	                            alert("验证码发送成功");
	                        }
	                        else {
	                            closs();
	                            alert(data);
	                        }
	                    });
	                }
	            }
	            //end-cghd

	        } //end onSuccess

	        //alert("验证完成");
	        //tosubmit(); // 验证完成后执行的提交函数


	    });  //end siliderCaptcha



        }
    } //end undefined
    else {

        alert('请切换到极速模式或使用Chrome/Firefox等现代浏览器!');
    }
}


// 关闭滑块验证
function closs() {
    //$('#captcha').sliderCaptcha.reset();
    $(".icon-refresh").click();
    document.getElementById("myModal1").style.display = "none";
}



