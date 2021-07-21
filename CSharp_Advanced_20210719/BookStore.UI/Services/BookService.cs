using BookStore.Shared.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.UI.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        private string _baseUrl = "https://localhost:5001/api/Book/";
        public BookService(HttpClient client)
        {
            _httpClient = client;
        }
        
        
        public async Task DeleteBook(int id)
        {
            string url = _baseUrl + id.ToString();

            HttpResponseMessage response = await _httpClient.DeleteAsync(url);
        }

        public async Task<List<Book>> GetAll()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _baseUrl);
            HttpResponseMessage response = await _httpClient.SendAsync(request);

            string jsonText = await response.Content.ReadAsStringAsync();

            List<Book> bookList = JsonConvert.DeserializeObject<List<Book>>(jsonText);

            return bookList;
        }

        public async Task<Book> GetById(int id)
        {
            string extendetUrl = _baseUrl + id.ToString();

            HttpResponseMessage response = await _httpClient.GetAsync(extendetUrl);
            string jsonText = await response.Content.ReadAsStringAsync();

            Book currentBook = JsonConvert.DeserializeObject<Book>(jsonText);

            return currentBook;
        }

        public async Task InsertBook(Book book)
        {
            string jsonText = JsonConvert.SerializeObject(book);

            StringContent data = new StringContent(jsonText, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_baseUrl, data);
        }

        public async Task UpdateBook(Book book)
        {
            string extendetURL = _baseUrl + book.Id.ToString();

            string jsonText = JsonConvert.SerializeObject(book);

            StringContent data = new StringContent(jsonText, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(extendetURL, data);

            
        }
    }
}
