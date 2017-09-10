//请参考JQuery Ajax框架Javascript API规范

function isUnsignedNumeric(strNumber) //正数
{
    var newPar = /^\d+(\.\d+)?$/;
    return newPar.test(strNumber);
}

function isNumericNum(strNumber) //浮点数
{
    var newPar = /^(-?\d+)(\.\d+)?$/;
    return newPar.test(strNumber);
}

function isZInt(strInt) //正整数
{
    var newPar = /^\d+$/;
    return newPar.test(strInt);
}

function is2Char(s) //2位字母
{
    var newPar = /^[a-zA-Z]{2}$/;
    return newPar.test(s);
}

function is2Num(s) //2位数字
{
    ///^(([1-9]\d)|(0[013456789]))$/
    var newPar = /^[0-9]{2}$/;
    return newPar.test(s);
}

//检查是否NULL或空字符串
function checkInput_Null(EleID, EleName) {
    var bReturn = true;

    var vO = $("#" + EleID);
    if (vO.length == 0) vO = $("#" + EleID);

    if (vO.length == 0) { 
        layer.alert(EleName + '不可以为空!',  { icon: 3, title: '信息' },
             function (index) {
                vO.focus();
                layer.close(index);
        });

        bReturn = false;
    }
    else {
        var strVal = trim(vO.val());
        if (strVal == '') { 
            layer.alert(EleName + '不可以为空!', { icon: 9, title: '信息' },
                 function (index) {
                     vO.focus();
                     layer.close(index);
                 });
            bReturn = false;
        }
    }
    return bReturn;
}


//检查输入值是否超出长度
function checkInput_MaxLength(EleID, EleName, MaxLength) {
    var bReturn = true;

    var vO = $("#" + EleID);
    if (vO.length == 0) vO = $("#" + EleID);

    if (vO.length == 0) {
        bReturn = false;
    }
    else {
        var strVal = trim(vO.val());
        if (strVal.length > MaxLength) {
            layer.alert('当前长度为' + strVal.length + '，超过最大长度' + MaxLength + '!',
                function (index) {
                    vO.focus();
                    layer.close(index);
            });
            bReturn = false;
        }
    }
    return bReturn;
}


function FocusElement(EleID) {
    var vO = document.getElementById(EleID);
    if (vO != null) {
        if (vO.tagName.toLowerCase() == "input") {
            vO.focus();
        }
    }
}

//重写dom的focus方法，光标定在最后
function getSelectPos(obj) {
    var esrc = document.getElementById(obj);
    if (esrc == null) {
        esrc = event.srcElement;
    }
    var rtextRange = esrc.createTextRange();
    rtextRange.moveStart('character', esrc.value.length);
    rtextRange.collapse(true);
    rtextRange.select();
}


//**********【START】JS对cookie操作**************************
function setCookie(name, value) {
    var Days = 30;
    var exp = new Date();
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    document.cookie = name + "= " + escape(value) + ";expires= " + exp.toGMTString();
}

function getCookie(sname) {
    var vreturn = null;
    var acookie = document.cookie.split("; ");
    for (var i = 0; i < acookie.length; i++) {
        var arr = acookie[i].split("=");
        if (arr.length == 2 && sname == arr[0]) {
            vreturn = unescape(arr[1]);
            break;
        }
    }
    return vreturn;
}

function delCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(name);
    if (cval != null) document.cookie = name + "= " + cval + ";expires= " + exp.toGMTString();
}

//**********【END】JS对cookie操作****************************
//**********【START】c:填充字符 length:长度******************
//getString(c,length)返回长度为length的字符串，它的所有字符均为c
function padStr(str, len, c, dir) {
    var out = String(str); // 原始字符串
    if (!c) c = "0";       // 如果参数c未定义，则c取默认值“0”
    if (!dir) dir = 1;     // 如果参数dir未定义，则dir取默认值1
    var bArr = (len - out.length).toString(2).split("");
    // 将length转换成2进制数，并转换成数组
    // 例如length为20，对应的2进制数是10100转换为数组bArr为["1","0","1","0","0"]
    var ret = "";
    var step = c; // 初始步长为字符串c
    for (var i = bArr.length - 1; i >= 0; i--)  // 从末位开始连接字符串
    {
        if (bArr[i] == "1") ret += step; // 当前位为1 时，在ret字符串后增加step
        step += step; // 步长加倍
    }
    var pad = ret;
    if (dir > 0) out = pad + out; // 在左侧填充
    else out += pad; // 在右侧填充
    return out;
}

