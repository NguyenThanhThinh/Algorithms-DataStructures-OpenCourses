namespace _02.StringEditor.Commands
{
    using _02.StringEditor.Interfaces;

    [Command]
    public class Print : ICommand
    {
        public string Execute(string @params, IStringEditor stringEditor)
        {
            var res = stringEditor.Print();

            return res;
        }
    }
}