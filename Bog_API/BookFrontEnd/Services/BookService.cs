using BookFrontEnd.Interfaces;
using Entities.Entities;

namespace BookFrontEnd.Services
{
    public class BookService : IBookService
    {
        private static HttpClient _httpClient = CreateHttpClient();

        public async Task<IList<Book>> GetAllBooks()
        {
            var list = new List<Book>();
            HttpResponseMessage response = await _httpClient.GetAsync("api/book");
            if (response.IsSuccessStatusCode)
            {
                list = await response.Content.ReadFromJsonAsync<List<Book>>();
            }

            //Check if list is Null
            IsListNull(list);
            return list;
        }

        public async Task<IList<Book>> GetAllBooksByTitle(string title)
        {
            var list = new List<Book>();
            HttpResponseMessage response = await _httpClient.GetAsync($"api/book/{title}");
            if (response.IsSuccessStatusCode)
            {
                list = await response.Content.ReadFromJsonAsync<List<Book>>();
            }

            //Check if list is Null
            IsListNull(list);

            return list;
        }


        private static HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7065/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;

        }

        //Check if list is Null, if true throw exception
        private bool IsListNull(List<Book> list)
        {
            if (list == null)
            {
                throw new Exception("List null");
            }
            return false;
        }
    }
}
