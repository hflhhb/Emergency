using LeaRun.ResourceManage.Business;
using LeaRun.ResourceManage.Entity;
using LeaRun.ResourceManage.Model;
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

        public object GetResources(ResourceMapQuery query)
        {
            return new
            {
                GasStations = new GasStationEntity[] { },
                Cameras = cameraBLL.GetList(query),
                Hospitals = hospitalBLL.GetList(query),
                Schools  = new SchoolEntity[] { }
            };
        }


    }
}
