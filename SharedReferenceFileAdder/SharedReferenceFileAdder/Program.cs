using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;

namespace SharedReferenceFileAdder
{
     class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Program>();
            builder.RegisterType<MainForm>();

            builder.RegisterType<UserFileHelper>().As<IUserFileHelper>();
            builder.RegisterType<DirectoryWrapper>().As<IDirectory>();
            builder.RegisterType<FileWrapper>().As<IFile>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            { 
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(scope.Resolve<MainForm>()); 
            }  
        }
    }
}
