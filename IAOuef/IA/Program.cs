using IA.Network;

class Program
{
    static void Main(string[] args)
    {
        Connection.OuvrirConnexion();

        string message = Connection.RecevoirMessage();
        Connection.EnvoyerMessage("OUEF");

        Connection.FermerConnexion();
    }
}
