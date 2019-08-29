$.confirm = function() {
    $("#alert").remove();
    var $meipian = $("body");
    if (arguments[1] == 'video') {
        $meipian.append('<div id="alert"><div class="win win-video"><div class="title">插入视频</div><div class="inputBox"><input type="text" class="video-src" placeholder="粘贴视频地址" /></div><div class="help"><a href="https://a.meipian.me/4jflb30" target="_blank"></a></div><div class="btn-list clearfix"><button class="fl cancel" onclick="video(this)"></button><button class="fr define videoLast" onclick="video(this)"></button></div></div></div>');
        var mask_layer = $('#alert'),
            confirm = mask_layer.find('.win-video'),
            help = confirm.find('a'),
            device = confirm.find('button');
        var text_message = arguments[0],
            text_sure = arguments[5] || "确定",
            text_cancel = arguments[4] || "取消",
            func_sure = arguments[3] || null,
            func_cancel = arguments[2] || null;

        help.html("如何获得视频地址");
        device.eq(0).html(text_cancel);
        device.eq(1).html(text_sure);

        device.eq(0).click(function() {
            if (func_cancel) {
                func_cancel(this);
            }
        });
        device.eq(1).click(function() {
            if (func_sure) {
                func_sure(this);
            }
        });
    } else if (arguments[1] == 'share') {
        $meipian.append('<div id="alert"><div class="win win-share"><div class="title">文章网页地址</div><input type="text" id="share_src" value="' + arguments[0] + '" disabled /><button class="copy" id="copy" data-clipboard-target="share_src">复制链接</button><div><div id="qrcode"><div><h4>分享到微信朋友圈</h4></div></div><div id="wechat" style="float:left;"><p>打开微信</p><p>使用右上角扫一扫功能扫描左侧的二维码</p><p style="padding-bottom: 0;">打开页面后，点击右上角三个点选择分享到朋友圈</p></div></div><div id="shut">关闭</div></div></div>');
        var qrcode = new QRCode(document.getElementById('qrcode'), {
            width: 140,
            height: 140
        });
        var mask_layer = $("#alert"),
            confirm = mask_layer.find(".win-share"),
            elText = confirm.find("#share_src").val(),
            device = confirm.find(".win-btn a");
        qrcode.makeCode(arguments[0]);
        $('#alert').click(function() {
            $(this).fadeOut(function() {
                $(this).remove();
            })
        });
        $('#shut').click(function() {
            $('#alert').fadeOut(function() {
                $('#alert').remove();
            })
        });
        confirm.click(function(e) {
            e.stopPropagation();
        })
    } else {
        $meipian.append('<div id="alert"><div class="win win-del"><div class="win-message"><p></p></div><div class="win-btn clearfix"><a href="javascript:void(0)" class="fl" id=""></a><a href="javascript:void(0)" class="fl"></a></div></div></div>');

        var mask_layer = $("#alert"),
            confirm = mask_layer.find(".win-del"),
            message = confirm.find(".win-message p"),
            device = confirm.find(".win-btn a");

        var text_message = arguments[0],
            text_sure = arguments[5] || "确定",
            text_cancel = arguments[4] || "取消",
            func_sure = arguments[3] || null,
            func_cancel = arguments[2] || null;

        message.html(text_message);
        device.eq(0).html(text_cancel);
        device.eq(1).html(text_sure);

        device.eq(0).click(function() {
            mask_layer.remove();
            if (func_cancel) {
                func_cancel();
            }
        });
        device.eq(1).click(function() {
            mask_layer.remove();
            if (func_sure) {
                func_sure();
            }
        })
    }
}