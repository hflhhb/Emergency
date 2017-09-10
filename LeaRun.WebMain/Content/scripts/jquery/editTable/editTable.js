//----------------------------------------------------------------------------------------------------
//   模块： 可编辑表格公用函数
//   作者： 肖海根  
//   日期： 2015-12-08
//   说明：
//      （1） 列头th 可以使用的扩展属性： 
//          data-key:  主键列字段名
//          data-colname:  普通列字段名
//          data-editor:  编辑控件的ID；编辑控件可以写在th里。
//
//      (2) 每列的编辑控件如下编写：
//          <th width="150px;" data-editor="txt_Field_Desc" data-colname="Field_Desc" style="background-color:greenyellow">
//              <input id='txt_Field_Desc' type='text' style='width:97%; display:none;' value=''
//                  onkeypress="if (event.keyCode==13) {HideTDInputText(this);}" onblur="HideTDInputText(this);" />
//          </th>
//------------------------------------------------------------------------------------------------------

//begin ----表格的单元格编辑公用函数----

//在线编辑Table单元格绑定click事件
function editTable(tableId) {
    var table = $("#" + tableId);
    if (table) {
        table.on("click", "tbody>tr>td", function (e) {
            var rowIndex = $(this).parent().index();
            var colIndex = $(this).index();

            var vThead = table.find('thead>tr:last');
            var vThColumn = vThead.find("th").eq(colIndex);
            var ElementID = vThColumn.attr("data-editor");

            if (ElementID) {
                ShowTDInputText(ElementID);
            }

        });
    }

    return table;
}

//当点击单元格时，在当前单元格内显示本列th上data-editor属性指明的input控件
function ShowTDInputText(ElementID) {
    if (event.srcElement.tagName.toLowerCase() == "td") { 
        var objTD = event.srcElement;
        var objValue = $.trim(objTD.innerText);
        $(objTD).attr("title", objValue);
        objTD.innerText = "";
        
        var oInput = document.getElementById(ElementID);
        if (oInput != null) {
            objTD.appendChild(oInput);
            $(oInput).val($.trim(objValue));
            $("#" + ElementID).show();
            getSelectPos(ElementID);
        }
    }
}

//当输入控件失去焦点或按回车键时，隐藏本控件。
//控件上标准事件处理如下： onkeypress="if (event.keyCode==13) {HideTDInputText(this);}" onblur="HideTDInputText(this);" 
function HideTDInputText(oInput) {
    var oInputValue = $(oInput).val();

    var objTD = oInput.parentElement;
    document.body.appendChild(oInput);
    $(oInput).hide();

    var strInputValue = $.trim(oInputValue);

    //tr对象的dirty 属性代表本行数据已经被修改
    if ($(objTD).attr("title") != strInputValue) {
        $(objTD.parentElement).attr('dirty', true);
    }

    $(objTD).text(strInputValue);
    $(objTD).attr("title", strInputValue);

    $(objTD).css("backgroundColor", $(objTD.parentElement).css("backgroundColor"));

}

//得到当前单元格
function GetCurrentCell(oInput) {
    var objTD = oInput.parentElement;
    if ("td" != objTD.tagName.toLowerCase()) {
        objTD = objTD.parentElement;
    }
    if ("td" != objTD.tagName.toLowerCase()) {
        objTD = objTD.parentElement;
    }
    return objTD;
}

//得到当前行索引
function GetCurrentRowIndex(oInput) {
    var objTD = GetCurrentCell(oInput);
    var rowIndex = $(objTD).parent().index();
    var colIndex = $(objTD).index();

    return rowIndex;
}
 
//得到当前行索引
function GetCurrentColIndex(oInput) {
    var objTD = GetCurrentCell(oInput);
    var rowIndex = $(objTD).parent().index();
    var colIndex = $(objTD).index();

    return colIndex;
}

//得到当前行指定列名的列索引。
function GetCellIndexByColumnName(oInput,columnName) {
    var objTD = GetCurrentCell(oInput);
    var rowIndex = $(objTD).parent().index();
    var colIndex = $(objTD).index();

    var objTable = objTD.parentElement.parentElement;
    if ("table" != objTable.tagName.toLowerCase()) {
        objTable = objTable.parentElement;
    }
    if ("table" != objTable.tagName.toLowerCase()) {
        objTable = objTable.parentElement;
    }


    var table = $(objTable);
     
    var vThead = table.find('thead>tr:last');
    var arrColEdit = vThead.find("th[data-colname]");  //th上的data-editor 是编辑控件的ID，还需要指明data-colname属性，代表编辑列名
    var arrColKey = vThead.find("th[data-key]");      //th上的data-key，代表主键列名

    //获取列名对应的列索引
    var iColumnIndex = -1;
    $(arrColKey).each(function (j) {
        var col = arrColKey[j];
        var keyname = $(vThead[0].cells[col.cellIndex]).attr("data-key");

        if (keyname && keyname.length > 0) {
            if (keyname.toLowerCase() == columnName.toLowerCase()) {
                iColumnIndex = col.cellIndex;
            }
        }
    });

    if (iColumnIndex < 0) {
        $(arrColEdit).each(function (j) {
            var col = arrColEdit[j];

            var colname = $(vThead[0].cells[col.cellIndex]).attr("data-colname");
            if (colname && colname.length > 0) {
                if (colname.toLowerCase() == columnName.toLowerCase()) {
                    iColumnIndex = col.cellIndex;
                }
            }
        });
    }

    if (iColumnIndex >= 0)
    {
        return iColumnIndex;
    }
    return -1;
}

