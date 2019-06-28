using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeyrekAsistan.ReadTasks;

namespace ZeyrekAsistan.Helper
{
    public static class TaskHelper
    {
        /// <summary>
        /// bütün görevleri web servis üzerinden getirir 
        /// </summary>
        /// <param name="userName">kullanıcı adı</param>
        /// <param name="type">Task ya da Approval değerlerini alır</param>
        /// <returns></returns>
        public static IList<ZTask> GetTaskList(string userName, string type)
        {
            IList<ZTask> taskList = null;
            try
            {

                ReadTask readTask = new ReadTask();
                var tasks = readTask.ZReadTask(userName);

                if (tasks != null && tasks.Length > 0)
                {
                    taskList = tasks.Where(e => e.Type == type).ToList(); //task listesinde type sütunu Task ya da Approval değerleri alabilir 
                }
            }
            catch (Exception)
            {

                throw;
            }

            return taskList;
        }
        
    }
}
