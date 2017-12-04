$.fn.extend({
    /** 
     * 图片上传本地预览 
     * 参数说明： 
     * imgId：image节点对象(必填) 
     * imgType：图片格式限制数组(可选) 
     * callBack：回调函数(可选) 
     * message：图片格式错误时是否弹出消息(可选boolean) 
     */
    imgPreview: function (imgId, imgType, callBack, message) {
        var url = $(this).val();
        var opts = {
            imgType: ["jpg", "jpeg", "gif", "png", "bmp"],
            message: function (statu) {
                if (statu) {
                    alert("您选择的图片有误，仅支持" + this.imgType.join("、") + "图片格式上传！");
                }
            },
            callBack: function (data) { }
        };
        //如果省略了参数，则进行参数转换  
        if ($.isFunction(imgType)) {
            callBack = imgType;
            imgType = opts.imgType;
        } else if ($.type(imgType) === "boolean") {
            message = imgType;
            imgType = opts.imgType;
            callBack = opts.callBack();
        }
        if ($.type(callBack) === "boolean") {
            message = callBack;
            callBack = opts.callBack();
        }
        if (message === undefined) {
            message = true;
        }
        //合并对象  
        opts = $.extend(opts, { "imgType": imgType, "callBack": callBack });
        //图片格式验证  
        if (!RegExp("\.(" + opts.imgType.join("|").toLowerCase() + ")$", "i").test(url.toLowerCase())) {
            //执行回调函数  
            opts.callBack(false);
            //清空file  
            this.defaultValue = "";
            //消息提示  
            opts.message(message);
            return false;
        }
        var img = $("#" + imgId);
        //IE下  
        if ($.browser.msie) {
            //使用滤镜  
            this.select();
            url = document.selection.createRange().text;
            //创建一个div设置背景作为图片预览  
            var newPreview = document.createElement("div");
            newPreview.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale)";
            newPreview.style.width = img.width();
            newPreview.style.height = img.height();
            //使用div标签替换img标签  
            img.replaceWith(newPreview);
            //使用图片  
            newPreview.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = url;
            //other  
        } else {
            if (this[0].files) {
                var file = this[0].files[0];
                if (window.URL != undefined) {
                    url = window.URL.createObjectURL(file);
                } else if (window.webkitURL != undefined) {
                    url = window.webkitURL.createObjectURL(file);
                }
            }
            img.attr("src", url);
        }
        //执行回调函数  
        opts.callBack(true);
        return true;
    }
});