//**********【END】c:填充字符 length:长度******************
//**********【START】返回介于Min, Max的随机整数**************
function getRandomNum(Min, Max) {
    var Range = Max - Min;
    var Rand = Math.random();
    return (Min + Math.round(Rand * Range));
}

//**********【END】返回介于Min, Max的随机整数**************
function getRandURL(url) {
    url = setUrlParam(url, "rannum", getRandomNum(0, 99999999));
    return url;
}


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

 
function getUrlParam(url, param) {
    var oRegex = new RegExp('[\?&]' + param + '=([^&]+)', 'i');
    //var oMatch = oRegex.exec( window.top.location.search ) ; //获取当前窗口的URL
    var oMatch = oRegex.exec(url);
    if (oMatch && oMatch.length > 1)
        return oMatch[1];  //返回值
    else
        return '';
}


//Trim 字符串
function trim(inputString) {
    if (inputString) {
        return inputString.replace(/^ +/, "").replace(/ +$/, "");
    } else {
        return '';
    }
}


//清空Form中的输入值
function clearForm(formName) {

    var formObj = document.forms[formName];
    var formEl = formObj.elements;
    for (var i = 0; i < formEl.length; i++) {
        var element = formEl[i];
        if (element.type == 'submit') { continue; }
        if (element.type == 'reset') { continue; }
        if (element.type == 'button') { continue; }
        if (element.type == 'hidden') { continue; }
        if (element.type == 'text') { element.value = ''; }
        if (element.type == 'textarea') { element.value = ''; }
        if (element.type == 'checkbox') { element.checked = false; }
        if (element.type == 'radio') { element.checked = false; }
        if (element.type == 'select-multiple') { element.selectedIndex = 0; } //-1
        if (element.type == 'select-one' && element.name != 'AppRole') { element.selectedIndex = 0; } //-1
    }
}

/*Javascript设置要保留的小数位数，四舍五入。
 *ForDight(Dight,How):数值格式化函数，Dight要格式化的 数字，How要保留的小数位数。
 *这里的方法是先乘以10的倍数，然后去掉小数，最后再除以10的倍数。
 */
function Round(Dight, How) {
    Dight = Math.round(Dight * Math.pow(10, How)) / Math.pow(10, How);
    return Dight;
}

function clearNoNum(obj) {
    obj.value = obj.value.replace(/[^\d.]/g, "");     //不可以输入负数
    //obj.value = obj.value.replace(/[^-\d.]/g, "");  //可以输入负数
    obj.value = obj.value.replace(/^\./g, "");
    obj.value = obj.value.replace(/\.{2,}/g, ".");
    obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
}

function clearNoNumMinus(obj) {
    obj.value = obj.value.replace(/[^-\d.]/g, "");      //可以输入负数
    obj.value = obj.value.replace(/^\./g, "");
    obj.value = obj.value.replace(/\.{2,}/g, ".");
    obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
}

function getRadioCheckedValue(strName) {
    var strReturn = "";
    var obj = document.getElementsByName(strName);
    for (var i = 0; i < obj.length; i++) {
        if (obj[i].checked) {
            strReturn = obj[i].value;
            break;
        }
    }

    return strReturn;
}

function getCheckedValue(strName, strDot) {

    var strChecked = "";
    var aChk = document.getElementsByName(strName);
    for (var i = 0; i < aChk.length; i++) {
        if (aChk[i].checked) {
            if (strChecked == "") {
                strChecked = aChk[i].value;
            }
            else {
                strChecked = strChecked + strDot + aChk[i].value;
            }
        }
    }
    return strChecked;
}


