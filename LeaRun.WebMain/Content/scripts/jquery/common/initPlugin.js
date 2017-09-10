//**********【START】对HTML元素进行Ajax扩展************** 
$(document).ready(function () {
    
    IntiAutoCompletes(); 
});

function IntiAutoCompletes() {
    
    //初始化所有AutoComplete选择框
    $(".AutoComplete").each(function () {
        var _url = $(this).attr('data-url');
        var _parents = $(this).attr('data-parents');
        var _data_resultType = $(this).attr('data-resultType');
        var _data_hiddenInputId = $(this).attr('data-hiddenInputId');
        var _data_jsonName = $(this).attr('data-jsonName');
        var _data_jsonValue = $(this).attr('data-jsonValue');
        var _data_jsonDesc = $(this).attr('data-jsonDesc');

        if ($(this).attr('data-result-type')) _data_resultType = $(this).attr('data-result-type');
        if ($(this).attr('data-hidden-input-id')) _data_hiddenInputId = $(this).attr('data-hidden-input-id');
        if ($(this).attr('data-json-name')) _data_jsonName = $(this).attr('data-json-name');
        if ($(this).attr('data-json-value')) _data_jsonValue = $(this).attr('data-json-value');
        if ($(this).attr('data-json-desc')) _data_jsonDesc = $(this).attr('data-json-desc');

        if (!_data_jsonName) _data_jsonName = "Text";
        if (!_data_jsonValue) _data_jsonValue = "Value";
        if (!_data_jsonDesc) _data_jsonDesc = "Desc";

        if (!_data_resultType) {
            if (_data_hiddenInputId) {
                _data_resultType = "Text";
            } else {
                _data_resultType = "Value";
            }
        }

        vUrl = getRandURL(_url);
        $(this).autocomplete(vUrl, {
            minChars: 2,
            width: $(this).width,
            mustMatch: false,
            autoFill: false,
            max: 100,
            cache: false,
            scrollHeight: 200,
            multiple: false,
            extraParams: {
                jsonParams: function () {
                    var post_data = {};
                    if (_parents) {
                        $(_parents).each(function () {
                            var key = $(this).attr("id");
                            if ($(this).attr("name")) {
                                key = $(this).attr("name");
                            }
                            var value = $(this).val();
                            post_data[key] = value;
                        });
                    }
                    return JSON.stringify(post_data);
                },
                rnd: function () { return getRandomNum(0, 99999999); }
            },
            dataType: "json",
            parse: function (json) {
                var rows = [];
                var aData = json.data;
                if (aData) {
                    for (var i = 0; i < aData.length; i++) {
                        if (_data_resultType == "Value") {
                            rows[i] = {
                                data: aData[i],
                                value: aData[i].Value,
                                result: aData[i].Value
                            };
                        } else {
                            rows[i] = {
                                data: aData[i],
                                value: aData[i].Value,
                                result: aData[i].Text,
                            };
                        }
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

            if (_data_hiddenInputId) {
                $("#" + _data_hiddenInputId).val(vCode);
            }

            //if (vSelectAction) {
            //    vSelectAction.call(this, data, value);
            //}
        });

    });
}
//**********【END】对HTML元素进行Ajax扩展******************