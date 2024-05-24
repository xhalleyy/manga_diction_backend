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
                { "tragedy", "f8f62932-27da-4fe4-8ee1-6779a8c5edba" }, { "comedy", "4d32cc48-9f00-4cca-9b5a-a839f0764984" }, {"drama", "b9af3a63-f058-46de-a9a0-e0c13906197a"},
                {"oneshot", "0234a31e-a729-4e28-9d6a-3f87c4966b9e"}, {"thriller", "07251805-a27e-4d59-b488-f0bfbec15168"}, {"award winning", "0a39b5a1-b235-4886-a747-1d05d216532d"},
                {"reincarnation", "0bc90acb-ccc1-44ca-a34a-b9f3a73259d0"}, {"sci-fi", "256c8bd9-4904-4360-bf4f-508a76d67183"},
                {"time travel", "292e862b-2d17-4062-90a2-0356caa4ae27"}, {"genderswap", "2bd2e8d0-f146-434a-9b51-fc9ff2c5fe6a"}, {"traditional games", "31932a7e-5b8e-49a6-9f12-2afa39dc544c"},
                {"official colored", "320831a8-4026-470b-94f6-8353740e6f04"}, {"historical", "33771934-028e-4cb3-8744-691e866a923e"}, {"monsters", "36fd93ea-e8b8-445e-b836-358f02b3d33d"},
                {"action", "391b0423-d847-456f-aff0-8b0cfc03066b"}, {"demons", "39730448-9a5f-48a2-85b0-a70db87b1233"}, {"psychological", "3b60b75c-a2d7-4860-ab56-05f391bb889c"},
                {"ghosts", "3bb26d85-09d5-4d2e-880c-c34b974339e9"},{"animals", "3de8c75d-8ee3-48ff-98ee-e20a65c86451"},{"long strip", "3e2b8dae-350e-4ab8-a8ce-016e844b9f0d"},
                {"romance", "423e2eae-a7a2-4a8b-ac03-a8351462d71d"},{"ninja", "489dd859-9b61-4c37-af75-5b18e88daafc"},{"anthology", "51d83883-4103-437c-b4b1-731cb73d786c"},
                {"boys' love", "5920b825-4181-4a17-beeb-9918b0ff7a30"},{"incest", "5bd0e105-4481-44ca-b6e7-7544da56b1a3"},{"crime", "5ca48985-9a9d-4bd8-be29-80dc0303db72"},
                {"survival", "5fff9cde-849c-4d78-aab0-0d52b2ee1d25"},{"zombies", "631ef465-9aba-4afb-b0fc-ea10efe274a8"},{"reverse harem","65761a2a-415e-47f3-bef2-a9dababba7a6"},
                {"sports", "69964a64-2f90-4d33-beeb-f3ed2875eb4c"},{"superhero", "7064a261-a137-4d3a-8848-2d385de3a99c"},{"martial arts","799c202e-7daa-44eb-9cf7-8a3c0441531e"},
                {"fan colored", "7b2ce280-79ef-4c09-9b58-12b7c23a9b78"},{"samurai", "81183756-1453-4c81-aa9e-f6e1b63be016"},{"magical girls","81c836c9-914a-4eca-981a-560dad663e73"},
                {"mafia", "85daba54-a71c-4554-8a28-9901a8b0afad"},{"adventure", "87cc87cd-a395-47af-b27a-93258283bbc6"},{"self-published","891cf039-b895-47f0-9229-bef4c96eccd4"},
                {"virtual reality", "8c86611e-fab7-4986-9dec-d1a2f44acdd5"},{"loli", "2d1f5d56-a1e5-4d0d-a961-2193588b08ec"},{"office workers","92d6d951-ca5e-429c-ac78-451071cbf064"},
                {"video games", "9438db5a-7e2a-4ac0-b39e-e0d95a34b8a8"},{"post-apocalyptic", "9467335a-1b83-4497-9231-765337a00b96"},{"sexual violence","97893a4c-12af-4dac-b6be-0dffb353568e"},
                {"crossdressing", "9ab53f92-3eed-4e9b-903a-917c86035ee3"},{"magic", "a1f53773-c69a-4ce5-8cab-fffcd90b1565"},{"girls' love","a3c67850-4684-404e-9b7f-c69850ee5da6"},
                {"harem", "aafb99c1-7f60-43fa-b75f-fc9502ce29c7"},{"military", "ac72833b-c4e9-4878-b9db-6c8a4a99444a"},{"wuxia","acc803a4-c95a-4c22-86fc-eb6b582d82a2"},
                {"isekai", "ace04997-f6bd-436e-b261-779182193d3d"},{"4-koma", "b11fda93-8f1d-4bef-b2ed-8803d3733170"},{"doujinshi","b13b2a48-c720-44a9-9c77-39c9979373fb"},
                {"philosophical", "b1e97889-25b4-4258-b28b-cd7f4d28ea9b"},{"gore", "b29d6a3d-1569-4e7a-8caf-7557bc92cd5d"},{"medical","c8cbe35b-1b2b-4a3f-9c37-db84c4514856"},
                {"school life", "caaa44eb-cd40-4177-b930-79d3ef2afe87"},{"horror", "cdad7e68-1419-41dd-bdce-27753074a640"},{"fantasy","cdc58593-87dd-415e-bbc0-2ec27bf404cc"},
                {"villainess", "d14322ac-4d6f-4e9b-afd9-629d5f4d8a41"},{"vampires", "d7d1730f-6eb0-4ba6-9437-602cac38664c"},{"delinquents","da2d50ca-3018-4cc0-ac7a-6b7d472a29ea"},
                {"monster girls", "dd1f77c5-dea9-4e2b-97ae-224af09caf99"},{"shota", "ddefd648-5140-4e5f-ba18-4eca4071d19b"},{"police","df33b754-73a3-4c54-80e6-1a74a8058539"},
                {"web comic", "e197df38-d0e7-43b5-9b09-2842d0c326dd"},{"slice of life", "e5301a23-ebd9-49dd-a0cb-2add944c7fe9"},{"aliens","e64f6742-c834-471d-8d72-dd51fc02b835"},
                {"cooking", "ea2bc92d-1c26-4930-9b7c-d5c0dc1b6869"},{"supernatural", "eabc5b4c-6aff-42f3-b657-3e90cbd00b75"},{"mystery","ee968100-4191-4968-93d3-f82d72be7e46"},
                {"adaptation", "f4122d1c-3b44-44d0-9936-ff7502c39ad3"},{"music", "f42fbf9e-188a-447b-9fdc-f19dc1e4d685"},{"full color","f5ba408b-0e7a-484d-8d49-4e9125ac96de"},
                {"gyaru", "fad12b5e-68ba-460e-b933-9ae8318f5b65"}
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
                     List<string> filteredList = request.TagInput.Where(item => !string.IsNullOrEmpty(item)).ToList();
                    if (filteredList.Count > 0)
                    {
                        foreach (string tag in filteredList)
                        {
                             string lowerTag = tag.ToLower();
                            if(tagLookup.ContainsKey(lowerTag)){

                                string tagId = tagLookup[lowerTag];

                                apiUrl += $"&includedTags[]={tagId}";
                            }
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

        [HttpGet("GetMangaById/{id}")]
        public async Task<string> GetMangaById(string id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                // Set the base address of the API
                httpClient.BaseAddress = new Uri("https://api.mangadex.org/");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "MangaDictionApi");
                try
                {
                    // Send a GET request with the id parameter
                    HttpResponseMessage response = await httpClient.GetAsync($"manga/{id}?includes[]=cover_art&includes[]=author");
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

        [HttpGet("GetMangaAuthor/{authorId}")]
        public async Task<string> GetMangaAuthor(string authorId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                // Set the base address of the API
                httpClient.BaseAddress = new Uri("https://api.mangadex.org/");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "MangaDictionApi");
                try
                {
                    // Send a GET request with the id parameter
                    HttpResponseMessage response = await httpClient.GetAsync($"author/{authorId}?includes[]=");
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



