namespace _02.StringEditor.Commands
{
    using _02.StringEditor.Interfaces;

    [Command]
    public class Append : ICommand
    {
        public string Execute(string @params, IStringEditor stringEditor) => stringEditor.Append(@params) ? "OK" : "ERROR";
    }
}