//HTML表格中展开或或收缩明细区域。实现HTML表格中只有一个展开的明细区域
function expandRow(i) {
    collapseAllRow(i);
    var strRC = document.getElementById("RowImg" + i).src.toLowerCase();
    var iPos = strRC.toLowerCase().indexOf('/img/expand.gif');
    if (iPos != "-1") {
        document.getElementById("RowDetail" + i).style.display = "";
        document.getElementById("RowImg" + i).src = '/img/collapse.gif';
    }
    else {
        document.getElementById("RowDetail" + i).style.display = "none";
        document.getElementById("RowImg" + i).src = '/img/expand.gif';
    }
}

//HTML表格中收缩所有明细区域。
function collapseAllRow(ID) {
    for (var i = 0; i < document.images.length; i++) {
        if (document.images[i].src.toLowerCase().indexOf('/img/collapse.gif') != "-1") {
            if (document.images[i].id.indexOf("RowImg") == 0 && document.images[i].id != "RowImg" + ID) { //本行可以折叠
                var vRowDetail = document.images[i].id.replace("Img", "Detail");
                document.getElementById(vRowDetail).style.display = "none";
                document.images[i].src = '/img/expand.gif';
            }
        }
    }
}


//展开或收缩子行
function expandChildRow(i) {

    collapseAllChildRow(i);
    var strRC = document.getElementById("ChildRowImg" + i).src.toLowerCase();
    var iPos = strRC.toLowerCase().indexOf('/img/expand.gif');
    if (iPos != "-1") {
        document.getElementById("ChildRowDetail" + i).style.display = "";
        document.getElementById("ChildRowImg" + i).src = '/img/collapse.gif';
    }
    else {
        document.getElementById("ChildRowDetail" + i).style.display = "none";
        document.getElementById("ChildRowImg" + i).src = '/img/expand.gif';
    }
}

//HTML表格中收缩所有明细区域。
function collapseAllChildRow(ID) {
    for (var i = 0; i < document.images.length; i++) {
        if (document.images[i].src.toLowerCase().indexOf('/img/collapse.gif') != "-1") {
            if (document.images[i].id.indexOf("ChildRowImg") == 0 && document.images[i].id != "ChildRowImg" + ID) { //本行可以折叠
                var vRowDetail = document.images[i].id.replace("Img", "Detail");
                document.getElementById(vRowDetail).style.display = "none";
                document.images[i].src = '/img/expand.gif';
            }
        }
    }
}

//打开新窗口
function openWindowByUrl(url) {
    var oWin = window.open(url);
    if (oWin == null) alert("对不起,您的浏览器屏蔽了新窗口弹出功能,请启用该功能后重试！");
}


//将Form中的输入值URL序列化，各值之间用&分割。
function getRequestBody(oForm) {
    var aParams = new Array();
    if (oForm == null)
        return false;
    for (var i = 0; i < oForm.elements.length; i++) {
        if (oForm.elements[i].name != '__VIEWSTATE') {
            var sParam

            if (oForm.elements[i].name && oForm.elements[i].name != "")       //优先使用Name生成串，没有name取ID
            {
                sParam = oForm.elements[i].name;
            } else if (oForm.elements[i].id && oForm.elements[i].id != "")  //没有Name或ID的不生成串
            {
                sParam = oForm.elements[i].id;
            }

            if (sParam) {
                if (oForm.elements[i].type == "checkbox" || oForm.elements[i].type == "radio") {
                    if (oForm.elements[i].checked) {
                        sParam += "=";
                        sParam += encodeURIComponent(oForm.elements[i].value);
                        aParams.push(sParam);
                    }
                }
                else {
                    sParam += "=";
                    sParam += encodeURIComponent(oForm.elements[i].value);
                    aParams.push(sParam);
                }
            }
        }
    }
    return aParams.join("&");
}

//将Form中的输入值URL序列化，各值之间用&分割。
function getPostBody(FormID) {
    var vForm = document.forms[0];
    if (typeof (FormID) != "undefined") {
        vForm = document.getElementById(FormID);
    }

    if (!vForm) {
        vForm = document.getElementById(FormID);
    }

    var vPostData = getRequestBody(vForm);
    return vPostData;
}


function getCheckedValue(strName, strDot) {
    var strChecked = "";
    var aChk = document.getElementsByName(strName);
    for (var i = 0; i < aChk.length; i++) {
        if (aChk[i].checked) {
            if (strChecked == "") {
                strChecked = aChk[i].value;
            }
            else {
                strChecked = strChecked + strDot + aChk[i].value;
            }
        }
    }
    return strChecked;
}


