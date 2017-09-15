using LeaRun.ResourceManage.Entity;
using LeaRun.ResourceManage.IService;
using LeaRun.Data;
using LeaRun.Util.Web;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util.Extension;
using LeaRun.Util;

namespace LeaRun.ResourceManage.Service
{
    /// <summary>
    /// �� �� 1.5
    /// Copyright (c) 2017-2020 Ф����
    /// �� ����HFL
    /// �� �ڣ�2017-09-13 00:46
    /// �� ����Camera
    /// </summary>
    public class CameraService : Dao<CameraEntity>, ICameraService
    {
        /// <summary>
        /// �������ַ��������Ĺ��캯��
        /// </summary>
        /// <param name="dbcontext"></param>
        public CameraService(DbContextBase dbcontext) : base(dbcontext)
        {
        }

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<CameraEntity> GetList(string queryJson)
        {
            return base.Queryable().OrderByDescending(t => t.CreateTime).ToList();
        }

        /// <summary>
        /// �б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        public IEnumerable<CameraEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<CameraEntity>();
            var queryParam = queryJson.ToJObject();
            //��ѯ����
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "Code":            //���
                        expression = expression.And(t => t.Code.Contains(keyword));
                        break;
                    case "Area":            //����
                        expression = expression.And(t => t.Area.Contains(keyword));
                        break;
                    case "Address":        //��ַ
                        expression = expression.And(t => t.Address.Contains(keyword));
                        break;
                    default:
                        break;
                }
            }
            return base.FindList(expression, pagination);
        }

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public CameraEntity GetEntity(string keyValue)
        {
            return base.FindEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            base.Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, CameraEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                base.Update(entity);
            }
            else
            {
                entity.Create();
                base.Insert(entity);
            }
        }
        #endregion
    }
}
