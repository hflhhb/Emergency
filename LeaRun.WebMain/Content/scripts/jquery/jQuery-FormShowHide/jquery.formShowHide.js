/*!
 * jQuery FormShowHide 1.0
 * https://github.com/dkeeghan/jQuery-FormShowHide
 * Copyright 2014 Damian Keeghan
 * Released under the MIT license:
 * http://www.opensource.org/licenses/mit-license.php
 */

!
function(e) {
    e.formShowHide = function(o, n) {
        var i = this;
        i.$el = e(o),
        i.el = o,
        "undefined" == typeof i.$el.data("formShowHide") && (i.options = e.extend({},
        e.formShowHide.defaultOptions, n), i.$el.data("formShowHide", i), i.nodeType = i.el.nodeName.toUpperCase(), i.inputType = "INPUT" === i.nodeType ? i.$el.attr("type").toUpperCase() : "", i.showType = "", i.showParams = "", i.init = function() {
            var o = "change.formShowHide keyup.formShowHide check.formShowHide initCheck.formShowHide";
            if ("SELECT" === i.nodeType) i.$el.off(".formShowHide").on(o, i.onChange);
            else if ("OPTION" === i.nodeType) i.$el.closest("select").off(".formShowHide").on(o, i.onChange);
            else if ("INPUT" === i.nodeType) if ("RADIO" === i.inputType) {
                var n = i.$el.attr("name");
                e('input[name="' + n + '"]').off(".formShowHide").on(o, i.onChange)
            } else "CHECKBOX" === i.inputType ? i.$el.off(".formShowHide").on(o, i.onChange) : "TEXT" === i.inputType && (i.showType = i.$el.attr(i.options.showTypeAttr), i.showParams = i.$el.attr(i.options.showParamsAttr), i.showType && i.showParams && (i.showParams = i.convertStrToArr(i.showParams, !0)), i.$el.off(".formShowHide").on(o, i.onChange));
            i.$el.trigger("initCheck.formShowHide")
        },
        i.convertStrToArr = function(o, n) {
            if (n = "boolean" == typeof n && n === !0, o = o.replace(/ +(?= )/g, ""), "" === o) return [];
            var i = [];
            if ( - 1 === o.indexOf(" ")) i.push(n ? o: "#" + o);
            else {
                var t = o.split(" ");
                e(t).each(function(e, o) {
                    i.push(n ? o: "#" + o)
                })
            }
            return n ? i: e.fn.formShowHide.utils.unique(i)
        },
        i.checkShowDefined = function(e) {
            var o = e.attr(i.options.showAttr);
            return "undefined" == typeof o ? "": o
        },
        i.checkHideDefined = function(e) {
            var o = e.attr(i.options.hideAttr);
            return "undefined" == typeof o ? "": o
        },
        i.idsToShow = function() {
            var n = "";
            if ("SELECT" === i.nodeType || "OPTION" === i.nodeType) {
                var t = "OPTION" === i.nodeType ? i.$el.parent() : i.$el;
                n = i.checkShowDefined(t.find("option:selected")),
                t.find("option").each(function(o, t) {
                    e(t).prop("selected") || (n += " " + i.checkHideDefined(e(t)))
                })
            } else if ("INPUT" === i.nodeType) if ("RADIO" === i.inputType) {
                var r = i.$el.attr("name");
                e('input[name="' + r + '"]').each(function(o, t) {
                    n += e(t).prop("checked") ? i.checkShowDefined(e(t)) : " " + i.checkHideDefined(e(t))
                })
            } else "CHECKBOX" === i.inputType ? n += i.$el.prop("checked") ? " " + i.checkShowDefined(i.$el) : " " + i.checkHideDefined(e(o)) : "TEXT" === i.inputType && i.showType && i.showParams && "function" == typeof e.formShowHide.types[i.showType] && i.showParams.length > 0 && e.formShowHide.types[i.showType](i.el, i.showParams) && (n = i.checkShowDefined(i.$el));
            return "undefined" == typeof n ? [] : i.convertStrToArr(e.fn.formShowHide.utils.trim(n))
        },
        i.idsToHide = function(n) {
            var t = "";
            if ("SELECT" === i.nodeType || "OPTION" === i.nodeType) {
                var r = "OPTION" === i.nodeType ? i.$el.parent() : i.$el;
                t = i.checkHideDefined(r.find("option:selected")),
                r.find("option").each(function(o, n) {
                    e(n).prop("selected") || (t += " " + i.checkShowDefined(e(n)))
                })
            } else if ("INPUT" === i.nodeType) if ("RADIO" === i.inputType) {
                var h = i.$el.attr("name");
                e('input[name="' + h + '"]').each(function(o, n) {
                    t += e(n).prop("checked") ? " " + i.checkHideDefined(e(n)) : " " + i.checkShowDefined(e(n))
                })
            } else "CHECKBOX" === i.inputType ? t += i.$el.prop("checked") ? " " + i.checkHideDefined(e(o)) : " " + i.checkShowDefined(e(o)) : "TEXT" === i.inputType && i.showType && i.showParams && "function" == typeof e.formShowHide.types[i.showType] && i.showParams.length > 0 && (e.formShowHide.types[i.showType](i.el, i.showParams) || (t = i.checkShowDefined(i.$el)));
            var f = i.convertStrToArr(e.fn.formShowHide.utils.trim(t));
            return n.length === f.length && 1 === n.length ? f: (e(n).each(function(e, o) {
                for (var n in f) if (f[n] === o) return void f.splice(n, 1)
            }), f)
        },
        i.onChange = function(o) {
            var n = i.idsToShow(),
            t = i.idsToHide(n);
            n.length === t.length && e.fn.formShowHide.utils.compare(n, t) || e(n).each(function(n, t) {
                e(t).is(":visible") ? i.options.showAlreadyVisible(n, t) : "initCheck" === o.type ? i.options.initShow(n, t) : i.options.show(n, t)
            }),
            e(t).each(function(n, t) {
                var r = function() {
                    e(t).hasClass(i.options.resetClass) && (e(t).find("input:text").attr("value", "").trigger("keyup"), e(t).find("option:selected").prop("selected", !1).end().find("option:first-child").prop("selected", !0).trigger("check.formShowHide").trigger("keyup"), e(t).find("input:radio, input:checkbox").prop("checked", !1).trigger("check.formShowHide").trigger("keyup"))
                };
                "initCheck" === o.type ? i.options.initHide(n, t, r) : i.options.hide(n, t, r)
            })
        },
        i.init())
    },
    e.formShowHide.types = {
        lessThan: function(o, n) {
            var i = "number" == typeof parseInt(n[0], 10) ? parseInt(n[0], 10) : 0,
            t = "" === e(o).val() ? 0 : parseInt(e(o).val(), 10);
            return i > t
        }
    },
    e.formShowHide.defaultOptions = {
        show: function(o, n, i) {
            e(n).show(),
            "function" == typeof i && i()
        },
        hide: function(o, n, i) {
            e(n).hide(),
            "function" == typeof i && i()
        },
        initShow: function(o, n, i) {
            e(n).show(),
            "function" == typeof i && i()
        },
        initHide: function(o, n, i) {
            e(n).hide(),
            "function" == typeof i && i()
        },
        showAlreadyVisible: function(o, n) {
            e(n).show()
        },
        showAttr: "data-show-id",
        showTypeAttr: "data-show-type",
        showParamsAttr: "data-show-params",
        hideAttr: "data-hide-id",
        resetClass: "formShowHide_reset"
    },
    e.fn.formShowHide = function(o) {
        return this.each(function() {
            new e.formShowHide(this, o)
        })
    },
    e.fn.formShowHide.utils = {
        unique: function(e) {
            for (var o = 0; o < e.length;) {
                for (var n = e.length; n > o; n -= 1) e[n] === e[o] && e.splice(n, 1);
                o += 1
            }
            return e
        },
        trim: function(e) {
            return e.replace(/^\s+/, "").replace(/\s+$/, "")
        },
        compare: function(e, o) {
            if (e.length !== o.length) return ! 1;
            for (var n = e.sort(), i = o.sort(), t = 0; o[t]; t += 1) if (n[t] !== i[t]) return ! 1;
            return ! 0
        }
    }
} (jQuery);