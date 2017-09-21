using LeaRun.ResourceManage.Business;
using LeaRun.ResourceManage.Entity;
using LeaRun.ResourceManage.Model;
using LeaRun.Util.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.GIS.Business
{
    public class ResourceMapBLL
    {
        //private IAuthorizeService service = new AuthorizeService(DbFactory.Base());
        private GasStationBLL gasStationBLL = new GasStationBLL();
        private SchoolBLL schoolBLL = new SchoolBLL();
        private CameraBLL cameraBLL = new CameraBLL();
        private HospitalBLL hospitalBLL = new HospitalBLL();

        public object GetResources(string[] kinds, ResourceMapQuery query)
        {
            IEnumerable<GasStationEntity> gasStations = new GasStationEntity[] { };
            IEnumerable<CameraEntity> cameras = new CameraEntity[] { };
            IEnumerable<HospitalEntity> hospitals = new HospitalEntity[] { };
            IEnumerable<SchoolEntity> schools = new SchoolEntity[] { };
            if (kinds != null)
            {
                foreach (var item in kinds)
                {
                    if (item.EqualsIgnoreCase("gasStation"))
                    {
                        gasStations = gasStationBLL.GetList(query);
                    }
                    if (item.EqualsIgnoreCase("camera"))
                    {
                        cameras = cameraBLL.GetList(query);
                    }
                    if (item.EqualsIgnoreCase("hospital"))
                    {
                        hospitals = hospitalBLL.GetList(query);
                    }
                    if (item.EqualsIgnoreCase("school"))
                    {
                        schools = schoolBLL.GetList(query);
                    }
                }
            }
            return new
            {
                GasStations = gasStations,
                Cameras = cameras,
                Hospitals = hospitals,
                Schools  = schools
            };
        }


    }
}
