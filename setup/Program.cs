using System;
using System.Windows.Forms;
using WixSharp;
using WixSharp.Forms;

namespace setup
{
    internal class Program
    {
        static void Main()
        {
            var project = new ManagedProject("autoupdater-test",
                             new Dir(@"%ProgramFiles%\autoupdater-test",
                                 new DirFiles(@"..\bin\Release\net6.0-windows\*.*")));

            project.GUID = new Guid("f66a4b6b-50ce-42ed-b174-9a3435d8cd08");

            project.ManagedUI = new ManagedUI();

            project.ManagedUI.InstallDialogs.Add(Dialogs.Welcome)
                                            .Add(Dialogs.Licence)
                                            .Add(Dialogs.InstallDir)
                                            .Add(Dialogs.Progress)
                                            .Add(Dialogs.Exit);

            project.ManagedUI.ModifyDialogs.Add(Dialogs.MaintenanceType)
                                           .Add(Dialogs.Progress)
                                           .Add(Dialogs.Exit);

            project.ManagedUI.Icon = "../icon.ico";
            project.ControlPanelInfo.ProductIcon = "../icon.ico";
            project.ControlPanelInfo.Manufacturer = "Simon Sedlatschek";

            project.BuildMsi();
        }
    }
}