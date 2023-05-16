using RestSharp;

namespace DeckOfCards.Models
{
    public class CardsDAL
    {
        public Deck GetDeck()
        {
            string URL = "https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";
            RestClient client = new RestClient(URL);
            RestRequest request = new RestRequest();

            Deck response = client.Get<Deck>(request);

            return response;
        }

        public Hand GetHand(string id)
        {
            string url = $"https://deckofcardsapi.com/api/deck/{id}/draw/?count=5";
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest();

            Hand response = client.Get<Hand>(request);

            return response;
        }



    }
}
