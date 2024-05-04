using IA.Model;
using IA.Network;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();

        Connection.OuvrirConnexion();



        string message = Connection.RecevoirMessage();
        Connection.EnvoyerMessage("OUEF");

        Connection.FermerConnexion();
    }
}
