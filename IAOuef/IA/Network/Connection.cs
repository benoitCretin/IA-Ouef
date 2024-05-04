using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace IA.Network
{
    public class Connection
    {
        //Singleton interne
        private static Connection instance;
        //Get du singleton
        private static Connection Instance
        {
            get
            {
                return instance;
            }
        }



        private TcpClient client;
        /// <summary>Le flux entrant depuis le serveur</summary>
        private StreamReader fluxEntrant;
        /// <summary>Le flux sortant vers le serveur</summary>
        private StreamWriter fluxSortant;

        /// <summary>
        /// Constructeur naturel
        /// </summary>
        private Connection()
        {
            this.client = new TcpClient("127.0.0.1", 1234);
            this.fluxEntrant = new StreamReader(client.GetStream());
            this.fluxSortant = new StreamWriter(client.GetStream());
            this.fluxSortant.AutoFlush = true;
        }

        /// <summary>
        /// Envoi d'un message au serveur
        /// </summary>
        /// <param name="message">Le message à envoyer</param>
        public static void EnvoyerMessage(string message)
        {
            Connection.Instance.fluxSortant.WriteLine(message);
            Console.WriteLine(">> " + message);
        }

        /// <summary>
        /// Réception d'un message du serveur
        /// </summary>
        /// <returns>Message reçu</returns>
        public static string RecevoirMessage()
        {
            string messageRecu = Connection.Instance.fluxEntrant.ReadLine();
            Console.WriteLine("<< " + messageRecu);
            return messageRecu;
        }

        public static void OuvrirConnexion()
        {
            if (instance != null) FermerConnexion();
            instance = new Connection();
        }

        //Ferme la connexion
        public static void FermerConnexion()
        {
            Instance.client.Close();
            instance = null;
        }
    }
}
