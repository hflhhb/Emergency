

//**********【START】对URL添加随机参数，防止读缓存版本**************
function getRandURL(url) {
    url = setUrlParam(url, "rannum", getRandomNum(0, 99999999));
    return url;
}

//返回介于Min, Max的随机整
function setUrlParam(oldurl, paramname, pvalue) {
    var reg = new RegExp("(\\?|&)" + paramname + "=([^&]*)(&|$)", "gi");
    var pst = oldurl.match(reg);
    if ((pst == undefined) || (pst == null)) {
        return oldurl + ((oldurl.indexOf("?") == -1) ? "?" : "&") + paramname + "=" + pvalue;
    }

    var t = pst[0];
    var retxt = t.substring(0, t.indexOf("=") + 1) + pvalue;
    if (t.charAt(t.length - 1) == '&') retxt += "&";

    return oldurl.replace(reg, retxt);
}

function getRandomNum(Min, Max) {
    var Range = Max - Min;
    var Rand = Math.random();
    return (Min + Math.round(Rand * Range));
}

function getUrlParam(url, param) {
    var oRegex = new RegExp('[\?&]' + param + '=([^&]+)', 'i');
    //var oMatch = oRegex.exec( window.top.location.search ) ; //获取当前窗口的URL
    var oMatch = oRegex.exec(url);
    if (oMatch && oMatch.length > 1)
        return oMatch[1];  //返回值
    else
        return '';
}
//**********【END】对URL添加随机参数，防止读缓存版本******************

//**********【START】字符串等公用函数**************
//Trim 字符串
function trim(inputString) {
    if (inputString) {
        return inputString.replace(/^ +/, "").replace(/ +$/, "");
    } else {
        return '';
    }
}
//**********【END】字符串等公用函数******************
//检查是否NULL或空字符串
function checkInput_Null(EleID, EleName) {
    var bReturn = true;

    var vO = $("#" + EleID);
    if (vO.length == 0) vO = $("#" + EleID);

    if (vO.length == 0) {
        jqAlert(EleName + '不可以为空!', function (index) {
            layer.close(index);
            vO.focus();
        });

        bReturn = false;
    }
    else {
        var strVal = trim(vO.val());
        if (strVal == '') {
            jqAlert(EleName + '不可以为空!', function (index) {
                layer.close(index);
                vO.focus();
            });

            bReturn = false;
        }
    }
    return bReturn;
}

//美化系统alert提示框。 
function jqAlert(message, vAction) {
    layer.open({
        title: [
            "提示",
            'background-color:blue; color:#fff;'
        ],
        content: message,
        btn: ['确定'],
        yes: function (index) {
            layer.close(index);
            if (vAction) {
                vAction.call();
            }
        }
    }); 
}

//美化系统alert提示框。 
function jqConfirm(message, vAction) {
    layer.open({
        title: [
            "请确认",
            'background-color:blue; color:#fff;'
        ],
        content: message,
        btn: ['确定',"取消"],
        yes: function (index) {
            layer.close(index);
            if (vAction) {
                vAction.call();
            }
        }
    });
}

//提交新增或编辑对话框。
function submitHTMLForm(vURL, htmlFormId, Callback) {
    DialogURL = getRandURL(vURL);
    var vPostData = $("#" + htmlFormId).serialize();

    $.ajax({
        type: "POST",
        url: DialogURL,
        data: vPostData,
        datatype: "html",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8'
    })
    .done(function (data, textStatus, jqXHR) {
        switch (data.statusCode) {
            case "200":

                if (Callback != null) {
                    Callback.call();
                } else {
                    jqAlert(data.message, function () {
                        location.href = location.href;
                    });
                }
                break; 
            default: //权限不够，其他原因
                jqAlert(data.message)
                break;
        }
    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        jqAlert(jqXHR.responseText) //注意，如果str是object，那么需要字符拼接。
    });
}



