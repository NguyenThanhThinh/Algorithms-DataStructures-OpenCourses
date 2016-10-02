namespace _02.StringEditor.Interfaces
{
    public interface ICommand
    {
        string Execute(string @params, IStringEditor stringEditor);
    }
}