using LeaRun.ResourceManage.Entity;
using LeaRun.ResourceManage.Model;
using LeaRun.Util.Web;
using System.Collections.Generic;

namespace LeaRun.ResourceManage.IService
{
    /// <summary>
    /// �� �� 1.5
    /// Copyright (c) 2017-2020 Ф����
    /// �� ����HFL
    /// �� �ڣ�2017-09-13 00:46
    /// �� ����Camera
    /// </summary>
    public interface ICameraService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<CameraEntity> GetList(string queryJson);

        /// <summary>
        /// �б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        IEnumerable<CameraEntity> GetPageList(Pagination pagination, string queryJson);


        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<CameraEntity> GetList(ResourceMapQuery query);

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        CameraEntity GetEntity(string keyValue);
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        void SaveForm(string keyValue, CameraEntity entity);
        #endregion
    }
}