//function confirm(vtitle, msg, fun) {
//    layer.confirm(msg, { icon: 3, title: vtitle }, function (index) {
//        layer.close(index);
//        if (fun != undefined) fun();
//    });

//}

//function alert(title, msg, fun) {
//    layer.alert(msg, function (index) {
//        layer.close(index);
//        if (fun != undefined) {
//            fun();
//        } 
//    }); 
//}


function jqAlert(vMessage, vAction) {
    layer.alert(vMessage, function (index) { 
        layer.close(index);
        if (vAction) {
            vAction.call();
        }
    }); 
}

function jqConfirm(vMessage, vAction) { 
    layer.confirm(vMessage, { icon: 3, title: '提示' }, function (index) {
            layer.close(index);
            if (vAction) {
                vAction.call();
            }
    }); 
}


//显示警告提示对话框，用户单击“确定”后调Callback函数。
function jqAlert_YESNO(vMessage, Callback, NoBack) {

    layer.confirm(vMessage, { icon: 3, title: '提示' },
        function (index) {
            layer.close(index);
            if (Callback) {
                Callback.call();
            }
        },

       function (index) {
           layer.close(index);
           if (NoBack) {
            NoBack.call();
            }
        } 
    );
     
}

//显示带输入框的确认提示对话框，用户单击“确定”后调Callback函数。 
function jqConfirmWithInput(strMsg, vTitle, Callback) {
    layer.prompt({
        title: strMsg,
        formType: 1 //prompt风格，支持0-2
    }, function (pass) {
        if (Callback) {
            Callback.call(pass);
        }
    });
     
}

//控制按钮是否可用的函数.
function setDialogBtnEnable(buttonText, enable) {
    if (buttonText == "" || buttonText == null) return;

    var dlgButton = $('.ui-dialog-buttonpane button'); //全选所有dialog的按钮
    dlgButton.each(function () { 
        if (this.firstChild) {
            if (this.firstChild.innerHTML == buttonText) {
                if (enable) {
                    $(this).button("option", "disabled", false);
                } else {
                    $(this).button("option", "disabled", true);
                }
            }
        }
    });
}

//显示对话框，只有“确定/取消”按钮，用户单击“确定”后调OkAction函数。
function showDialog(DialogTitle, DialogURL, Width, Height)
{ 
    DialogURL = getRandURL(DialogURL);
    //Ajax获取
    $.get ( DialogURL , {}, function (strHtml) {
        layer.open({
            type: 1,
            title: DialogTitle,
            shadeClose: true,
            shade: false,
            maxmin: true, //开启最大化最小化按钮
            area: [Width, Height],
            content: strHtml //注意，如果str是object，那么需要字符拼接。
        });
    }); 
}


function showDivDialog(DialogTitle, divId, Width, Height)
{
    //debugger;
    var dialogId = "#" + divId;
       
    layer.open({
        type: 1,
        title: DialogTitle,
        shadeClose: true,
        shade: false,
        maxmin: false, //开启最大化最小化按钮
        area: [Width, Height],
        content: $("#" + divId)
    });
}
 
//初始化日期输入框。
function setDatePickerById(txtInputId) {
    var txtInput = "#" + txtInputId;
    $(txtInput).datePicker({
        clickInput: true,
        createButton: false,
        displayClose: false,
        startDate: '2000-01-01'
    }).trigger('change');
}


//刷新列表区域
function refreshList(vContainDivId, vTableDivId) {

    var vListURL = $("#" + vTableDivId).attr("data-url");

    $.post(vListURL, {}, function (strHtml) {
        $("#" + vContainDivId).html(strHtml);     //刷新查询结果
    });
}

function refreshDiv(vContainDivId, vTableDivId, currPage)
{
    var vDiv_Data_Url = $("#" + vTableDivId).attr("data-url"); 

    if (currPage) {
        vDiv_Data_Url = setUrlParam(vDiv_Data_Url, "pageNo", currPage);
    }

    $.post(vDiv_Data_Url, {}, function (strHtml) {
        $("#" + vContainDivId).html(strHtml);     //刷新查询结果
    });
}

