namespace _02.StringEditor
{
    using _02.StringEditor.Core;
    using _02.StringEditor.Interfaces;
    using _02.StringEditor.Models;

    public class StringEditorTest
    {
        public static void Main()
        {
            IStringEditor stringEditor = new StringEditor();
            IAppController appController = new AppController(stringEditor);

            App app = new App(appController);

            app.Run();
        }
    }
}
