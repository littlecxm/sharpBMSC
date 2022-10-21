using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC.My;

[EditorBrowsable(EditorBrowsableState.Never)]
[GeneratedCode("MyTemplate", "10.0.0.0")]
internal class MyApplication : WindowsFormsApplicationBase
{

    private void MyApplication_Shutdown(object sender, EventArgs e)
    {
    }

    private void MyApplication_Startup(object sender, StartupEventArgs e)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private void MyApplication_UnhandledException(object sender, Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs e)
    {
        var msgBoxResult = Interaction.MsgBox("An unhandled exception has occurred in the application: \r\n" + e.Exception.Message + "\r\n\r\nClick Yes to save a back-up, click No otherwise, or click Cancel to ignore this exception and continue.", MsgBoxStyle.YesNoCancel | MsgBoxStyle.Critical, "Unhandled Exception");
        if (msgBoxResult == MsgBoxResult.Cancel)
        {
            e.ExitApplication = false;
        }
        if (msgBoxResult == MsgBoxResult.Yes)
        {
            var now = DateTime.Now;
            var text = "\\AutoSave_" + Conversions.ToString(now.Year) + "_" + Conversions.ToString(now.Month) + "_" + Conversions.ToString(now.Day) + "_" + Conversions.ToString(now.Hour) + "_" + Conversions.ToString(now.Minute) + "_" + Conversions.ToString(now.Second) + "_" + Conversions.ToString(now.Millisecond) + ".IBMSC";
            MyProject.Forms.MainWindow.ExceptionSave(MyProject.Application.Info.DirectoryPath + text);
            Interaction.MsgBox("A back-up has been saved to " + MyProject.Application.Info.DirectoryPath + text, MsgBoxStyle.Information);
        }
    }
}