//实现Ajax翻页跳转功能，并刷新refreshTableId代表的数据表。
function gotoPage(gotoPageURL, refreshTableId, Callback) {
    
    var refreshTable = "#" + refreshTableId;

    $.ajax({
        type: "POST",
        url: gotoPageURL,
        data: {rnd: getRandomNum(1, 999999)},
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        datatype: "html"
    })
    .done(function (html, textStatus, jqXHR) {
        $(refreshTable).html(html);     //刷新查询结果  
        if (Callback != null) {
            Callback.call();
        }
    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        layer.open({
            type: 1,
            title: "错误信息",
            shadeClose: true,
            shade: false,
            maxmin: true, //开启最大化最小化按钮
            area: ['800px', '600px'],
            content: jqXHR.responseText //注意，如果str是object，那么需要字符拼接。
        });
    }); 
}

//提交searchFormId代表的搜索条件Form,并刷新refreshTableId代表的数据表。
function doSearch(vSearchURL, searchFormId, refreshTableId) {

    var refreshTable = "#" + refreshTableId;
    
    var vPostData = $("#" + searchFormId).serialize(); //弹出的Dialog获取其所辖值时需要指明Form ID, 否则获取缺省的第一个的
    if (vSearchURL.indexOf("?") >= 0) {
        vSearchURL = vSearchURL + "&" + vPostData + "&searchFormId=" + searchFormId;
    } else {
        vSearchURL = vSearchURL + "?" + vPostData + "&searchFormId=" + searchFormId;
    }
    var vURL = getRandURL(vSearchURL);

    $.ajax({
        type: "POST",
        url: vURL,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        datatype: "html"
    }) 
    .done(function (html, textStatus, jqXHR) {
        $(refreshTable).html(html);     //刷新查询结果  
    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        layer.open({
            type: 1,
            title: "错误信息",
            shadeClose: true,
            shade: false,
            maxmin: true, //开启最大化最小化按钮
            area: ['800px', '600px'],
            content: jqXHR.responseText //注意，如果str是object，那么需要字符拼接。
        });
    });
}


//提交新增或编辑对话框。
function submitHTMLForm(vURL, htmlFormId, Callback) {
    DialogURL = getRandURL(vURL);
    var vPostData = $("#" + htmlFormId).serialize() ;

    $.ajax({
        type: "POST",
        url: DialogURL,
        data: vPostData,
        datatype: "html",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8'
    }) 
    .done(function(data, textStatus, jqXHR) { 
        switch (data.statusCode) {
            case "200":
                if (Callback != null) {
                    Callback.call();
                } else { 
                    layer.alert(data.message, function (index) { layer.close(index); location.href = location.href; });
                }
                break;
            case "301": //超时
                layer.alert(data.message, function (index) { layer.close(index); location.href = "/Login.aspx"; });
                break;
            default: //权限不够，其他原因
                layer.alert(data.message, function (index) {layer.close(index)});
                break;
        } 
    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        layer.open({
            type: 1,
            title: "错误信息",
            shadeClose: true,
            shade: false,
            maxmin: true, //开启最大化最小化按钮
            area: ['800px', '600px'],
            content: jqXHR.responseText //注意，如果str是object，那么需要字符拼接。
        });
    }); 
}


//提交新增或编辑对话框，并提交大数据vData。
function submitHTMLForm2(vURL, htmlFormId, vData, Callback) {
    DialogURL = getRandURL(vURL);
    var vPostData = $("#" + htmlFormId).serialize();
    vPostData = vPostData + "&" + vData;

    $.ajax({
        type: "POST",
        url: DialogURL,
        data: vPostData,
        datatype: "html",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8'
    })
    .done(function(data, textStatus, jqXHR) { 
        switch (data.statusCode) {
            case "200":
                if (Callback != null) {
                    Callback.call();
                } else { 
                    layer.alert(data.message, function (index) { layer.close(index); location.href = location.href; });
                }
                break;
            case "301": //超时
                layer.alert(data.message, function (index) { layer.close(index); location.href = "/Login.aspx"; });
                break;
            default: //权限不够，其他原因
                layer.alert(data.message, function (index) {layer.close(index)});
                break;
        } 
    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        layer.open({
            type: 1,
            title: "错误信息",
            shadeClose: true,
            shade: false,
            maxmin: true, //开启最大化最小化按钮
            area: ['800px', '600px'],
            content: jqXHR.responseText //注意，如果str是object，那么需要字符拼接。
        });
    });  
}


