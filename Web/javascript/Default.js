        //html½âÂë
    	function HtmlDecode(text) 
        { 
            return text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>'); 
        }

        function refresh() {
            $("#PresentInformation").html(HtmlDecode(""));
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "/Template/WebService1.asmx/PresentInformation",
                //                data:"{name:'dgplqSlqeoh',password:'dgplqSlqeoh'}",
                data: "{}",
                dataType: "json",
                success: function (data) {
                    $("#PresentInformation").html(data.d);

                }
            });
           
        }
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "/Template/WebService1.asmx/PresentInformation",
                //                data:"{name:'dgplqSlqeoh',password:'dgplqSlqeoh'}",
                data: "{}",
                dataType: "json",
                success: function (data) {
                    //alert(data);
                    //alert(HtmlDecode(data));
                    $("#PresentInformation").html(data.d);

                }
            });

        });