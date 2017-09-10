(function ($) {
    $.fn.tabgrid = function (options) {
        $.fn.tabgrid.opts = $.extend({}, $.fn.tabgrid.defaults, options);
        var settings = $.fn.tabgrid.opts;

        var arrHTML = new Array();
        //处理
        arrHTML.push("<table id='" + settings.tabID + "' border='1' cellpadding='0' cellspacing='0' class='tab_grid' style='width:" + settings.tabWidth + ";'>");
        arrHTML.push("<colgroup>");
        //多选框
        if (settings.multiselect) {
            arrHTML.push("<col style='width:3%;' />");
        }
        //详细
        if (settings.detail && settings.detail.isShow) {
            arrHTML.push("<col style='width:" + (!isNaN(settings.detail.width) ? settings.detail.width + 'px' : settings.detail.width) + ";' />");
        }
        $(settings.colModel).each(function () {
            if (this.width) {
                arrHTML.push("<col style='width:" + (!isNaN(this.width) ? this.width + 'px' : this.width) + ";' />");
            }
            else {
                arrHTML.push("<col style='width:;' />");
            }
        });
        arrHTML.push("</colgroup>");
        arrHTML.push("<thead>");
        arrHTML.push("<tr class='tr_css'>");
        //多选框
        //if (settings.multiselect) {
        //    arrHTML.push("<th><input type='checkbox' id='multiselect_tabgrid' onclick='allSelectGridCkb(this.id, \"" + settings.tabID + "\");' /></th>");
        //}
        //详细
        if (settings.detail && settings.detail.isShow) {
            arrHTML.push("<th>&nbsp;</th>");
        }
        $(settings.colModel).each(function () {
            arrHTML.push("<th>" + (this.display ? this.display : "") + "</th>");
        });
        arrHTML.push("</tr>");
        arrHTML.push("</thead>");
        arrHTML.push("<tbody>");
        arrHTML.push("</tbody>");
        arrHTML.push("</table>");
        $("#" + settings.appendTo).css("height", settings.appendHeight);
        $("#" + settings.appendTo).html(arrHTML.join(''));

        if (settings.url) {
            $.fn.tabgrid.reload({});
        }
        if (settings.pageTo) {
            setPageHTML(0, 0, 0);
        }
    }

    $.fn.tabgrid.defaults = {
        appendTo: 'maingrid',
        appendHeight: '100%',
        tabID: 'tabGrid',
        tabWidth: '100%',
        data: null,
        colModel: null,
        pageTo: 'gridpage',
        pageSize: 20,
        page: 1,
        rowList: [10, 20, 30, 40],
        multiselect: false,
        detail: { isShow: false, onShowDetail: null },
        complete: null
    };

    $.fn.tabgrid.opts = {};

    $.fn.tabgrid.reload = function (options) {
        $.fn.tabgrid.opts = $.extend({}, $.fn.tabgrid.opts, options);
        var settings = $.fn.tabgrid.opts;
        if (!settings.url) {
            return false;
        }

        //添加加载数据等待
        var vColsLength = settings.colModel.length;
        if (settings.detail && settings.detail.isShow) {
            vColsLength++;
        }
        if (settings.multiselect) {
            vColsLength++;
        }
        document.getElementById(settings.appendTo).scrollTop = 0;
        var vMaskHTML = "<tr><td colspan='" + vColsLength + "'>";
        vMaskHTML += "<div name='mask' class='mask_bg'></div>";
        vMaskHTML += "<div name='mask' class='mask_show'>正在加载...</div>";
        vMaskHTML += "</td></tr>";
        $("#" + settings.tabID + " tbody").append(vMaskHTML);

        settings.pageSize = $("#page_setsize").val() ? $("#page_setsize").val() : settings.pageSize;
        var vAjaxUrl = settings.url;
        if (vAjaxUrl.indexOf('?') < 0) {
            vAjaxUrl += "?page=" + settings.page + "&rows=" + settings.pageSize;
        }
        else {
            vAjaxUrl += "&page=" + settings.page + "&rows=" + settings.pageSize;
        }
        vAjaxUrl = getRandURL(vAjaxUrl);
        try {
            $.pubAjax({
                url: vAjaxUrl,
                data: settings.data,
                success: function (data) {
                    var vData = eval(data.Content.rows);
                    setTbodyHTML(settings, vData);
                    if (settings.pageTo) {
                        setPageHTML(data.Content.total, data.Content.page, data.Content.records);
                    }
                },
                complete: function () {
                    if (settings.complete) {
                        settings.complete.call();
                    }
                }
            });
        }
        catch (e) { }
    }

    function setTbodyHTML(settings, vRows) {
        var vCols = settings.colModel;

        var arrHTML = new Array();
        $(vRows).each(function (i) {
            arrHTML.push("<tr>");
            //多选
            //if (settings.multiselect) {
            //    arrHTML.push("<td><input type='checkbox' name='ckb_tabgrid' /></td>");
            //}
            //详细(列)
            if (settings.detail && settings.detail.isShow) {
                arrHTML.push("<td title='详细' style='cursor:pointer;'><img id='" + settings.tabID + "_showdetail_img_" + i + "' name='showdetail_img' src='/img/tabgrid/tab_expand.png' alt='' /></td>");
            }
            $(vCols).each(function (j) {

                var v;
                if (this.formatter) {
                    var vCallReturn = this.formatter.call(this, vRows[i]);
                    if (vCallReturn) {
                        v = vCallReturn;
                    }
                }
                else {
                    v = this.name ? eval("vRows[i]." + this.name) : "";
                }

                if (this.formatter || !v) {
                    arrHTML.push("<td");
                }
                else {
                    arrHTML.push("<td title='" + v + "'");
                }

                if (this.align) {
                    arrHTML.push(" align=" + this.align);
                }
                arrHTML.push(">");
                arrHTML.push(v);
                arrHTML.push("</td>");
            });

            arrHTML.push("</tr>");

            //详细(行)
            if (settings.detail && settings.detail.isShow) {
                arrHTML.push("<tr style='display:none;'>");
                arrHTML.push("<td>&nbsp;</td>");
                var vDetailColspan = settings.multiselect ? vCols.length + 1 : vCols.length;
                arrHTML.push("<td id='" + settings.tabID + "_showdetail_td_" + i + "' colspan='" + vDetailColspan + "'>&nbsp;</td>");
                arrHTML.push("</tr>");
            }
        });
        $("#" + settings.tabID + " tbody").html(arrHTML.join(''));

        //设置详细事件
        if (settings.detail.onShowDetail) {
            var vImgs = $("#" + settings.tabID + " td").find("img[name='showdetail_img']");
            vImgs.each(function () {
                var vID = $(this).attr("id");
                var arrID = vID.split('_');
                var vIndex = arrID[arrID.length - 1];
                var vImgObj = $(this);
                $(this).parent().click(function () {
                    if (vImgObj.attr("src").indexOf("/img/tabgrid/tab_collapse.png") >= 0) {
                        vImgObj.attr("src", "/img/tabgrid/tab_expand.png");
                        $("#" + settings.tabID + "_showdetail_td_" + vIndex).parent().css("display", "none");
                    }
                    else {
                        var vReturnDetailHTML = settings.detail.onShowDetail.call(this, vRows[vIndex], settings.tabID + "_showdetail_td_" + vIndex);
                        $("#" + settings.tabID + "_showdetail_td_" + vIndex).parent().css("display", "");
                        vImgObj.attr("src", "/img/tabgrid/tab_collapse.png");
                        //if (vReturnDetailHTML) {
                        //    $("#grid_showdetail_td_" + vIndex).html(vReturnDetailHTML);
                        //}
                    }
                });
            });
        }
    }

    function setPageHTML(vTotal, vPage, vRecords) {
        var settings = $.fn.tabgrid.opts;

        var arrPageHTML = new Array();
        arrPageHTML.push("<a id='" + settings.tabID + "_page_first'>首&nbsp;&nbsp;&nbsp;页</a>");
        arrPageHTML.push("<a id='" + settings.tabID + "_page_prev'>上一页</a>");
        arrPageHTML.push("<select id='" + settings.tabID + "_page_turnpage' style='width:auto;'>");
        for (var i = 1; i <= vTotal; i++) {
            if (i == settings.page) {
                arrPageHTML.push("<option selected value='" + i + "'>" + i + "</option>");
            }
            else {
                arrPageHTML.push("<option value='" + i + "'>" + i + "</option>");
            }
        }
        arrPageHTML.push("</select>");
        arrPageHTML.push("&nbsp;<a id='" + settings.tabID + "_page_next'>下一页</a>");
        arrPageHTML.push("<a id='" + settings.tabID + "_page_last'>尾&nbsp;&nbsp;&nbsp;页</a>");
        arrPageHTML.push("总共<font style='font-weight:bold;margin:3px;'>" + vRecords + "</font>条，每页显示&nbsp;");
        arrPageHTML.push("<select id='" + settings.tabID + "_page_setsize' style='width:auto;'>");
        $(settings.rowList).each(function (i) {
            if (settings.rowList[i] == settings.pageSize) {
                arrPageHTML.push("<option selected value='" + settings.rowList[i] + "'>" + settings.rowList[i] + "</option>");
            }
            else {
                arrPageHTML.push("<option value='" + settings.rowList[i] + "'>" + settings.rowList[i] + "</option>");
            }
        });
        arrPageHTML.push("</select>");
        arrPageHTML.push("&nbsp;条记录，共<font style='font-weight:bold;margin:3px;'>" + vTotal + "</font>页&nbsp;&nbsp;");

        $("#" + settings.pageTo).html(arrPageHTML.join(''));

        if (vTotal) {
            //首页事件
            $("#" + settings.tabID + "_page_first").click(function () {
                settings.page = 1;
                $.fn.tabgrid.reload(settings);
            });
            //上一页事件
            $("#" + settings.tabID + "_page_prev").click(function () {
                settings.page = settings.page <= 1 ? 1 : settings.page - 1;
                $.fn.tabgrid.reload(settings);
            });
            //下一页事件
            $("#" + settings.tabID + "_page_next").click(function () {
                settings.page = settings.page >= vTotal ? vTotal : settings.page + 1;
                $.fn.tabgrid.reload(settings);
            });
            //尾页事件
            $("#" + settings.tabID + "_page_last").click(function () {
                settings.page = vTotal;
                $.fn.tabgrid.reload(settings);
            });
            //选择页下拉框事件
            $("#" + settings.tabID + "_page_turnpage").change(function () {
                settings.page = this.value;
                $.fn.tabgrid.reload(settings);
            });
            //每页显示多少条记录下拉框事件
            $("#" + settings.tabID + "_page_setsize").change(function () {
                settings.page = 1;
                settings.pageSize = this.value;
                $.fn.tabgrid.reload(settings);
            });
        }
    }

})(jQuery);
//**********【START】设置Grid高度********
function setTabGridHeight(vFrmCondition, vHeight) {
    var vConditionHeight = 0;
    if (!vFrmCondition) {
        vFrmCondition = "frmCondition";
    }
    if ($("#" + vFrmCondition)) {
        vConditionHeight = $("#" + vFrmCondition).height();
    }
    if (!vHeight) {
        vHeight = 85;
    }
    var vHeight = $(window).height() - vConditionHeight - vHeight;
    return vHeight;
}
//**********【END】设置Grid高度**********