//根据数据库记录ID,删除记录。并回调Callback 
function delRecordByID(vURL, ID, Callback) {
    DialogURL = getRandURL(vURL);
    $.ajax({
        type: "POST",
        url: DialogURL,
        data: "ID=" + ID + "&rnd=" + getRandomNum(1, 999999),
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        datatype: "json"
    })
    .done(function(data, textStatus, jqXHR) { 
            switch (data.statusCode) {
                case "200":
                    if (Callback != null) {
                        layer.alert(data.message, function (index) { layer.close(index); Callback.call(); });
                    } else { 
                        layer.alert(data.message, function (index) { layer.close(index); location.href = location.href; });
                    }
                    break;
                case "301": //超时
                    layer.alert(data.message, function (index) { layer.close(index); location.href = "/Login.aspx"; });
                    break;
                default: //权限不够，其他原因
                    layer.alert(data.message, function (index) {layer.close(index)});
                    break;
            } 
    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        layer.open({
            type: 1,
            title: "错误信息",
            shadeClose: true,
            shade: false,
            maxmin: true, //开启最大化最小化按钮
            area: ['800px', '600px'],
            content: jqXHR.responseText //注意，如果str是object，那么需要字符拼接。
        });
    });
}

//根据数据库记录ID,做服务单业务动作。并回调Callback 
function doActionByID(vURL, ID, Callback) {
    DialogURL = getRandURL(vURL);
    $.ajax({
        type: "POST",
        url: DialogURL,
        data: "ID=" + ID + "&rnd=" + getRandomNum(1, 999999),
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        datatype: "json"
     })
     .done(function(data, textStatus, jqXHR) { 
         switch (data.statusCode) {
             case "200":
                 if (Callback != null) {
                     Callback.call();
                 } else { 
                     layer.alert(data.message, function (index) { layer.close(index); location.href = location.href; });
                 }
                 break;
             case "301": //超时
                 layer.alert(data.message, function (index) { layer.close(index); location.href = "/Login.aspx"; });
                 break;
             default: //权限不够，其他原因
                 layer.alert(data.message, function (index) {layer.close(index)});
                 break;
         } 
     })
    .fail(function (jqXHR, textStatus, errorThrown) {
        layer.open({
            type: 1,
            title: "错误信息",
            shadeClose: true,
            shade: false,
            maxmin: true, //开启最大化最小化按钮
            area: ['800px', '600px'],
            content: jqXHR.responseText //注意，如果str是object，那么需要字符拼接。
        });
    });
}



//根据URL,做服务单业务动作。并回调Callback 
function doAction(vURL, Callback) {
    DialogURL = getRandURL(vURL);
    $.ajax({
        type: "POST",
        url: DialogURL,
        data: "&rnd=" + getRandomNum(1, 999999),
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        datatype: "json" 
    }).done(function (data, textStatus, jqXHR) {
        switch (data.statusCode) {
            case "200":
                if (Callback != null) {
                    Callback.call();
                } else {
                    layer.alert(data.message, function (index) { layer.close(index); location.href = location.href; });
                }
                break;
            case "301": //超时
                layer.alert(data.message, function (index) { layer.close(index); location.href = "/Login.aspx"; });
                break;
            default: //权限不够，其他原因
                layer.alert(data.message, function (index) { layer.close(index) });
                break;
        }
    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        layer.open({
            type: 1,
            title: "错误信息",
            shadeClose: true,
            shade: false,
            maxmin: true, //开启最大化最小化按钮
            area: ['800px', '600px'],
            content: jqXHR.responseText //注意，如果str是object，那么需要字符拼接。
        });
    });
}

