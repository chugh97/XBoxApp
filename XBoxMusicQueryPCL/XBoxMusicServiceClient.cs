using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xbox.Music;


namespace XboxMusicQueryPCL
{
    /*
     * Uses portable rest client at https://github.com/AdvancedREI/Xbox.Music to connect to xbox music
     * This client takes care of renewing access token.
     * 
     */
    public class XBoxMusicServicePCLClient
    {
        private MusicClient serviceClient;

        private string clientSecret = "";
        private string ClientSecret
        {
            get { return clientSecret; }
        }

        private string clientId = "";
        public string ClientID 
        { 
            get { return clientId; } 
        }


        public XBoxMusicServicePCLClient (string ClientId, string ClientSecret)
        {
            clientId = ClientId;
            clientSecret = ClientSecret;
        }

        public bool Connect()
        {
            serviceClient = new MusicClient(ClientID, ClientSecret);
            try
            {
                Task task = serviceClient.Find("Foo Fighters", maxItems: 1);
                task.Wait();
                return task.Status.Equals(TaskStatus.RanToCompletion);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }


        public async Task<string> FindAlbums (string Artist)
        {
           serviceClient = new MusicClient(ClientID, ClientSecret);
           ContentResponse resp = await serviceClient.Find(Artist);
            
            return resp.Albums.ToString();
        }

    }
}
