var Kou = Kou || {};

//
Kou.Map = function (container, options) {
    var defaults = {
        center: new BMap.Point(121.487864, 31.249223),
        currentCity: "上海",
        enableScrollWheelZoom: true
    };
    this.container = container || "allmap";
    //
    this.options = $.extend({}, defaults, options);

    this.initial(container);
};

Kou.Map.prototype = {
    //
    initial: function () {
        // 百度地图API功能
        var map = new BMap.Map(this.container);    // 创建Map实例
        this.map = map;
        map.centerAndZoom(this.options.center, 16);  // 初始化地图,设置中心点坐标和地图级别
        map.addControl(new BMap.MapTypeControl());   //添加地图类型控件
        map.setCurrentCity(this.options.currentCity);          // 设置地图显示的城市 此项是必须设置的
        map.enableScrollWheelZoom(this.options.enableScrollWheelZoom);     //开启鼠标滚轮缩放

        //单击获取点击的经纬度
        map.addEventListener("click", function (e) {
            console.info(e.point.lng + "," + e.point.lat);
        });

        //
        // 添加带有定位的导航控件
        var navigationControl = new BMap.NavigationControl({
            // 靠左上角位置
            anchor: BMAP_ANCHOR_TOP_LEFT,
            // LARGE类型
            type: BMAP_NAVIGATION_CONTROL_LARGE,
            // 启用显示定位
            enableGeolocation: true
        });
        map.addControl(navigationControl);
        // 添加定位控件
        var geolocationControl = new BMap.GeolocationControl();
        geolocationControl.addEventListener("locationSuccess", function (e) {
            // 定位成功事件
            var address = '';
            address += e.addressComponent.province;
            address += e.addressComponent.city;
            address += e.addressComponent.district;
            address += e.addressComponent.street;
            address += e.addressComponent.streetNumber;
            dialogTop("当前定位地址为：" + address, 'success');
        });

        //
        geolocationControl.addEventListener("locationError", function (e) {
            // 定位失败事件
            dialogTop(e.message, 'error');
        });
        map.addControl(geolocationControl);

        //
        return map;
    },

    iniAutoComplete: function (input, onSearchComplete) {
        var map = this.map;
        var ac = new BMap.Autocomplete(    //建立一个自动完成的对象
            {
                input: input,
                location: map
            });
        ac.addEventListener("onconfirm", function (e) {    //鼠标点击下拉列表后的事件
            var _value = e.item.value;
            var tmpPlace = _value.province + _value.city + _value.district + _value.street + _value.business;
            searchAndSetPlace(tmpPlace, onSearchComplete);
        });

        this.autoComplete = ac;
    },

    searchAndSetPlace: function (txtPlace, onSearchComplete) {
        var map = this.map;
        map.clearOverlays();    //清除地图上所有覆盖物
        var local = new BMap.LocalSearch(map, { //智能搜索
            onSearchComplete: function () {
                var searchResults = local.getResults();
                if (!searchResults) return;
                var firstPoi = searchResults.getPoi(0);
                if (!firstPoi) return;
                var pp = firstPoi.point;    //获取第一个智能搜索的结果
                if (!pp) return;
                map.centerAndZoom(pp, 18);
                map.addOverlay(new BMap.Marker(pp));    //添加标注
                !!onSearchComplete && onSearchComplete(searchResults);
            }
        });
        local.search(txtPlace);
    }

};