//初始化自动完成输入框，传递自定义参数。
function setAutoComplete_Name(vUrl, txtInputID, hiddenInputId, vExtraParams, vSelectAction) {
    var txtInput = "#" + txtInputID;
    var hiddenInput = "#" + hiddenInputId;

    vUrl = getRandURL(vUrl);
    $(txtInput).autocomplete(vUrl, {
        minChars: 2,
        width: $(txtInputID).width,
        mustMatch: false,
        autoFill: false,
        max: 100,
        cache: false,
        scrollHeight: 200,
        multiple: false,        
        extraParams:   $.extend({ rnd: function () { return Math.random(); } }, vExtraParams) ,
        dataType: "json",
        parse: function (json) {
            var rows = []; 
            var aData = json.data; 
            if (aData) {
                for (var i = 0; i < aData.length; i++) {
                    rows[i] = {
                        data: aData[i],
                        value: aData[i].Value,
                        result: aData[i].Text
                    };
                }
            } 
            return rows;
        },
        formatItem: function (row, i, n) { 
            var vHTML = "<table class='table fix table-bordered table-responsive'  style='margin:0;' >";
            vHTML += "<tr><colgroup><col style='width:30%;' /><col style='width:45%;' /><col style='width:25%;' /></colgroup>";
            vHTML += "  <td >&nbsp;" + trim(row.Value) + "</td>";
            vHTML += "  <td >&nbsp;" + trim(row.Text) + "</td>";
            vHTML += "  <td >&nbsp;" + trim(row.Desc) + "</td>";
            vHTML += "</tr></table>";

            return vHTML 
        } 
    }).result(function (event, data, value) {
        var vCode = !data ? '' : value;

        if (hiddenInputId) {
            $(hiddenInput).val(vCode);
        }

        if (vSelectAction) {
            vSelectAction.call(this, data, value);
        }
    });
}


//初始化自动完成输入框，传递自定义参数。
function setAutoComplete_Code(vUrl, txtInputID, hiddenInputId, vExtraParams, vSelectAction) {
    var txtInput = "#" + txtInputID;
    var hiddenInput = "#" + hiddenInputId;
    vUrl = getRandURL(vUrl);

    $(txtInput).autocomplete(vUrl, {
        minChars: 2,       
        width: $(txtInputID).width ,    
        mustMatch: false,
        autoFill: false,
        max: 100,
        cache: false,
        scrollHeight: 200,
        multiple: false,
        extraParams: vExtraParams,
        dataType: "json",
        parse: function (json) {
            var rows = []; 
            var aData = json.data;  
            if (aData) {
                for (var i = 0; i < aData.length; i++) {
                    rows[i] = {
                        data: aData[i] ,
                        value: aData[i].Value,
                        result: aData[i].Value
                    };
                }
            } 
            return rows;
        },
        formatItem: function (row, i, n) {
            var vHTML = "<table class='table fix table-bordered table-responsive'  style='margin:0;' >";
            vHTML += "<tr><colgroup><col style='width:30%;' /><col style='width:45%;' /><col style='width:25%;' /></colgroup>";
            vHTML += "  <td >&nbsp;" + trim(row.Value) + "</td>";
            vHTML += "  <td >&nbsp;" + trim(row.Text) + "</td>";
            vHTML += "  <td >&nbsp;" + trim(row.Desc) + "</td>";
            vHTML += "</tr></table>";

            return vHTML
        } 
    }).result(function (event, data, value) {
        var vCode = !data ? '' : value;

        if (hiddenInputId) {
            $(hiddenInput).val(vCode);
        }

        if (vSelectAction) {
            vSelectAction.call(this, data, value);
        }
    });
}

//**********【START】对HTML元素进行Ajax扩展**************
//  .ajaxLink类扩展
$(document).ready(function () {
    
    //通用Ajax加载页面到指定Div
    $("body").on("click", ".ajaxLink", function () {
        var vDataUrl = $(this).attr('data-url'); 
        var vDivTarget = ($(this).attr('data-target'));
        var vDivHidden = ($(this).attr('data-hidden-div'));

        $('#' + vDivTarget).load(getRandURL(vDataUrl), function () {
            if (vDivHidden) {
                $('#' + vDivHidden).css("display", "none");   //列表页隐藏
            }
            $("#" + vDivTarget).css("display", "");    //明细页显示
        });

    });
     
});
//**********【END】对HTML元素进行Ajax扩展******************

//拍照后返回图片路径
function videoUpdated(attachId) { 
    $('#adp_Image').val(attachId);
    $('#arp_Image').val(attachId);
}
 