//根据URL,做服务单业务动作。并回调Callback 
function doActionByPost(vURL, vPostData, Callback) {
    DialogURL = getRandURL(vURL);
    $.ajax({
        type: "POST",
        url: DialogURL,
        data: vPostData,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        datatype: "json"
    })
    .done(function (data, textStatus, jqXHR) {
            switch (data.statusCode) {
                case "200":
                    if (Callback != null) {
                        Callback.call();
                    } else { 
                        layer.alert(data.message, function (index) { layer.close(index); location.href = location.href; });
                    }
                    break;
                case "301": //超时
                    layer.alert(data.message, function (index) { layer.close(index); location.href = "/Login.aspx"; });
                    break;
                default: //权限不够，其他原因
                    layer.alert(data.message, function (index) {layer.close(index)});
                    break;
            } 
        })
    .fail(function (jqXHR, textStatus, errorThrown) {
        layer.open({
            type: 1,
            title: "错误信息",
            shadeClose: true,
            shade: false,
            maxmin: true, //开启最大化最小化按钮
            area: ['800px', '600px'],
            content: jqXHR.responseText //注意，如果str是object，那么需要字符拼接。
        });
    });
}



//根据URL得到JSON数据
function getJSONByURL(vURL, Callback) {
    var vURL = getRandURL(vURL);
    $.ajax({
        type: "GET",
        url: vURL,
        datatype: "json",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8'
    })
    .done(function(data, textStatus, jqXHR) { 
        switch (data.statusCode) {
            case "200":
                if (Callback != null) {
                    Callback.call(data, data);
                } else { 
                    layer.alert(data.message, function (index) { layer.close(index); location.href = location.href; });
                }
                break;
            case "301": //超时
                layer.alert(data.message, function (index) { layer.close(index); location.href = "/Login.aspx"; });
                break;
            default: //权限不够，其他原因
                layer.alert(data.message, function (index) {layer.close(index)});
                break;
        } 
    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        layer.open({
            type: 1,
            title: "错误信息",
            shadeClose: true,
            shade: false,
            maxmin: true, //开启最大化最小化按钮
            area: ['800px', '600px'],
            content: jqXHR.responseText //注意，如果str是object，那么需要字符拼接。
        });
    }); 
}

function askQuit() {
    layer.confirm("点击[确定]将退出你的登录状态，[取消]不退出。", function () {
        layer.msg("正在退出，请稍候...");
        location.href = "/Global/misc/logout.aspx";
    });
}

function setAutoComplete(vID, vURL, vSelectAction, vWidth, vDescID, vPositionMy, vPositionAt) {
    var vMy = "left top";
    var vAt = "left bottom";
    if (vPositionMy) {
        vMy = vPositionMy;
    }
    if (vPositionAt) {
        vAt = vPositionAt;
    }
    $("#" + vID).autocomplete({
        position: { my: vMy, at: vAt },
        select: function (event, ui) {
            if (vSelectAction) {
                vSelectAction.call(this, ui);
            }
            else {
                if (vDescID) {
                    $("#" + vDescID).val(ui.item.desc);
                }
            }
        },
        source: function (request, response) {
            var vRandUrl = getRandURL(vURL);
            $.post(vRandUrl, { key: request.term, pageSize: 20 }, function (data) {
                response(data);
            }, "json");
        }
    }).data("autocomplete")._renderItem = function (ul, item) {
        var vHTML = "<table width='100%' cellpadding='0' cellspacing='0' style='margin:0;'>";
        vHTML += "<tr><colgroup><col style='width:35%;' /><col style='width:65%;' /></colgroup>";
        vHTML += "<td style='border-bottom:1px solid #CCCCCC;'>&nbsp;" + item.value + "</td>";
        vHTML += "<td style='border-left:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;'>&nbsp;" + item.desc + "</td>";
        vHTML += "</tr></table>";

        return $("<li style='width:" + vWidth + "px;'></li>")
                .append($("<a style='margin:0;padding:0;'></a>").html(vHTML))
                .appendTo(ul);
    };
}


