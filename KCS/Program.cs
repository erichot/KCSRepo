
namespace KCS
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using DevExpress.Internal;
    using DevExpress.Utils.Taskbar;
    using DevExpress.Utils.Taskbar.Core;
    using KCS.Common.DAL;
    using KCS.Common.Utils;
    using KCS.Form;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            TaskbarAssistant.Default.Initialize();
            AppDomain.CurrentDomain.AssemblyResolve += OnCurrentDomainAssemblyResolve;
            //DataDirectoryHelper.LocalPrefix = "KCS";
            DevAVDataDirectoryHelper.LocalPrefix = "KCS";
            bool exit;
            //using (IDisposable singleInstanceApplicationGuard = DataDirectoryHelper.SingleInstanceApplicationGuard("KCS", out exit))
            using (IDisposable singleInstanceApplicationGuard = DevAVDataDirectoryHelper.SingleInstanceApplicationGuard("KCS", out exit))
            {
                if (exit) return;
                DevExpress.XtraEditors.WindowsFormsSettings.SetDPIAware();
                DevExpress.XtraEditors.WindowsFormsSettings.EnableFormSkins();
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle("Office 2016 Colorful");
                DevExpress.XtraEditors.WindowsFormsSettings.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
                DevExpress.XtraEditors.WindowsFormsSettings.ScrollUIMode = DevExpress.XtraEditors.ScrollUIMode.Touch;
                SystemConfigure.LoadDataBaseConnectionData();
                if (SystemConfigure.LanguageSelect == "zh_TW" || SystemConfigure.LanguageSelect == "zh_CN")
                {
                    DevExpress.Utils.AppearanceObject.DefaultFont = new Font("宋体", AppHelper.GetDefaultChSize());



                }
                else
                {
                    DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Segoe UI", AppHelper.GetDefaultSize());
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                DevExpress.Mvvm.CommandBase.DefaultUseCommandManager = false;


                using (new StartUpProcess())
                {
                    using (StartUpProcess.Status.Subscribe(new DemoStartUp()))
                    {
                        System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
                        System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);

                        // For Toyota 取消系統管理員權限要求：Client端電腦的登入使用者並未具有該電腦之Administator，導致使用衝突
                        //if (1==1 || principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                        if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                        {
                            try
                            {
                                Application.Run(new MainForm());
                            }
                            catch (Exception ex)
                            {
                                var strDateInfo = "An unhandled exception has occurred:" + DateTime.Now + "\r\n";

                                var str = string.Format(strDateInfo + "Exception type:{0}\r\nException message:{1}\r\nException message:{2}\r\n",
                                                           ex.GetType().Name, ex.Message, ex.StackTrace);

                                WriteLog(str);
                                DevExpress.XtraEditors.XtraMessageBox.Show("An error occurred, please check the program log!", "KCS error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                            startInfo.UseShellExecute = true;
                            startInfo.WorkingDirectory = Environment.CurrentDirectory;
                            startInfo.FileName = Application.ExecutablePath;
                            //设置启动动作,确保以管理员身份运行
                            startInfo.Verb = "runas";
                            try
                            {
                                System.Diagnostics.Process.Start(startInfo);
                            }
                            catch
                            {
                                return;
                            }
                            //退出
                            Application.Exit();
                        }
                    }
                }
            }
        }

        /// <summary>
        ///错误弹窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str;
            var strDateInfo = "An unhandled exception has occurred" + DateTime.Now + "\r\n";
            var error = e.Exception;
            if (error != null)
            {
                str = string.Format(strDateInfo + "Exception type:{0}\r\nException message:{1}\r\nException message:{2}\r\n",
                     error.GetType().Name, error.Message, error.StackTrace);
            }
            else
            {
                str = string.Format("Application thread error:{0}", e);
            }

            WriteLog(str);
            DevExpress.XtraEditors.XtraMessageBox.Show("An error occurred, please check the program log！", "KCS error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var error = e.ExceptionObject as Exception;
            var strDateInfo = "An unhandled exception has occurred：" + DateTime.Now + "\r\n";
            var str = error != null ? string.Format(strDateInfo + "Application UnhandledException:{0};\n\rStack information:{1}", error.Message, error.StackTrace) : string.Format("Application UnhandledError:{0}", e);

            WriteLog(str);
            DevExpress.XtraEditors.XtraMessageBox.Show("An error occurred, please check the program log！", "KCS error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="str"></param>
        static public void WriteLog(string str)
        {
            string szConfigPath = string.Format("{0}\\ErrLog", System.Windows.Forms.Application.StartupPath);
            if (!Directory.Exists(szConfigPath))
            {
                Directory.CreateDirectory(szConfigPath);
            }
            string szConfigFile = string.Format("{0}\\ErrLog\\ErrLog.txt", System.Windows.Forms.Application.StartupPath);
            using (var sw = new StreamWriter(szConfigFile, true))
            {
                sw.WriteLine(str);
                sw.WriteLine("---------------------------------------------------------");
                sw.Close();
            }
        }
        static Assembly OnCurrentDomainAssemblyResolve(object sender, ResolveEventArgs args) {
            string partialName = DevExpress.Utils.AssemblyHelper.GetPartialName(args.Name).ToLower();
            if(partialName == "entityframework" ) {
                string path = Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), partialName + ".dll");
                return Assembly.LoadFrom(path);
            }
            return null;
        }

        
    }
}
