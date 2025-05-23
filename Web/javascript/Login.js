var scriptArgs = document.getElementById('testScript').getAttribute('data');
var result = scriptArgs.split('&');


alert(result[0]);
        
            	$.get("reg.aspx",{uName:escape(result[0]),uPwd:escape(result[1]),loginType:result[3],uTime:result[2]},function(data)
                {
                    if(data.split('&')[0] == "true")
                    {
                    alert('aa');                 
                    }
                    else
                    {
                        alert('bb');                   
                    }
                });