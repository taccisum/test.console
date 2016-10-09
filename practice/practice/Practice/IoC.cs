using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;


namespace practice.Practice
{
    public class IoC : Test
    {
        public IoC(string testName = "IoC test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
        }

        protected override void RealTestOutPut()
        {
            IUnityContainer container = new UnityContainer();
            var section = GetSection();
            container.LoadConfiguration(section);
            ILanguage language = container.Resolve<ILanguage>();
            Console.WriteLine(language.GetDesc());
        }

        private UnityConfigurationSection GetSection()
        {
            var file = new FileInfo("IoCSettings.xml");
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = file.FullName };
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            return (UnityConfigurationSection)configuration.GetSection("unity");  
        }
    }

    public interface ILanguage
    {
        string GetDesc();
    }

    public abstract class LanguageBase : ILanguage
    {
        protected string Desc { get; set; }

        public virtual string GetDesc()
        {
            return Desc;
        }
    }


    public class Chinese : LanguageBase
    {
        public Chinese()
        {
            Desc = "中文";
        }
    }

    public class Japanese : LanguageBase
    {
        public Japanese()
        {
            Desc = "日本語の";
        }
    }

    public class English : LanguageBase
    {
        public English()
        {
            Desc = "English";
        }
    }

    public class Korean : LanguageBase
    {
        public Korean()
        {
            Desc = "한국어";
        }
    }
}
