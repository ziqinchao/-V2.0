<%@ Page Language="C#" MasterPageFile="~/UserPage/Person/PersonFrame.Master" AutoEventWireup="true" CodeBehind="idcard.aspx.cs" Inherits="WeyiShow.UserPage.Person.idcard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/stepstyle.css" rel="stylesheet" type="text/css" />

    <div class="am-cf am-padding">
        <div class="am-fl am-cf"><strong class="am-text-danger am-text-lg">实名认证</strong> / <small>Real&nbsp;authentication</small></div>
    </div>
    <hr />
    <div class="authentication">
        <p class="tip">请填写您身份证上的真实信息，以用于报关审核</p>
        <div class="authenticationInfo">
            <p class="title">填写个人信息</p>

            <div class="am-form-group">
                <label for="user-name" class="am-form-label">真实姓名</label>
                <div class="am-form-content">
                    <input type="text" id="user-name" placeholder="请输入您的真实姓名">
                </div>
            </div>
            <div class="am-form-group">
                <label for="user-IDcard" class="am-form-label">身份证号</label>
                <div class="am-form-content">
                    <input type="tel" id="user-IDcard" placeholder="请输入您的身份证信息">
                </div>
            </div>


        </div>

        <div class="authenticationPic">
            <p class="title">上传身份证照片</p>
            <p class="tip">请按要求上传身份证</p>
            <ul class="cardlist">
                <li>
                    <div class="cardPic">
                        <img id="pic" src="../images/cardbgz.png">

                        <input id="upload" name="upload" accept="image/*" type="file" style="display: none" />
                        <p class="titleText">身份证正面</p>
                    </div>
                    <div class="cardExample">
                        <img src="../images/cardbg.jpg">
                        <p class="titleText">示例</p>
                    </div>

                </li>
                <li>
                    <div class="cardPic">
                        <img id="pic1" src="../images/cardbgf.png">
                        <input id="upload1" name="upload1" accept="image/*" type="file" style="display: none" />
                        <p class="titleText">身份证背面</p>
                    </div>
                    <div class="cardExample">
                        <img src="../images/cardbg.jpg">
                        <p class="titleText">示例</p>
                    </div>
                    
                </li>
                <li>
                    <input id="btnUpload" class="am-btn-primary" type="button" value="上传" />
                </li>
            </ul>
        </div>
        <div class="info-btn">
            <div class="am-btn am-btn-danger" onclick="Submit();">提交</div>
        </div>
        <div style="display: none">
            <asp:TextBox ID="userguid1" runat="server"></asp:TextBox>
            <input type="text" id="picz" >
            <input type="text" id="picf" >
        </div>
    </div>


    <%--<input type="file" id="imgfile" onchange="imgPreview(this)" />
    <input type="button" id="btnUpload"  value="上传图片" />
    <div id="imgDiv" runat="server"></div>
    <img src="" id = "img" width="150" height="200"/>  --%>
    <%-- <img id="pic" style="width: 100px; height: 100px; border-radius: 50%; margin: 20px auto; cursor: pointer;"
        src="../images/cardbg.jpg">--%>




    <script type="text/javascript">
        //$(document).ready(function () {
        //    //图片预览  
        //    $("#imgfile").uploadPreview({ imgDiv: "#imgDiv", imgType: ["bmp", "gif", "png", "jpg"], maxwidth: 250, maxheight: 250 });
        //    //上传图片  
        //    $("#btnUpload").click(function () {
        //        $.post("exec/UploadFile.ashx", { upfile: getPath($("#imgfile")) }, function (json) {
        //            //json.result为upload.ashx文件返回的值  
        //            alert(json.result);
        //        }, "json");
        //    });
        //});



        $(function () {
            $("#pic").click(function () {
                $("#upload").click(); //隐藏了input:file样式后，点击头像就可以本地上传
                $("#upload").on("change", function () {
                    var objUrl = getObjectURL(this.files[0]); //获取图片的路径，该路径不是图片在本地的路径
                    if (objUrl) {
                        $("#pic").attr("src", objUrl); //将图片路径存入src中，显示出图片
                    }
                });
            });
        });

        $(function () {
            $("#pic1").click(function () {
                $("#upload1").click(); //隐藏了input:file样式后，点击头像就可以本地上传
                $("#upload1").on("change", function () {
                    var objUrl = getObjectURL(this.files[0]); //获取图片的路径，该路径不是图片在本地的路径
                    if (objUrl) {
                        $("#pic1").attr("src", objUrl); //将图片路径存入src中，显示出图片
                    }
                });
            });
        });


        $("#btnUpload").click(function (evt) {
            var fileUpload = $("#upload").get(0);
            var files = fileUpload.files;

            var fileUpload1 = $("#upload1").get(0);
            var files1 = fileUpload1.files;

            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            for (var i = 0; i < files1.length; i++) {
                data.append(files1[i].name, files1[i]);
            }
            var tex = $(" input[ name='txt' ] ").val()
            data.append('txt', tex);

            $.ajax({
                url: "FileUploadHandler.ashx",
                type: "POST",
                data: data,
                contentType: false,
                processData: false,
                success: function (result) {
                    if (result != null) {
                        alert("上传成功");
                        var arry = result.split('%');
                        $("#picz").val(arry[0]);
                        $("#picf").val(arry[1]);
                        
                    }
                },
                error: function (err) {
                    alert(err.statusText)
                }
            });

            evt.preventDefault();
        });


        //建立一個可存取到該file的url
        function getObjectURL(file) {
            var url = null;
            if (window.createObjectURL != undefined) { // basic
                url = window.createObjectURL(file);
            } else if (window.URL != undefined) { // mozilla(firefox)
                url = window.URL.createObjectURL(file);
            } else if (window.webkitURL != undefined) { // webkit or chrome
                url = window.webkitURL.createObjectURL(file);
            }
            return url;
        }

        function Submit() {
            var pathz = $('#picz').val();
            var pathf = $('#picf').val();
            var username = $("#user-name").val();
            var usercard = $("#user-IDcard").val();
            var userguid = $('#<%=userguid1.ClientID%>').val();
            $.ajax({
                type: "POST",
                url: "UploadFile.ashx?type=Save" + "&pathz=" + pathz + "&pathf=" + pathf + "&userguid=" + userguid + "&username=" + username + "&usercard=" + usercard,
                data: "",
                beforeSend: function () { },
                success: function (msg) {
                    if (msg == 1) {
                        alert("修改成功");
                        location = location;
                    }
                    else {
                        alert("修改失败");
                        location = location;
                    }

                },
                error: function () { alert("网络繁忙，请稍后再试。"); },
                complete: function () { }
            });
        }
    </script>
</asp:Content>
