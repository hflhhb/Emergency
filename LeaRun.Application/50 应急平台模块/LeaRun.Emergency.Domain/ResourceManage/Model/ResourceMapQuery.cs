using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.ResourceManage.Model
{
    public class MapPoint
    {
        public MapPoint(decimal lng, decimal lat)
        {
            Longitude = lng;
            Latitude = lat;
        }


        public static MapPoint Parse(decimal? lng, decimal? lat)
        {
            if (!lng.HasValue || !lat.HasValue) return null;
            return new MapPoint(lng.Value, lat.Value);
        }

        /// <summary>
        /// 经度
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public decimal Latitude { get; set; }
    }


    public class MapBounds
    {
        public MapBounds(MapPoint sw, MapPoint ne)
        {
            SouthWest = sw;
            NorthEast = ne;
        }

        public static MapBounds Parse(decimal? lngsw, decimal? latsw, decimal? lngne, decimal? latne)
        {
            return new MapBounds(MapPoint.Parse(lngsw, latsw), MapPoint.Parse(lngne, latne));
        }

        /// <summary>
        /// 西南边界的点（左下角）
        /// </summary>
        public MapPoint SouthWest { get; set; }
        /// <summary>
        /// 东北边界的点（右上角）
        /// </summary>
        public MapPoint NorthEast { get; set; }
    }

    public class ResourceMapQuery
    {
        public MapBounds Bounds { get; set; }
        public string AreaName { get; set; }
        public string Address { get; set; }
    }
}
