//
var geoc = new BMap.Geocoder();
var kouMap = new Kou.Map("allmap", {
    enableNavCtrl:false,
    onMapClick: function (e) {
        var point = e.point;
        map.clearOverlays();    //清除地图上所有覆盖物
        var marker = new BMap.Marker(point);// 创建标注
        map.addOverlay(marker);// 将标注添加到地图中
        marker.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画

        $("#lng").val(point.lng);
        $("#lat").val(point.lat);
        //
        geoc.getLocation(point, function (rs) {
            $("#txtSuggest").val(rs.address);
        });
    }
});
var map = kouMap.map;
//
kouMap.iniAutoComplete("txtSuggest", onConfirmed);
//查询事件
$("#btn_Search").click(function () {
    kouMap.searchAndSetPlace($("#txtSuggest").val(), onConfirmed);
});
//查询回车
$('#txtSuggest').on('keydown', function (event) {
    if (event.keyCode == "13") {
        $('#btn_Search').trigger("click");
    }
});

//确定
function mergeLoaction(postData) {
    postData.Address = $("#txtSuggest").val();
    postData.Longitude = $("#lng").val();
    postData.Latitude = $("#lat").val();

    return postData;
}

function focusRequestLocation(location) {
    var reqAddress = location.Address;
    var reqLng = location.Longitude;
    var reqLat = location.Latitude;
    //
    setTimeout(function () {
        $("#txtSuggest").val(reqAddress);
        if (reqLng > 0 && reqLat > 0) {
            locateMapPoint(reqLng, reqLat);
        } else {
            reqAddress && kouMap.searchAndSetPlace(reqAddress, onConfirmed);
        }
    }, 200);
    
    
}
function onConfirmed(ret, pp) {
    locateMapPoint(pp.lng, pp.lat);
}
function locateMapPoint(reqLng, reqLat)
{
    map.clearOverlays();
    var reqPt = new BMap.Point(reqLng, reqLat);
    var reqMarker = new BMap.Marker(reqPt);// 创建标注
    map.addOverlay(reqMarker);// 将标注添加到地图中
    map.panTo(reqPt);
    reqMarker.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画
    $("#lng").val(reqLng);
    $("#lat").val(reqLat);
}

//setTimeout(function () {
//    focusRequestLocation();
//}, 200);