//得到当前行指定列名的单元格的innerText。
function GetCellValueByColumnName(oInput, columnName) { 
    var objTD = GetCurrentCell(oInput);
    var iColumnIndex = GetCellIndexByColumnName(oInput, columnName);
    //获取单元格值
    var vCellValue = "";
    if (iColumnIndex>=0 && objTD && objTD.parentElement) {
        if (objTD.parentElement.cells[iColumnIndex] != null) {
            vCellValue = objTD.parentElement.cells[iColumnIndex].innerText;

            if (! $.trim(vCellValue)) {
                vCellValue= $(objTD.parentElement.cells[iColumnIndex]).attr("title");
            }
        }
    }
    vCellValue = $.trim(vCellValue);
    return vCellValue; 
}

//设置当前行指定列名单元格的innnerText
function SetCellValueByColumnName(oInput, columnName,cellValue) {
    var objTD = GetCurrentCell(oInput);
    var iColumnIndex = GetCellIndexByColumnName(oInput, columnName);
    //获取单元格值 
    if (iColumnIndex>=0 && objTD && objTD.parentElement) {
        objTD.parentElement.cells[iColumnIndex].innerText = $.trim(cellValue);
        $(objTD.parentElement).attr('dirty', true);
    } 
}

//获取编辑的单元格的JSON值。
//条件本行数据是否被修改 tr上dirty属性为true
function GetCellJsonValues(tableId) {
    var table = $("#" + tableId);

    var arrRow = table.find('tbody>tr');
    var vThead = table.find('thead>tr:last');
    var arrColEdit = vThead.find("th[data-editor]");  //th上的data-editor 是编辑控件的ID，还需要指明data-colname属性，代表编辑列名
    var arrColKey = vThead.find("th[data-key]");      //th上的data-key，代表主键列名

    var jsonTable = [];

    $(arrRow).each(function (i) {
        var row = arrRow[i];
        //本行数据是否被修改
        var dirty = $(arrRow[i]).attr('dirty');
        if (dirty) {

            var jsonRow = {};

            $(arrColKey).each(function (j) {
                var col = arrColKey[j];
                var keyname = $(vThead[0].cells[col.cellIndex]).attr("data-key");

                var vKeyValue = "";
                var inputCtrl = $(row.cells[col.cellIndex]).find("input");
                if (inputCtrl.length == 1) {
                    vKeyValue = inputCtrl.val();
                } else {
                    vKeyValue = row.cells[col.cellIndex].innerText;
                }
                jsonRow[keyname] = vKeyValue;
            });


            $(arrColEdit).each(function (j) {
                var col = arrColEdit[j];

                var colname = $(vThead[0].cells[col.cellIndex]).attr("data-colname");
                if (colname && colname.length > 0) {
                    var vText = "";
                    var inputCtrl = $(row.cells[col.cellIndex]).find("input");
                    if (inputCtrl.length == 1) {
                        vText = inputCtrl.val();
                    } else {
                        vText = row.cells[col.cellIndex].innerText;
                    }
                    jsonRow[colname] = vText;
                }
            });

            jsonTable.push(jsonRow);

        }// end if dirty 
    });

    return jsonTable;
}


//重写dom的focus方法，光标定在最后
function getSelectPos(obj) {

    var esrc = document.getElementById(obj);
    if (esrc == null) {
        esrc = event.srcElement;
    }

    if ("input" == esrc.tagName.toLowerCase()) {
        var inputType = $(esrc).attr("type");
        if (inputType && "text" == inputType.toLowerCase()) {
            var rtextRange = esrc.createTextRange();
            rtextRange.moveStart('character', esrc.value.length);
            rtextRange.collapse(true);
            rtextRange.select();
        } else {
            $(esrc).focus();
        }

    } else {
        $(esrc).focus();
    }
}

//end   ----表格的单元格编辑公用函数----