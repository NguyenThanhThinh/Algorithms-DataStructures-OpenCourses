namespace _02.StringEditor.Core
{
    using System;

    using _02.StringEditor.Interfaces;

    public class App
    {
        private readonly IAppController appController;

        public App(IAppController appController)
        {
            this.appController = appController;
        }

        public void Run()
        {
            while (true)
            {
                var inputLine = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(inputLine))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                try
                {
                    var commandResult = this.appController.DispatchCommand(inputLine);
                    Console.WriteLine(commandResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}