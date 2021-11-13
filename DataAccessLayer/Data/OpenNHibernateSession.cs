using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessLayer.Data
{
    public class OpenNHibernateSession
    {

        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath("~/Models/NHibernateConfig/nhibernate.configuration.xml");
            configuration.Configure(configurationPath);
            var studentConfigurationFile = HttpContext.Current.Server.MapPath("~/Models/NHibernateConfig/Student.mapping.xml");
            configuration.AddFile(studentConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
