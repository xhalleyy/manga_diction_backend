using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace manga_diction_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MangaSearchRequest
{
    public string? Name { get; set; }
    public string[]? TagInput { get; set; }
    public string? Demographic { get; set; }
    public string? Status { get; set; }
}
    public class MangaDexController : ControllerBase
    {
        [HttpPost("GetManga")]
        public async Task<string> GetManga([FromBody] MangaSearchRequest request)
        {


            //https://api.mangadex.org/manga?limit=15&title=tokyo&includedTagsMode=AND&excludedTagsMode=OR&order%5BlatestUploadedChapter%5D=desc&contentRating%5B%5D=safe&contentRating%5B%5D=suggestive&contentRating%5B%5D=erotica

            //https://api.mangadex.org/manga?limit=15&title=tokyo&includedTagsMode=AND&excludedTagsMode=OR&order%5BlatestUploadedChapter%5D=desc&contentRating%5B%5D=safe&contentRating%5B%5D=suggestive&contentRating%5B%5D=erotica

            //https://api.mangadex.org/manga?limit=15&title=&includedTagsMode=AND&excludedTagsMode=OR&order%5BlatestUploadedChapter%5D=desc&contentRating%5B%5D=safe&contentRating%5B%5D=suggestive&contentRating%5B%5D=erotica

            //https://api.mangadex.org/manga?limit=15&title=tokyo&includedTagsMode=AND&excludedTagsMode=OR&order%5BlatestUploadedChapter%5D=desc&publicationDemographic%5B%5D=shounen&status%5B%5D=ongoing&contentRating%5B%5D=safe&contentRating%5B%5D=suggestive&contentRating%5B%5D=erotica

            Dictionary<string, string> tagLookup = new Dictionary<string, string>
            {
                { "tragedy", "f8f62932-27da-4fe4-8ee1-6779a8c5edba" },
                { "comedy", "4d32cc48-9f00-4cca-9b5a-a839f0764984" },
                {"drama", "b9af3a63-f058-46de-a9a0-e0c13906197a"},
                // Add more tag mappings as needed
            };

            using (HttpClient httpClient = new HttpClient())
            {
                // Set the base address of the API
                httpClient.BaseAddress = new Uri("https://api.mangadex.org/");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "MangaDictionApi");
                try
                {
                    // Construct the URL with query parameters
                    string apiUrl = "manga?limit=15";

                    // Include manga name query parameter if provided
                    if (!string.IsNullOrEmpty(request.Name))
                    {
                        apiUrl += $"&title={request.Name}";
                    }

                    // Include tag IDs if tagInput matches any tag name in the lookup table
                    if ( request.TagInput.Length > 0)
                    {
                        foreach(string tag in request.TagInput)
                        {
                            string tagId = tagLookup[tag.ToLower()];

                            apiUrl += $"&includedTags[]={tagId}";
                        }
                    }

                    // Include demographic parameter if provided
                    if (!string.IsNullOrEmpty(request.Demographic))
                    {
                        apiUrl += $"&publicationDemographic[]={request.Demographic}";
                    }

                    // Include status parameter if provided
                    if (!string.IsNullOrEmpty(request.Status))
                    {
                        apiUrl += $"&status[]={request.Status}";
                    }

                    // Add contentRating parameter
                    apiUrl += "&contentRating[]=safe&contentRating[]=suggestive&contentRating[]=erotica";

                    // Add order parameter
                    apiUrl += "&order%5BlatestUploadedChapter%5D=desc";

                    // Add includes parameter
                    apiUrl += "&includes[]=cover_art&includes[]=author";

                    // Send a GET request
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the content of the response as a string
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response:");
                        Console.WriteLine(responseBody);

                        return responseBody; // Return the response body
                    }
                    else
                    {
                        // Print the status code if the request was not successful
                        Console.WriteLine($"Request failed with status code {response.StatusCode}");
                        return null; // Return null if the request was not successful
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Handle any exceptions that occurred during the request
                    Console.WriteLine($"Request failed: {ex.Message}");
                    return null; // Return null if an exception occurs
                }
            }
        }
    }



}