function setJqueryUIAutoComplete(vID, vURL, vSelectAction, vWidth, vDescID, vPositionMy, vPositionAt) {
    var vMy = "left top";
    var vAt = "left bottom";
    if (vPositionMy) {
        vMy = vPositionMy;
    }
    if (vPositionAt) {
        vAt = vPositionAt;
    }
    $("#" + vID).autocomplete({
        position: { my: vMy, at: vAt },
        select: function (event, ui) {
            //设置输入框的值
            if (ui.item && ui.item.value) { $(this).val(ui.item.value); }

            if (vSelectAction) {
                vSelectAction.call(this, ui);
            }
            else {
                if (vDescID) {
                    $("#" + vDescID).val(ui.item.desc);
                }
            }
        },
        source: function (request, response) {
            var vRandUrl = getRandURL(vURL);
            $.post(vRandUrl, { key: request.term, pageSize: 20 }, function (data) {
                response(data);
            }, "json");
        }
    }).data("autocomplete")._renderItem = function (ul, item) {
        var vHTML = "<table width='100%' cellpadding='0' cellspacing='0' style='margin:0;'>";
        vHTML += "<tr><colgroup><col style='width:45%;' /><col style='width:55%;' /></colgroup>";
        vHTML += "<td style='border-bottom:1px solid #CCCCCC;'>&nbsp;" + item.value + "</td>";
        vHTML += "<td style='border-left:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;'>&nbsp;" + item.desc + "</td>";
        vHTML += "</tr></table>";

        return $("<li style='width:" + vWidth + "px;'></li>")
                .append($("<a style='margin:0;padding:0;'></a>").html(vHTML))
                .appendTo(ul);
    };
}

//JQueryUI零件AutoComplete 框,显示简码、名称、图号三列
function setJqueryUIPartAutoComplete(vID, vURL, vSelectAction, vWidth, vDescID, vPositionMy, vPositionAt) {
    var vMy = "left top";
    var vAt = "left bottom";
    if (vPositionMy) {
        vMy = vPositionMy;
    }
    if (vPositionAt) {
        vAt = vPositionAt;
    }
    $("#" + vID).autocomplete({
        position: { my: vMy, at: vAt },
        select: function (event, ui) {
            //设置输入框的值
            if (ui.item && ui.item.value) { $(this).val(ui.item.value); }

            if (vSelectAction) {
                vSelectAction.call(this, ui);
            }
            else {
                if (vDescID) {
                    $("#" + vDescID).val(ui.item.desc);
                }
            }
        },
        source: function (request, response) {
            var vRandUrl = getRandURL(vURL);
            $.post(vRandUrl, { key: request.term, pageSize: 20 }, function (data) {
                response(data);
            }, "json");
        }
    }).data("autocomplete")._renderItem = function (ul, item) {
        var vHTML = "<table width='100%' cellpadding='0' cellspacing='0' style='margin:0;' >";
        vHTML += "<tr><colgroup><col style='width:20%;font-size:small;'  /><col style='width:45%;font-size:small;' /><col style='width:35%;font-size:small;' /></colgroup>";
        vHTML += "<td style='border-bottom:1px solid #CCCCCC;'>&nbsp;" + item.value + "</td>";
        vHTML += "<td style='border-left:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;'>&nbsp;" + item.desc + "</td>";
        vHTML += "<td style='border-left:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;'>&nbsp;" + item.pt__chr01 + "</td>";
        vHTML += "</tr></table>";

        return $("<li style='width:" + vWidth + "px;'></li>")
                .append($("<a style='margin:0;padding:0;'></a>").html(vHTML))
                .appendTo(ul);
    };
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
        extraParams: $.extend({ rnd: function () { return Math.random(); } }, vExtraParams),
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
        width: $(txtInputID).width,
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
                        data: aData[i],
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
 
//begin  ----下载文件---- 
function downloadFile(divURL) {
    //获得页面查询的URL
    var linkurl = getRandURL(divURL);
    if ($('#downloadiframe').length > 0) $('#downloadiframe').remove();
    $('body').append("<iframe id='downloadiframe' style='display:none'></iframe>");
    $('#downloadiframe').attr('src', linkurl);
}
//end ----下载文件----


//导出查询或报表
function DownloadReport() {

    var chk1 = layer.confirm("点击“确定”将导出数据,点击“取消”不导出.", function () {

        //获得页面查询的URL
        var linkurl = $("#queryurl_hidden").val();
        linkurl += "&action=export&rnd=" + getRandomNum(1, 999999);
        //alert(linkurl);

        if ($('#downloadiframe').length > 0) $('#downloadiframe').remove();
        $('body').append("<iframe id='downloadiframe' style='display:none'></iframe>");
        $('#downloadiframe').attr('src', linkurl);

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