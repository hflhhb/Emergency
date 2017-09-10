/*
 * Chained - jQuery / Zepto chained selects plugin
 *
 * Copyright (c) 2010-2014 Mika Tuupola
 *
 * Licensed under the MIT license:
 *   http://www.opensource.org/licenses/mit-license.php
 *
 * Project home:
 *   http://www.appelsiini.net/projects/chained
 *
 * Version: 1.0.0
 *
 */

;(function($, window, document, undefined) {
    "use strict";

    $.fn.remoteChained = function(options) { 
        var settings = $.extend({}, $.fn.remoteChained.defaults, options);

        /* Loading text always clears the select. */
        if (settings.loading) {
            settings.clear = true;
        }

        var _select = $(this);
        settings.url = typeof _select.attr('data-url') === 'undefined' ? settings.url : _select.attr('data-url');
        settings.parents = typeof _select.attr('data-parents') === 'undefined' ? settings.parents : _select.attr('data-parents');
        settings.required = typeof _select.attr('data-required') === 'boolean' ? _select.attr('required') : settings.required;

        var _data_firstTitle = _select.attr('data_firstTitle');
        var _data_firstValue = _select.attr('data_firstValue');
        var _data_jsonName = _select.attr('data-jsonName');
        var _data_jsonValue = _select.attr('data-jsonValue');
        if (_select.attr('data-first-title')) _data_firstTitle = _select.attr('data-first-title');
        if (_select.attr('data-first-value')) _data_firstValue = _select.attr('data-first-value');
        if (_select.attr('data-json-name')) _data_jsonName = _select.attr('data-json-name');
        if (_select.attr('data-json-value')) _data_jsonValue = _select.attr('data-json-value');

        settings.firstTitle = typeof _data_firstTitle === 'undefined' ? settings.firstTitle : _data_firstTitle;
        settings.firstValue = typeof _data_firstValue === 'undefined' ? settings.firstValue : _data_firstValue;
        settings.jsonName = typeof _data_jsonName === 'undefined' ? settings.jsonName : _data_jsonName;
        settings.jsonValue = typeof _data_jsonValue === 'undefined' ? settings.jsonValue : _data_jsonValue;


        return this.each(function() {
            /* Save this to self because this changes when scope changes. */
            var self = this;
            var request = false; /* Track xhr requests. */

            if (settings.parents) {
                $(settings.parents).each(function () {
                    $(this).bind("change", function () {

                        /* Build data array from parents values. */
                        var data = {};
                        $(settings.parents).each(function () {
                            var id = $(this).attr(settings.attribute);
                            var value = ($(this).is("select") ? $(":selected", this) : $(this)).val();
                            data[id] = value;

                            /* Optionally also depend on values from these inputs. */
                            if (settings.depends) {
                                $(settings.depends).each(function () {
                                    /* Do not include own value. */
                                    if (self !== this) {
                                        var id = $(this).attr(settings.attribute);
                                        var value = $(this).val();
                                        data[id] = value;
                                    }
                                });
                            }
                        });

                        /* If previous request running, abort it. */
                        /* TODO: Probably should use Sinon to test this. */
                        if (request && $.isFunction(request.abort)) {
                            request.abort();
                            request = false;
                        }

                        if (settings.clear) {
                            if (settings.loading) {
                                /* Clear the select and show loading text. */
                                build.call(self, { "": settings.loading });
                            } else {
                                /* Clear the select. */
                                $("option", self).remove();
                            }

                            /* Force updating the children to clear too. */
                            $(self).trigger("change");
                        }
                        
                        data["rnd"] = getRandomNum(0, 99999999);
                        request = $.getJSON(settings.url, data, function (json) {
                            build.call(self, json);

                            /* Force updating the children. */
                            $(self).trigger("change");
                        });
                    });

                    /* If we have bootstrapped data given in options. */
                    if (settings.bootstrap) {
                        build.call(self, settings.bootstrap);
                        settings.bootstrap = null;
                    }
                });
            } else {  //没有parents的情况，直接加载数据。
                /* If previous request running, abort it. */
                /* TODO: Probably should use Sinon to test this. */
                if (request && $.isFunction(request.abort)) {
                    request.abort();
                    request = false;
                }
                 
                var data = {};
                request = $.getJSON(settings.url, data, function (json) {
                    build.call(self, json);

                    /* Force updating the children. */
                    $(self).trigger("change");
                });
            }

            function getRandomNum(Min, Max) {
                var Range = Max - Min;
                var Rand = Math.random();
                return (Min + Math.round(Rand * Range));
            }
            /* Build the select from given data. */
            //--------兼容SelectListItem默认下拉列表Json格式, 此函数修改by 肖海根 2017-03-30
            function build(json) {
                /* If select already had something selected, preserve it. */
                var selected_key = $(":selected", self).val();

                var defaultValue = $(self).attr("data-value");
                if (defaultValue) { 
                    $(self).removeAttr("data-value");
                    selected_key = defaultValue;
                }

                if (!$.isArray(json)) { return };
                 
                var _required = settings.required;
                var _firstTitle = settings.firstTitle;
                var _firstValue = settings.firstValue;
                var _jsonName = settings.jsonName;
                var _jsonValue = settings.jsonValue;

                /* Clear the select. */
                $("option", self).remove();
                 
                var _html = !_required ? '<option value="' + String(_firstValue) + '">' + String(_firstTitle) + '</option>' : '';

                // 区分标题、值的数据
                if (typeof _jsonName === 'string' && _jsonName.length) {
                    // 无值字段时使用标题作为值
                    if (typeof _jsonValue !== 'string' || !_jsonValue.length) {
                        _jsonValue = _jsonName;
                    };

                    for (var i = 0, l = json.length; i < l; i++) {
                        _html += '<option value="' + String(json[i][_jsonValue]) + '">'+ String(json[i][_jsonValue]) +"  -  "+ String(json[i][_jsonName]) + '</option>';
                    };

                    // 数组即为值的数据
                } else {
                    for (var i = 0, l = json.length; i < l; i++) {
                        _html += '<option value="' + String(json[i]) + '">' + String(json[i]) + '</option>';
                    };
                };
                  
                $(self).append(_html);

                /* Loop option again to set selected. IE needed this... */
                $(self).children().each(function() {
                    if ($(this).val() === selected_key + "") {
                        $(this).attr("selected", "selected");
                    }
                });

                /* If we have only the default value disable select. */
                if (1 === $("option", self).size() && $(self).val() === "") {
                    $(self).prop("disabled", true);
                } else {
                    $(self).prop("disabled", false);
                }
            }
        });
    };

    /* Alias for those who like to use more English like syntax. */
    $.fn.remoteChainedTo = $.fn.remoteChained;

    /* Default settings for plugin. */
    $.fn.remoteChained.defaults = {
        attribute: "name",
        required : false,
        firstTitle: "",
        firstValue: "", 
        jsonName: "Text",
        jsonValue: "Value",
        depends : null,
        bootstrap : null,
        loading : null,
        clear : false
    };

})(window.jQuery || window.Zepto, window, document);