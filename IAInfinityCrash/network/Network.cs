using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace IAInfinityCrash.network
{
    class Network
    {
        private TcpClient client;
        private StreamReader fluxEntrant;
        private StreamWriter fluxSortant;
        private int port = 1234;
        private String ip = "127.0.0.0";

        private void Connexion()
        {
            this.client = new TcpClient(ip, port);

        }

        private void CreationFlux()
        {
            this.fluxEntrant = new StreamReader(client.GetStream());
            this.fluxSortant.AutoFlush = true;
            this.fluxSortant = new StreamWriter(client.GetStream());
        }

        public void Start()
        {
            // Mise en place de la connexion avec le serveur
            this.Connexion();
            this.CreationFlux();
            String messageRecu = "";
            String messageAEnvoyer = "";
            Console.WriteLine("-- Début de la transmission --");
            do
            {
                // Réception du message du serveur
                messageRecu = this.fluxEntrant.ReadLine();
                Console.WriteLine("<< " + messageRecu);
                // Envoie du message de réponse
                messageAEnvoyer = "Quoi ?";
                this.fluxSortant.WriteLine(messageAEnvoyer);
                Console.WriteLine(">> " + messageAEnvoyer);
            } while (!messageRecu.Equals("FIN"));
            Console.WriteLine("-- Fin de la transmission --");
            // Fermeture de la connexion
            this.client.Close();
        }

    }
}
